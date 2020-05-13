using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXM.VTX;
using Microsoft.AspNetCore.Mvc;

namespace DXM.Web.Interface.Controllers
{
    public class vtController : Controller
    {
        public IActionResult Index()
        {
            //if (!Program.registrado) { return RedirectToAction("index","licenca"); }
            ViewBag.registrado = Program.registrado;
            if (Program.vt.DXM_Status.Contains("Online"))
            {               
                return View(Program.vt);
            }
            else
            {
                return RedirectToAction("offline");
            }
        }

        public ActionResult historico(int id)
        {

            //if (!Program.registrado) { return RedirectToAction("index", "licenca"); }
            ViewBag.registrado = Program.registrado;
            string S_ini = string.Format("{0} 00:00:00", DateTime.Now.Date.ToShortDateString());
            string S_fim = string.Format("{0} 23:59:00", DateTime.Now.Date.ToShortDateString());
            DateTime ini = Convert.ToDateTime(S_ini);
            DateTime fim = Convert.ToDateTime(S_fim);
            Motor l = Program.vt.motores[id];
            l.histFiltro = Program.banco.get_linha_hist(id, ini, fim);
            l.filtro_Ini = ini;
            l.filtro_fim = fim;
            l.filtro_fim = fim; l.filtro_fim = fim; return View(l);
        }
        public ActionResult historicoFiltro(int id, DateTime ini, DateTime fim)
        {

            //if (!Program.registrado) { return RedirectToAction("licenca"); }
            ViewBag.registrado = Program.registrado;
            Motor l = Program.vt.motores[id];
            l.histFiltro = Program.banco.get_linha_hist(id, ini, fim);
            l.filtro_Ini = ini;
            l.filtro_fim = fim;
            return View(l);
        }

        public ActionResult offline()
        {

            ViewBag.ip = Program.vt.DXM_Endress;
            return View();
        }


        [HttpGet]
        public FileResult relatorio(int id, DateTime ini, DateTime fim)
        {
            //if (!Program.registrado) { return File(new byte[2], "", ""); }
            Motor l = Program.vt.motores[id];
            l.histFiltro = Program.banco.get_linha_hist(id, ini, fim);
            l.filtro_Ini = ini;
            l.filtro_fim = fim;

            string dados = string.Format("{0};iniciada em :;{1}; terminado em :; {2}\r\n", l.nome, l.filtro_Ini.ToString(), l.filtro_fim.ToString());
            dados = dados + string.Format("hora;Eixo X;Alerta Eixo X;Eixo Z;Alerta Eixo Z;Temperatura;Alerta Temperatura;Estado\r\n");
            for (int x = 0; x < l.histFiltro.Count; x++)
            {
                dados = dados + string.Format("{0};{1} mm/s;{2} mm/s;{3} mm/s;{4} mm/s;{5} C;{6} C;{7}\r\n", l.histFiltro[x].time.ToString(), l.histFiltro[x].V_Rms_Vel_X,
                    l.histFiltro[x].alert_v_Rms_Vel_X, l.histFiltro[x].V_Rms_Vel_Z, l.histFiltro[x].alert_v_Rms_Vel_Z,
                    l.histFiltro[x].temperatura, l.histFiltro[x].alert_tempe, l.histFiltro[x].Estado);
            }

            Stream stream = new MemoryStream();
            byte[] bite = Encoding.UTF8.GetBytes(dados);
            stream.Write(bite, 0, bite.Length);

            DateTime d = DateTime.Now.Date;
            return File(bite, "text/csv", string.Format("relatorio-{0}-{1}-{2}-{3}.csv", l.nome, d.Day, d.Month, d.Year));
        }

        public string getDados()
        {
            string ret = "{";
            ret = string.Format("{0}\"dxm\":\"{1}\",\"motores\":[",ret,Program.vt.DXM_Status);
            for(int x = 0; x < Program.vt.motores.Count; x++)
            {
                ret += "{";
                ret = string.Format("{0}\"id\":{1},\"nome\":\"{2}\",\"vx\":\"{3}\",\"vz\":\"{4}\",\"temp\":\"{5}\",\"estado\":\"{6}\"", ret, Program.vt.motores[x].id, Program.vt.motores[x].nome, 
                    Program.vt.motores[x].V_Rms_Vel_X, Program.vt.motores[x].V_Rms_Vel_Z, Program.vt.motores[x].Temperatura,
                    Program.vt.motores[x].Estado);
                ret += "},";
            }
            ret = ret.Substring(0, ret.Length - 1);
            ret += "]}";
            return ret;
        }
    }
}