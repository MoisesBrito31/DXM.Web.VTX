using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DXM.OEE;
using System.IO;
using System.Text;
using EasyModbus;
using System.Threading;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using DXM.Protocolo;

namespace DXM.Web.Interface.Controllers
{
    
    public class oeeController : Controller
    {
        
        public IActionResult Index()
        {

            //if (!Program.registrado) { return RedirectToAction("index","licenca"); }
            ViewBag.registrado = Program.registrado;
            if (Program.oee.DXM_Status.Contains("Online"))
            {
                ViewBag.turnoAtual = Program.turnoAtual;
                return View(Program.oee);
            }
            else
            {
                return RedirectToAction("offline");
            }
        }
      
        public ActionResult linha(int id)
        {
            
            //if (!Program.registrado) { return RedirectToAction("index", "licenca"); }
            Linha l = Program.oee.Linhas[id];
            return View(l);
        }
       
        public ActionResult historico(int id)
        {

            //if (!Program.registrado) { return RedirectToAction("index", "licenca"); }
            ViewBag.registrado = Program.registrado;
            string S_ini = string.Format("{0} 00:00:00",DateTime.Now.Date.ToShortDateString());
            string S_fim = string.Format("{0} 23:59:00", DateTime.Now.Date.ToShortDateString());
            DateTime ini = Convert.ToDateTime(S_ini);
            DateTime fim = Convert.ToDateTime(S_fim);
            Linha l = Program.oee.Linhas[id];
            l.histFiltro = Program.banco.get_linha_hist(id, ini, fim);
            l.filtro_Ini = ini;
            l.filtro_fim = fim;
            l.filtro_fim = fim; l.filtro_fim = fim; return View(l);
        }

        [HttpPost]      
        public ActionResult historicoFiltro(int id,DateTime ini,DateTime fim)
        {

            //if (!Program.registrado) { return RedirectToAction("licenca"); }
            ViewBag.registrado = Program.registrado;
            Linha l = Program.oee.Linhas[id];
            l.histFiltro = Program.banco.get_linha_hist(id,ini,fim);
            l.filtro_Ini = ini;
            l.filtro_fim = fim;
            return View(l);
        }
        
        public ActionResult offline()
        {
            
            ViewBag.ip = Program.oee.DXM_Endress;
            return View();
        }

        [HttpGet]
        public string conjunto_linhas()
        {
            //if (!Program.registrado) { return "falha"; }
            string ret = "";
            for (int x = 0; x < Program.oee.Linhas.Count; x++)
            {
                if (x == Program.oee.Linhas.Count - 1) {
                    ret = ret + "{" + string.Format("\"nome\":\"{0}\",\"oee\":{1},\"estado\":\"{2}\"", Program.oee.Linhas[x].nome, Program.oee.Linhas[x].oee,
                        Program.oee.Linhas[x].Estado) + "}";
                }
                else
                {
                    ret = ret + "{" + string.Format("\"nome\":\"{0}\",\"oee\":{1},\"estado\":\"{2}\"", Program.oee.Linhas[x].nome, Program.oee.Linhas[x].oee,
                           Program.oee.Linhas[x].Estado) + "},";
                }
            }

            ret = string.Format("[{0}]", ret);
            return ret;
        }

        [HttpGet]
        public string getTurno()
        {
            if (!Program.registrado) { return "falha"; }
            try
            {
                 return Program.turnoAtual; 
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        public string get_linha(int id)
        {
            //if (!Program.registrado) { return "falha"; }
            string ret = "";
            try
            {
                Linha l = Program.oee.Linhas[id];

                ret = string.Format("\"nome\":\"{0}\",\"estado\":\"{1}\",\"oee\":{2}," +
                    "\"dis\":{3},\"q\":{4},\"per\":{5}," +
                    "\"t_prod\":{6},\"t_par\":{7},\"t_p_prog\":{8}," +
                    "\"cont_in\":{9},\"cont_out\":{10},\"vel_atu\":{11}," +
                    "\"vel_esp\":{12}", l.nome, l.Estado, l.oee.ToString(),
                    l.dis.ToString(), l.q.ToString(), l.per.ToString(),
                    l.t_prod.ToString(), l.t_par.ToString(), l.t_p_prog.ToString(), l.cont_in.ToString(),
                    l.cont_out.ToString(), l.vel_atu.ToString(),
                    l.vel_esp.ToString());
                ret = "{" + ret + "}";
            }
            catch { }
          
            return ret;
        }

        [HttpGet]
        public string push(int id)
        {
            if (!Program.registrado) { return "falha"; }
            Program.oee.Linhas[id].exect_log();
            return Program.oee.Linhas[id].get_log_oee(false);
        }

        [HttpGet]
        public FileResult relatorio(int id, DateTime ini, DateTime fim)
        {
            //if (!Program.registrado) { return File(new byte[2], "", ""); }
            Linha l = Program.oee.Linhas[id];
            l.histFiltro = Program.banco.get_linha_hist(id, ini, fim);
            l.filtro_Ini = ini;
            l.filtro_fim = fim;
            
            string dados = string.Format("{0};iniciada em :;{1}; terminado em :; {2}\r\n",l.nome,l.filtro_Ini.ToString(),l.filtro_fim.ToString());
            dados = dados + string.Format("hora;OEE;Disponibilidade;Qualidade;Preformance;Rodando;Parado;Produzido;ruins/bons;velocidade\r\n");
            for(int x=0;x<l.histFiltro.Count;x++)
            {
                dados = dados + string.Format("{0};{1}%;{2}%;{3}%;{4}%;{5}:{10};{6}:{11};{7};{8};{9}p/m\r\n", l.histFiltro[x].time.ToString(),l.histFiltro[x].oee,
                    l.histFiltro[x].dis, l.histFiltro[x].q, l.histFiltro[x].per,
                    (int)l.histFiltro[x].t_prod/60, (int)l.histFiltro[x].t_par/60, l.histFiltro[x].ruins_total, l.histFiltro[x].bons, l.histFiltro[x].vel_atu,
                    (int)l.histFiltro[x].t_prod % 60, (int)l.histFiltro[x].t_par % 60);
            }

            Stream stream = new MemoryStream();
            byte[] bite = Encoding.UTF8.GetBytes(dados);
            stream.Write(bite, 0, bite.Length);

            DateTime d = DateTime.Now.Date;
            return File(bite, "text/csv", string.Format("relatorio-{0}-{1}-{2}-{3}.csv",l.nome,d.Day,d.Month,d.Year));
        }

        [HttpGet]
        public string set_vel_esp(int id, int valor)
        {
            //if (!Program.registrado) { return "falha"; }
            string ret = "";
            int[] reg = new int[1];
            reg[0] = valor;
            try
            {
                if (!Program.dxm.Connected)
                {
                    if (Program.oee.DXM_Tcp) { Program.dxm = new ModbusClient(Program.oee.DXM_Endress, 502); }
                    else { Program.dxm = new ModbusClient((Program.oee.DXM_Endress)); }
                    Program.dxm.ConnectionTimeout = 3000;
                    Program.dxm.Connect();
                }               
                Program.dxm.WriteMultipleRegisters(107 + (id * 13), reg);
                Program.oee.Linhas[id].vel_esp = valor;
                Program.oee.flush();
                Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.oee));
                Script script = new Script(Program.oee.Linhas, Program.oee.tickLog);
                script.salvaArquivo();
                ret = "ok";
            }
            catch(Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
       
        [HttpGet]
        public string set_t_p_prog(int id,int valor)
        {
            //if (!Program.registrado) { return "falha"; }
            string ret = "";
            int[] reg = new int[1];
            reg[0] = valor;
            try
            {
                if (!Program.dxm.Connected)
                {
                    if (Program.oee.DXM_Tcp) { Program.dxm = new ModbusClient(Program.oee.DXM_Endress, 502); }
                    else { Program.dxm = new ModbusClient((Program.oee.DXM_Endress)); }
                    Program.dxm.ConnectionTimeout = 3000;
                    Program.dxm.Connect();
                }
                Program.dxm.WriteMultipleRegisters(110 + (id * 13), reg);
                Program.oee.Linhas[id].t_p_prog = valor;
                Program.oee.flush();
                Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.oee));
                Script script = new Script(Program.oee.Linhas, Program.oee.tickLog);
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
        public string set_forma(int id, int valor)
        {
            //if (!Program.registrado) { return "falha"; }
            string ret = "";
            int[] reg = new int[1];
            reg[0] = valor;
            try
            {
                if (!Program.dxm.Connected)
                {
                    if (Program.oee.DXM_Tcp) { Program.dxm = new ModbusClient(Program.oee.DXM_Endress, 502); }
                    else { Program.dxm = new ModbusClient((Program.oee.DXM_Endress)); }
                    Program.dxm.ConnectionTimeout = 3000;
                    Program.dxm.Connect();
                }
                Program.dxm.WriteMultipleRegisters(109 + (id * 13), reg);
                Program.oee.Linhas[id].forma = valor;
                Program.oee.flush();
                Program.banco.set_fabrica(JsonConvert.SerializeObject(Program.oee));
                Script script = new Script(Program.oee.Linhas, Program.oee.tickLog);
                script.salvaArquivo();
                ret = "ok";
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }

    }
}