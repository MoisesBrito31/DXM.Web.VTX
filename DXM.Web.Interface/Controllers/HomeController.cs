using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DXM.Web.Interface.Models;

namespace DXM.Web.Interface.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            
            ViewData["Message"] = "Your application description page.";
            ViewBag.user = Program.user;
            ViewBag.reg = Program.regTipo;
            return View();
        }

    }
}
