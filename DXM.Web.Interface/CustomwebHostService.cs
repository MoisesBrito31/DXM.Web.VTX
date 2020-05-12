using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using EasyModbus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace DXM.Web.Interface
{
    public class CustomwebHostService : WebHostService
    {
        public CustomwebHostService(IWebHost host) : base(host) { }

        protected override void OnStarting(string[] args)
        {
            Program.banco = new Store.Store();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            VTX.VTX foo = ser.Deserialize<VTX.VTX>(Program.banco.Fabrica);

            Program.vt = new VTX.VTX(foo.quantidade, foo.motores, foo.DXM_Endress,foo.tickLog);
            if (Program.vt.DXM_Tcp) { Program.dxm = new ModbusClient(Program.vt.DXM_Endress, 502); }
            else { Program.dxm = new ModbusClient(Program.vt.DXM_Endress); }

            ThreadStart start = new ThreadStart(Program.leituraDXM);
            Thread acao = new Thread(start);
            ThreadStart log = new ThreadStart(Program.DXMLog);
            Thread acao2 = new Thread(log);
            ThreadStart log2 = new ThreadStart(Program.poolRegistro);
            Thread acao3 = new Thread(log2);

            acao3.Start();
            acao.Start();
            acao2.Start();

            Thread.Sleep(1000);
            if (!Program.registrado) { Program.urlString = "http://localhost:5001"; }
            Program.mapa.alteraQtdLinhas(Program.vt.motores.Count);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            base.OnStopping();
        }

    }
}
