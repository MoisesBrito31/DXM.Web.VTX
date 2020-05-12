using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXM.OEE;
using DXM.VTX;
using Microsoft.AspNetCore.Mvc;

namespace DXM.Web.Interface.Controllers
{
    public class relatorioController : Controller
    {
        public IActionResult Index()
        {
            if(!Program.registrado) { return RedirectToAction("index", "licenca"); }
            List<string> l = new List<string>();
            for(int x = 0; x < Program.vt.motores.Count; x++)
            {
                l.Add(Program.vt.motores[x].nome);
            }
            ViewBag.Linhas = l;
            return View();
        }
        /*
        public string getDados(string _color, int linha, DateTime ini, DateTime fim, int index)
        {
            string ret = "falha";
            string cor = "#" + _color;
            string nome = "abc";
            string date = "";

            Motor l = Program.vt.motores[linha];
            l.histFiltro = Program.banco.get_linha_hist(linha, ini, fim);
            l.historico = l.histFiltro;
            nome = l.nome;

            switch (index)
            {
                case 0:
                    for(int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].oee+",";
                    }
                    nome = nome + "-OEE";
                    break;
                case 1:
                    for (int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].dis + ",";
                    }
                    nome = nome + "-Dis";
                    break;
                case 2:
                    for (int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].q + ",";
                    }
                    nome = nome + "-Qua";
                    break;
                case 3:
                    for (int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].per + ",";
                    }
                    nome = nome + "-Per";
                    break;
                case 4:
                    for (int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].t_prod + ",";
                    }
                    nome = nome + "-Rod";
                    break;
                case 5:
                    for (int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].t_par + ",";
                    }
                    nome = nome + "-Par";
                    break;                   
                case 6:
                    for (int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].ruins_total + ",";
                    }
                    nome = nome + "-Pro";
                    break;
                case 7:                    
                    for (int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].bons + ",";
                    }
                    
                    nome = nome + "-ru/bon";
                    break;
                case 8:
                    for (int x = 0; x < l.histFiltro.Count; x++)
                    {
                        date = date + l.histFiltro[x].vel_atu + ",";
                    }
                    nome = nome + "-Vel";
                    break;
            }
            date = date.Substring(0, date.Length - 1);
            ret = string.Format("\"label\":\"{0}\", \"fill\":false ,\"backgroundColor\":\"{1}\", \"borderColor\":\"{2}\" ,\"data\":[{3}]",
                nome,cor,cor,date);
            ret = "{ " + ret + " }";
            return ret;
        }
        */
    }
}