using System.Threading;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using EasyModbus;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System;
using DXM.Web.Interface.Models;
using DXM.Protocolo;
using DXM.VTX;
using System.Collections.Generic;

namespace DXM.Web.Interface
{
    public class Program
    {
        public static string urlString = "http://*:5001;http://localhost:5001";
        public static string user = "indefinido";
        public static string regTipo = "Versão Básica";
        public static string chave = "J3GS4SMC50BXTA41";
        public static string chaveVetor = "E94NFGU4N5M47NA3";
        public static string pasta = "HKEY_CURRENT_USER\\DXM_vt";
        public static string sInf = crypt.Encriptar(Program.chave, Program.chaveVetor, "infinito");      
        public static string sdataAtual = crypt.Encriptar(Program.chave, Program.chaveVetor, "dataAtual");
        public static string sdataLim = crypt.Encriptar(Program.chave, Program.chaveVetor, "dataLimite");
        public static bool registrado = false;
        //public static OEE.OEE oee;
        public static VTX.VTX vt;
        public static ModbusClient dxm;        
        public static Store.Store banco;
        public static bool dxmChange = false;
        public static bool dxmINIcia = true;
        public static string _pathContentRoot;
        public static Mapa mapa;
        public static string turnoAtual = "";
        public static bool loging = false;

        public static void Main(string[] args)
        {

            mapa = new Mapa("base", "base.mapa");

            /*
            banco = new Store.Store();            
            JavaScriptSerializer ser = new JavaScriptSerializer();
            VTX.VTX foo = ser.Deserialize<VTX.VTX>(banco.Fabrica);

            vt = new VTX.VTX(foo.quantidade,foo.motores,foo.DXM_Endress,foo.tickLog);
            if (vt.DXM_Tcp) { dxm = new ModbusClient(vt.DXM_Endress, 502); }
            else { dxm = new ModbusClient(vt.DXM_Endress); }                  

            ThreadStart start = new ThreadStart(leituraDXM);
            Thread acao = new Thread(start);
            ThreadStart log = new ThreadStart(DXMLog);
            Thread acao2 = new Thread(log);
            ThreadStart log2 = new ThreadStart(poolRegistro);
            Thread acao3 = new Thread(log2);

            acao3.Start();
            acao.Start();
            acao2.Start();

            Thread.Sleep(1000);
            if (!registrado) { urlString = "http://localhost:5001"; }
            mapa.alteraQtdLinhas(vt.motores.Count);

            */

            var pathToExec = Process.GetCurrentProcess().MainModule.FileName;
            _pathContentRoot = Path.GetDirectoryName(pathToExec);

            CreateWebHostBuilder(args).Build().RunAsCustomService();
            //CreateWebHostBuilder(args).Build().Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls(urlString)
            .UseContentRoot(_pathContentRoot)
            .UseSockets()            
                .UseStartup<Startup>();       
           
        

        public static void leituraDXM()
        {

            int linhas = vt.quantidade;
            bool falha = false;            
            while (!falha)
            {
                linhas = vt.quantidade;
                bool dxm_ok = false;
                try
                {
                    if (dxmINIcia) {
                        //oee.normaliza(); // revifica se a variavel quantidade e linhas tem o mesmo valor.
                        if (!dxm.Connected)
                        {
                            if (vt.DXM_Tcp) { dxm = new ModbusClient(vt.DXM_Endress, 502); }
                            else { dxm = new ModbusClient(vt.DXM_Endress); }
                            dxm.ConnectionTimeout = 3000;
                            dxm.Connect();
                        } 
                        /*
                        int[] emu =new int[1];
                        int[] li =new int[1];
                        int[] vel =new int[1];
                        int[] t_p_prog =new int[1];
                        for (int x = 0; x < oee.quantidade; x++)
                        {
                            if (x == 0) {
                                emu[0] = oee.emulador;
                                li[0] = oee.quantidade;
                                dxm.WriteMultipleRegisters(88, emu);
                                dxm.WriteMultipleRegisters(89, li);
                            }
                            vel[0] = oee.Linhas[x].vel_esp;
                            t_p_prog[0] = oee.Linhas[x].t_p_prog;
                            dxm.WriteMultipleRegisters(107+(x*13), vel);
                            dxm.WriteMultipleRegisters(110 + (x * 13), t_p_prog);

                        } 
                        */
                        dxmINIcia = false;
                        Thread.Sleep(3000);
                    }
                    else { 
                    for (int x = 0; x < linhas; x++)
                    {
                        if (!dxm.Connected)
                        {
                            if (vt.DXM_Tcp) { dxm = new ModbusClient(vt.DXM_Endress, 502); }
                            else { dxm = new ModbusClient(vt.DXM_Endress); }                            
                            dxm.ConnectionTimeout = 3000;
                            dxm.Connect();
                        }
                        int linha = dxm.ReadHoldingRegisters(849, 1)[0];
                        if (linha == 0) { linha = 1; }
                        if (linha > 0) { vt.alteraLinhas(linha);}                       
                        vt.motores[x].readAovivo(dxm.ReadHoldingRegisters(25 + x * 16, 16));
                        dxm_ok = true;
                    }
                    }
                }
                catch {
                  
                    if (vt.DXM_Tcp) { dxm = new ModbusClient(vt.DXM_Endress, 502); }
                    else { dxm = new ModbusClient(vt.DXM_Endress); }                    
                    Thread.Sleep(3000);
                    dxmINIcia = true;
                }
               
                if (dxm_ok) { vt.DXM_insertOnLine(); }
                else { vt.DXM_insertFalha(); }
                Thread.Sleep(1000);
            }

        }

        public static void DXMLog()
        {
            int contador = 0;
            while (true) {
                long hora = DateTime.Now.ToFileTime();
                int linhas = vt.quantidade;
                int comparador = vt.tickLog + 60;
                contador++;
                
                if (contador > comparador && dxm.Connected)
                {
                    ///* 
                    loging = true;
                    try
                    {
                        DXM_Procotolo dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                        if (dxm_api.FileExist("Sbfile1.dat"))
                        {
                            dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                            string tempStr = "";
                            string tempStr2 = "";
                            List<string> temp = new List<string>();
                            List<string> temp2 = new List<string>();
                            dxm_api.destravar();                            
                            dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                            temp2 = dxm_api.getFile("LogFile1.txt");
                            Thread.Sleep(200);
                            dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                            temp = dxm_api.getFile("Sbfile1.dat");
                            try { 
                            if (temp[0] == "") { }
                            else
                            {
                                for (int x = 0; x < temp2.Count; x++)
                                {
                                    tempStr2 = tempStr2 + temp2[x];
                                }
                                for (int x = 0; x < temp.Count; x++)
                                {
                                    tempStr = tempStr + temp[x];
                                }
                                vt.flush();
                                banco.exec_log(tempStr, vt.quantidade,tempStr2);
                                dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                                dxm_api.deleteFile("Sbfile1.dat");
                                Thread.Sleep(200);
                                dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                                dxm_api.deleteFile("LogFile1.txt");
                                Thread.Sleep(1000);
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex);                               
                            }
                           
                            dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                            dxm_api.travar();
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex);                       
                    }
                    
                    /*        
                    contador = 0;
                    for (int z = 0; z < linhas; z++)
                    {
                        try
                        {
                            if (!vt.motores[z].Estado.Contains("DXM")) {
                                vt.flush();
                                banco.exec_log(vt.motores[z]);
                            }
                        }
                        catch { }
                    }
                    */
                    banco.set_fabrica(JsonConvert.SerializeObject(vt));
                    contador = 0;
                }
                else { loging = false; }
                Thread.Sleep(1000);
                  
                }
            }

        public static void registro()
        {
            try
            {
                //verifica integrigade do reistro               
                
                string atual = crypt.Encriptar(Program.chave, Program.chaveVetor, DateTime.Now.Date.ToShortDateString());
                string dataIni = (string)Registry.GetValue(pasta, sdataAtual, "not exist.");
                string datafim = (string)Registry.GetValue(pasta, sdataLim, "not exist.");
                string indefinido = (string)Registry.GetValue(pasta, sInf, "not exist.");

                DateTime d_ini = Convert.ToDateTime(crypt.Decriptar(chave, chaveVetor, dataIni));
                DateTime d_fim = Convert.ToDateTime(crypt.Decriptar(chave, chaveVetor, datafim));
                bool inf = Convert.ToBoolean(crypt.Decriptar(chave, chaveVetor, indefinido));

                user = (string)Registry.GetValue(pasta, "usuario", "indefinido");

                if (inf)
                {
                    registrado = true;
                    regTipo = "Versão Completa";
                }
                else if (d_ini.Date > DateTime.Now.Date)
                {
                    registrado = false;
                    regTipo = "Versão Básica";
                    Registry.SetValue(pasta, sdataAtual,"falha");
                    Registry.SetValue(pasta, sdataLim, "falha");
                    Registry.SetValue(pasta, sInf, "falha");
                }
                else if (DateTime.Now.Date > d_fim.Date)
                {
                    registrado = false;
                    regTipo = "Versão Básica";
                    Registry.SetValue(pasta, sdataAtual, "falha");
                    Registry.SetValue(pasta, sdataLim, "falha");
                    Registry.SetValue(pasta, sInf, "falha");
                }
                
                else
                {
                    Registry.SetValue(pasta, sdataAtual, atual);
                    registrado = true;
                    regTipo = "Vencimento " + d_fim.Date.ToShortDateString();
                    
                }

            }
            catch
            { registrado = false; }
            
        }

        public static void poolRegistro()
        {
            while (true)
            {
                registro();
                Thread.Sleep(300000);
            }
        }



    }

     
    
}

