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
using System.Collections.Generic;

namespace DXM.Web.Interface
{
    public class Program
    {
        public static string urlString = "http://*:5001;http://localhost:5001";
        public static string user = "indefinido";
        public static string regTipo = "Versão Básica";
        public static string chave = "P3DI43NF4SV8D4FA";
        public static string chaveVetor = "E94NFGU4N5M47NA3";
        public static string sInf = crypt.Encriptar(Program.chave, Program.chaveVetor, "infinito");      
        public static string sdataAtual = crypt.Encriptar(Program.chave, Program.chaveVetor, "dataAtual");
        public static string sdataLim = crypt.Encriptar(Program.chave, Program.chaveVetor, "dataLimite");
        public static bool registrado = false;
        public static OEE.OEE oee;
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

            //*
            banco = new Store.Store();            
            JavaScriptSerializer ser = new JavaScriptSerializer();
            OEE.OEE foo = ser.Deserialize<OEE.OEE>(banco.Fabrica);

            oee = new OEE.OEE(foo.quantidade,foo.Linhas,foo.DXM_Endress,foo.emulador,foo.tickLog);
            if (oee.DXM_Tcp) { dxm = new ModbusClient(oee.DXM_Endress, 502); }
            else { dxm = new ModbusClient(oee.DXM_Endress); }                  

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
            mapa.alteraQtdLinhas(oee.Linhas.Count);

            //*/

            var pathToExec = Process.GetCurrentProcess().MainModule.FileName;
            _pathContentRoot = Path.GetDirectoryName(pathToExec);

            //CreateWebHostBuilder(args).Build().RunAsCustomService();
            CreateWebHostBuilder(args).Build().Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls(urlString)
            //.UseContentRoot(_pathContentRoot)
            .UseSockets()            
                .UseStartup<Startup>();       
           
        

        public static void leituraDXM()
        {

            int linhas = oee.quantidade;
            bool falha = false;            
            while (!falha)
            {
                linhas = oee.quantidade;
                bool dxm_ok = false;
                try
                {
                    if (dxmINIcia) {
                        //oee.normaliza(); // revifica se a variavel quantidade e linhas tem o mesmo valor.
                        if (!dxm.Connected)
                        {
                            if (oee.DXM_Tcp) { dxm = new ModbusClient(oee.DXM_Endress, 502); }
                            else { dxm = new ModbusClient(oee.DXM_Endress); }
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
                            if (oee.DXM_Tcp) { dxm = new ModbusClient(oee.DXM_Endress, 502); }
                            else { dxm = new ModbusClient(oee.DXM_Endress); }                            
                            dxm.ConnectionTimeout = 3000;
                            dxm.Connect();
                        }
                        int linha = dxm.ReadHoldingRegisters(89, 1)[0];
                        if (linha > 0) { oee.alteraLinhas(linha); }
                        oee.emulador=dxm.ReadHoldingRegisters(88,1)[0];
                        oee.Linhas[x].insert_dinamics(dxm.ReadHoldingRegisters(0 + x * 5, 5));
                        oee.Linhas[x].insert_calculadas(dxm.ReadHoldingRegisters(100 + x * 13, 13));                       
                        dxm_ok = true;
                    }
                    }
                }
                catch {
                  
                    if (oee.DXM_Tcp) { dxm = new ModbusClient(oee.DXM_Endress, 502); }
                    else { dxm = new ModbusClient(oee.DXM_Endress); }                    
                    Thread.Sleep(3000);
                    dxmINIcia = true;
                }
               
                if (dxm_ok) { oee.DXM_insertOnLine(); }
                else { oee.DXM_insertFalha(); }
                Thread.Sleep(1000);
            }

        }

        public static void DXMLog()
        {
            int contador = 0;
            while (true) {
                long hora = DateTime.Now.ToFileTime();
                int linhas = oee.quantidade;
                int comparador = oee.tickLog + 60;
                contador++;
                
                if (contador > comparador && dxm.Connected)
                {
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
                                oee.flush();
                                banco.exec_log(tempStr, oee.quantidade,tempStr2);
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
                            if (!oee.Linhas[z].Estado.Contains("DXM")) {
                                oee.flush();
                                //banco.exec_log(oee.Linhas[z]);
                            }
                        }
                        catch { }
                    }
                    */
                    banco.set_fabrica(JsonConvert.SerializeObject(oee));
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
                string dataIni = (string)Registry.GetValue("HKEY_CURRENT_USER\\DXM_Web", sdataAtual, "not exist.");
                string datafim = (string)Registry.GetValue("HKEY_CURRENT_USER\\DXM_Web", sdataLim, "not exist.");
                string indefinido = (string)Registry.GetValue("HKEY_CURRENT_USER\\DXM_Web", sInf, "not exist.");

                DateTime d_ini = Convert.ToDateTime(crypt.Decriptar(chave, chaveVetor, dataIni));
                DateTime d_fim = Convert.ToDateTime(crypt.Decriptar(chave, chaveVetor, datafim));
                bool inf = Convert.ToBoolean(crypt.Decriptar(chave, chaveVetor, indefinido));

                user = (string)Registry.GetValue("HKEY_CURRENT_USER\\DXM_Web", "usuario", "indefinido");

                if (inf)
                {
                    registrado = true;
                    regTipo = "Versão Completa";
                }
                else if (d_ini.Date > DateTime.Now.Date)
                {
                    registrado = false;
                    regTipo = "Versão Básica";
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", sdataAtual,"falha");
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", sdataLim, "falha");
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web",sInf, "falha");
                }
                else if (DateTime.Now.Date > d_fim.Date)
                {
                    registrado = false;
                    regTipo = "Versão Básica";
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", sdataAtual, "falha");
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", sdataLim, "falha");
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", sInf, "falha");
                }
                
                else
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", sdataAtual, atual);
                    registrado = true;
                    regTipo = "vencimento " + d_fim.Date.ToShortDateString();
                    
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

