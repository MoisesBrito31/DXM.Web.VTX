using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using DXM.Web.Interface.Models;


namespace DXM.Web.Interface.Controllers
{
    public class licencaController : Controller
    {

        public IActionResult Index()
        {
            
            ViewBag.user = Program.user;
            return View();
        }
        [HttpPost]
        public ActionResult registrar(string serial, string user)
        {
            
            //DESCRIPT:
            string valor = crypt.Decriptar(Program.chave, Program.chaveVetor, serial);
            bool falha = false;
            //verifica se é vitalicio:

            if (valor.Contains("indeterminado"))
            {
                DateTime d = DateTime.Now;

                string sInfBool = crypt.Encriptar(Program.chave, Program.chaveVetor, "true");
                string atual = crypt.Encriptar(Program.chave, Program.chaveVetor, DateTime.Now.Date.ToShortDateString());
                string limite = crypt.Encriptar(Program.chave, Program.chaveVetor, d.ToShortDateString());
                Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", Program.sdataAtual, atual);
                Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", Program.sdataLim, limite);
                Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", Program.sInf, sInfBool);
                Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", "usuario", user);
                Program.registro();
                return RedirectToAction("Index", "config");
            }
            else
            {

                try
                {
                    DateTime d = Convert.ToDateTime(valor);
                    string sInfBool = crypt.Encriptar(Program.chave, Program.chaveVetor, "false");
                    string atual = crypt.Encriptar(Program.chave, Program.chaveVetor, DateTime.Now.Date.ToShortDateString());
                    string limite = crypt.Encriptar(Program.chave, Program.chaveVetor, d.ToShortDateString());
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", Program.sdataAtual, atual);
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", Program.sdataLim, limite);
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", Program.sInf, sInfBool);
                    Registry.SetValue("HKEY_CURRENT_USER\\DXM_Web", "usuario", user);
                    Program.registro();
                    return RedirectToAction("Index", "config");
                }
                catch (Exception ex)
                {
                    string f = ex.Message;
                    falha = true;

                }
                byte[] b = Encoding.UTF8.GetBytes("Index?valor=" + falha);
                
                return RedirectToAction("index", "licenca");
            }



        }


    }
   
}