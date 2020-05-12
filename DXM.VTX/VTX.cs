using System;
using System.Collections.Generic;
using System.Text;

namespace DXM.VTX
{
    public class VTX
    {

        public List<Motor> motores { get; set; } = new List<Motor>();
        public int quantidade { get; set; } = 0;
        public string DXM_Status { get; set; } = "";
        public string DXM_Endress { get; set; } = "192.168.0.4";
        public bool DXM_Tcp { get; set; } = true;
        public int emulador { get; set; } = 0;
        public int tickLog { get; set; } = 30;

        
        //
        public VTX() { }

        public VTX(int _linhas, List<Motor> vts, string _endereco, int _tickLog)
        {
            motores = vts;
            quantidade = _linhas;
            DXM_Endress = _endereco;            

            if (_tickLog == 0) { _tickLog = 60; }

            tickLog = _tickLog;

            if (_endereco.Contains("COM") || _endereco.Contains("com")) { DXM_Tcp = false; }
            else { DXM_Tcp = true; }

        }

        public void DXM_insertFalha()
        {
            DXM_Status = "DXM OffLine";
        }
        public void DXM_insertOnLine()
        {
            DXM_Status = "DXM Online";
        }

        public void flush()
        {
            for (int x = 0; x < motores.Count; x++)
            {
                motores[x].histFiltro = new List<VT_hist>();
                motores[x].historico = new List<VT_hist>();
            }
        }

        public void alteraLinhas(int quant)
        {
            if (quant == 0) { quant = 1; }

            int result = quant - quantidade;
            if (result > 0)
            {
                for (int x = 0; x < result; x++)
                {
                    Motor m = new Motor();
                    m.nome = string.Format("Motor {0}", x + quantidade + 1);
                    m.id = x + quantidade;
                    motores.Add(m);
                }

            }
            if (result < 0)
            {

                for (int x = motores.Count - 1; x >= quant; x--)
                {
                    motores.RemoveAt(x);
                }
            }
            quantidade = motores.Count;

        }
    }
}
