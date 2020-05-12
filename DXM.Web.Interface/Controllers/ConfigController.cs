using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyModbus;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DXM.Protocolo;

namespace DXM.Web.Interface.Controllers
{
    public class ConfigController : Controller
    {
        private string pasta = string.Format(@"{0}\wwwroot\script\",Program._pathContentRoot);
        private DXM_Procotolo dxm = new DXM_Procotolo(Program.dxm.IPAddress);
        private bool sucesso = false;
        public IActionResult Index()
        {            
            ViewBag.sucesso = sucesso;
            //if (!Program.registrado) { return RedirectToAction("index", "licenca"); }
            return View(Program.vt);
        }
        public IActionResult DxmConfig()
        {
            dxm = new DXM_Procotolo(Program.dxm.IPAddress);
            //if (!Program.registrado) { return RedirectToAction("index", "licenca"); }
            return View();
        }
        public IActionResult mapIO()
        {
            dxm = new DXM_Procotolo(Program.dxm.IPAddress);
           // if (!Program.registrado) { return RedirectToAction("index", "licenca"); }            
            return View(Program.mapa);
        }
        public IActionResult reset()
        {            
            return View();
        }
        public IActionResult turno()
        {            
            dxm = new DXM_Procotolo(Program.dxm.IPAddress);
            if (!Program.registrado) { return RedirectToAction("index", "licenca"); }            
            return View(Program.mapa.turnos);
        }

        /*
        public string setLinhaNome(int id, string valor, int t_p_p, string forma, int vel_esp)
        {
            //if (!Program.registrado) { r/eturn "falha"; }
            int[] reg = new int[1];
            int[] reg2 = new int[1];
            int[] reg3 = new int[1];
            reg[0] = t_p_p;
            reg2[0] = Convert.ToInt32(forma);
            reg3[0] = vel_esp;
            try {

                if (!Program.dxm.Connected)
                {
                    if (Program.oee.DXM_Tcp) { Program.dxm = new ModbusClient(Program.vt.DXM_Endress, 502); }
                    else { Program.dxm = new ModbusClient((Program.vt.DXM_Endress)); }
                    Program.dxm.ConnectionTimeout = 3000;
                    Program.dxm.Connect();
                }
            Program.vt.motores[id].nome = valor;
            Program.mapa.alteraNomeMotores(Program.vt);
            Program.dxm.WriteMultipleRegisters(110 + (id * 13), reg);
            Program.dxm.WriteMultipleRegisters(109 + (id * 13), reg2);
            Program.dxm.WriteMultipleRegisters(107 + (id * 13), reg3);
            Program.oee.Linhas[id].t_p_prog = reg[0];
            Program.oee.Linhas[id].forma = reg2[0];
            Program.oee.Linhas[id].vel_esp = reg3[0];
            Program.oee.flush();
            Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.oee));
            Script script = new Script(Program.oee.Linhas, Program.oee.tickLog);
            script.salvaArquivo();
            return "ok";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        */

        public string setTurno(int id, string nome, string hora)
        {
            if (!Program.registrado) { return "falha"; }
            try
            {
                DateTime data = Convert.ToDateTime(hora);
                Program.mapa.turnos[id] = new Evento(nome, data);
                Program.mapa.salvaArquivo(Program.mapa);                
                Xml xml = new Xml(Program.mapa);
                if (xml.salvaArquivo()) { return "ok"; }
                else { return "falha"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string addTurno(string nome, string hora)
        {
            if (!Program.registrado) { return "falha"; }
            try
            {
                DateTime data = Convert.ToDateTime(hora);               
                Program.mapa.turnos.Add(new Evento(Program.mapa.turnos.Count,nome, data));
                Program.mapa.salvaArquivo(Program.mapa);               
                Xml xml = new Xml(Program.mapa);
                if (xml.salvaArquivo()) { return "ok"; }
                else { return "falha"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string deleteTurno(int id)
        {
            if (!Program.registrado) { return "falha"; }
            try
            {
                Program.mapa.turnos.RemoveAt(id);
                Program.mapa.salvaArquivo(Program.mapa);                
                Xml xml = new Xml(Program.mapa);
                if (xml.salvaArquivo()) { return "ok"; }
                else { return "falha"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /*
        public string zerarLinha(int id)
        {
            //if (!Program.registrado) { return "falha"; }
            try
            {
                if (!Program.dxm.Connected)
                {
                    if (Program.oee.DXM_Tcp) { Program.dxm = new ModbusClient(Program.oee.DXM_Endress, 502); }
                    else { Program.dxm = new ModbusClient((Program.oee.DXM_Endress)); }
                    Program.dxm.ConnectionTimeout = 3000;
                    Program.dxm.Connect();
                }
                int[] wri = new int[1];
                wri[0] = 1;
                Program.dxm.WriteMultipleRegisters(108 + (id * 13), wri);
                //Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.oee));
                Thread.Sleep(2000);
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        */
        [HttpPost]
        public string setXml(string json)
        {
           
            //if (!Program.registrado) { return "falha"; }
            try
            {
                Mapa novo = new Mapa();
                novo = JsonConvert.DeserializeObject<Mapa>(json);
                Program.mapa = novo;  
                novo.salvaArquivo(novo);
                Xml xml = new Xml(novo);
                if (xml.salvaArquivo()){return "ok";}
                else { return "falha"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string setIp(string ip)
        {
           // if (!Program.registrado) { return "falha"; }
            try
            {
                Program.vt.DXM_Endress = ip;
                Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.vt));
                Program.dxm.Disconnect();
                Thread.Sleep(5000);
                Program.vt.flush();
                Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.vt));
                return "ok";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

       
        [HttpGet]
        public string setLinhas(int valor)
        {
            //if (!Program.registrado) { return "falha"; }
            string ret = "";
            int[] reg = new int[1];
            reg[0] = valor;
            try
            {
                if (!Program.dxm.Connected)
                {
                    if (Program.vt.DXM_Tcp) { Program.dxm = new ModbusClient(Program.vt.DXM_Endress, 502); }
                    else { Program.dxm = new ModbusClient((Program.vt.DXM_Endress)); }
                    Program.dxm.ConnectionTimeout = 3000;
                    Program.dxm.Connect();
                }
                Program.dxm.WriteMultipleRegisters(849, reg);
                Thread.Sleep(1000);                
                Program.vt.alteraLinhas(valor);
                Program.mapa.alteraQtdLinhas(valor);
                Program.vt.flush();               
                Thread.Sleep(500);
                Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.vt));
                Script script = new Script(Program.vt.motores, Program.vt.tickLog);
                script.salvaArquivo();
                ret = "ok";
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            Thread.Sleep(1000);           
            return ret;
        }

        public string salvaScript()
        {
           // if (!Program.registrado) { return "falha"; }
            string ret = "";
           
            try
            {
                Script script = new Script(Program.vt.motores,Program.vt.tickLog);
                script.salvaArquivo();
                ret = "ok";
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            Thread.Sleep(1000);
            return ret;
        }

        [HttpGet]
        public string setTickLog(int valor)
        {
            //if (!Program.registrado) { return "falha"; }
            string ret = "";
            int[] reg = new int[1];
            reg[0] = valor;
            try
            {
               
                Program.vt.tickLog = valor;               
                Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.vt));
                Script script = new Script(Program.vt.motores, Program.vt.tickLog);
                script.salvaArquivo();
                ret = "ok";
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }           
           
            return ret;
        }

        [HttpGet]
        public FileResult download(string arquivo)
        {
            if (!Program.registrado) { return File(new byte[2], "", ""); }
            byte[] bite = new byte[1];
            string arq = "";
            string n = "";
            switch (arquivo)
            {
                case "xml":
                    arq = string.Format("{0}\\wwwroot\\script\\{1}", Program._pathContentRoot, "DXM_OEE.xml");
                    n = "DXM_OEE.xml";
                    break;
                case "sb":
                    arq = string.Format("{0}\\wwwroot\\script\\{1}", Program._pathContentRoot, "OEE.sb");
                    n = "OEE.sb";
                    break;
            }
            
            try
            {
                StreamReader rd = new StreamReader(arq);
                bite = Encoding.UTF8.GetBytes(rd.ReadToEnd());
                rd.Close();               
            }
            catch (Exception ex) {
                bite = Encoding.UTF8.GetBytes(ex.Message);
                n = "falha.txt";
            }

            DateTime d = DateTime.Now.Date;
            return File(bite, "text/txt",n);
        }

        // dxm configuração processo:
        [HttpGet]
        public string getEstado()
        {
           // if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "destrado";                
                if (dxm.verificaTrava()) { ret = "travado"; }
                return ret;
            }
            catch (Exception ex){return ex.Message;}            
        }

        public string getRelogio()
        {
            //if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "falha";
                ret = dxm.getRelogio().ToString();
                return ret;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string setRelogio()
        {
            if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "falha";
                ret = dxm.setRelogio();
                return ret;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string travar()
        {
            //if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "falha";               
                if (dxm.travar()) { ret = "ok"; }
                return ret;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string destravar()
        {
            //if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "falha";               
                if (dxm.destravar()) { ret = "ok"; }
                return ret;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string sendScript()
        {
           // if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "falha";
                string arquivo = "OEE.sb";                
                if (dxm.EnviaArquivo(arquivo,pasta)) { ret = "ok"; }
                return ret;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string sendXml()
        {
           // if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "falha";
                string arquivo = "DXM_OEE.xml";                
                if (dxm.EnviaArquivo(arquivo, pasta)) { 
                    sucesso = true; 
                    ret = "ok"; 
                }
                return ret;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string exist(string file)
        {
            //if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "falha"; 
                if (dxm.FileExist(file)) { ret = "ok"; }
                return ret;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string fileDelete(string file)
        {
            //if (!Program.registrado) { return "falha"; }
            try
            {
                string ret = "falha";
                if (dxm.deleteFile(file)) { ret = "ok"; }
                return ret;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public FileResult fileDownload(string file)
        {
            if (!Program.registrado) { }
            try
            {
                string tempStr = "";
                List<string> temp = new List<string>();
                Stream stream = new MemoryStream();
                byte[] bite;


                temp = dxm.getFile(file);
                if (temp[0] == "") {  }
                else
                {
                    for (int x = 0; x < temp.Count; x++)
                    {
                        tempStr = tempStr + temp[x];
                    }
                }
                bite = Encoding.UTF8.GetBytes(tempStr);
                stream.Write(bite, 0, bite.Length);
                return File(bite, "text/dat", file);
            }
            catch (Exception ex) { return File(Encoding.UTF8.GetBytes(ex.Message), "text/dat", "falha.dat");}
        }

        public string baixaLog()
        {
            string ret = "falha";
            if (Program.dxm.Connected)
            {
                try
                {
                    Program.loging = true;
                    DXM_Procotolo dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                    if (dxm_api.FileExist("Sbfile1.dat"))
                    {
                        dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                        string tempStr = "";
                        string tempStr2 = "";
                        List<string> temp = new List<string>();
                        List<string> temp2 = new List<string>();
                        temp2 = dxm_api.getFile("LogFile1.txt");
                        Thread.Sleep(200);
                        dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                        temp = dxm_api.getFile("Sbfile1.dat");
                        try
                        {
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
                                Program.vt.flush();
                                Program.banco.exec_log(tempStr, Program.vt.quantidade, tempStr2);
                                dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                                dxm_api.deleteFile("Sbfile1.dat");
                                Thread.Sleep(200);
                                dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                                dxm_api.deleteFile("LogFile1.txt");
                                ret = "ok";
                            }
                        }
                        catch
                        {
                            ret = "falha - não foi possivel baixar o log, execute um diagnóstico e tente novamente";
                            dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                            dxm_api.travar();
                        }
                    }
                }
                catch
                {
                    ret = "falha - não foi possivel baixar o log, execute um diagnóstico e tente novamente";
                }
            }
            Program.loging = false;
            return ret;
        }

        public string forceLoging()
        {
            string ret = "falha";
            if (Program.dxm.Connected) { 
            try
            {
                Program.loging = true;
                DXM_Procotolo dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                if (dxm_api.FileExist("Sbfile1.dat"))
                {
                    Program.loging = true;
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
                    try
                    {
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
                            Program.vt.flush();
                            Program.banco.exec_log(tempStr, Program.vt.quantidade, tempStr2);
                            dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                            dxm_api.deleteFile("Sbfile1.dat");
                            Thread.Sleep(200);
                            dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                            dxm_api.deleteFile("LogFile1.txt");
                            Thread.Sleep(200);
                            ret = "ok";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    dxm_api = new DXM_Procotolo(Program.dxm.IPAddress);
                    dxm_api.travar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Program.loging = false;
            }
            return ret;            
        }

        public string Online()
        {
            
            string ret = "False";

            if (Program.dxm.Connected) { ret = "{\"dxmOnline\": true,"; }
            else { ret = "{\"dxmOnline\": false,"; }
            if (Program.loging) { ret = ret+"\"loging\": true}"; }
            else { ret = ret + "\"loging\": false}"; }
            return ret;
           
        }

    }
}