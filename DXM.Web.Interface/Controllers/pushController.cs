using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXM.Web.Interface.Models;
using Microsoft.AspNetCore.Mvc;
using DXM.OEE;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using DXM.Protocolo;

namespace DXM.Web.Interface.Controllers
{
    public class pushController : Controller
    {
        public List<string> colecao = new List<string>();
        public IActionResult Index()
        {
            
            return View();
        }

        public string xml()
        {
            DXM_Procotolo dxm = new DXM_Procotolo(Program.dxm.IPAddress);
            string dir = string.Format(@"{0}wwwroot\script\", AppContext.BaseDirectory);            
            return Convert.ToString(dxm.EnviaArquivo("DXM_OEE.xml", dir));
        }
        public string OEE()
        {
            DXM_Procotolo dxm = new DXM_Procotolo(Program.dxm.IPAddress);
            string dir = string.Format(@"{0}wwwroot\script\", AppContext.BaseDirectory);
            return Convert.ToString(dxm.EnviaArquivo("OEE.sb", dir));
        }

        public string trava()
        {
            DXM_Procotolo dxm = new DXM_Procotolo(Program.dxm.IPAddress);            
            return Convert.ToString(dxm.travar());
        }
        public string destrava()
        {
            DXM_Procotolo dxm = new DXM_Procotolo(Program.dxm.IPAddress);
            return Convert.ToString(dxm.destravar());
        }
        public string delete()
        {
            DXM_Procotolo dxm = new DXM_Procotolo(Program.dxm.IPAddress);
            return Convert.ToString(dxm.deleteFile("OEE.sb"));
        }
        public string check()
        {
            string ret = "";
            DXM_Procotolo dxm = new DXM_Procotolo(Program.dxm.IPAddress);
            if (dxm.verificaTrava()) { ret = "Travado"; }
            else { ret = "destravado"; }
            return Convert.ToString(ret);
        }
    }
}