using System;
using System.Collections.Generic;
using System.Text;

namespace DXM.VTX
{
    public class Motor 
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string Estado { get; set; }

        //leituras
        public float V_Rms_Vel_X{ get; set; }
        public float V_Pico_Vel_X{ get; set; }
        public int V_Pico_HighFreq_X { get; set; }

        public float V_Rms_Acc_Z { get; set; }
        public float V_Pico_Acc_Z { get; set; }
        public int V_Pico_HighFreq_Z { get; set; }

        public float Temperatura { get; set; }

        // limites (falhas)

        public float alert_tempe { get; set; }
        public float alert_v_Rms_Vel_X { get; set; }
        public float alert_v_Rms_Vel_Z { get; set; }


        //historicos
        public List<Hist> historico { get; set; } = new List<Hist>();
        public List<Hist> histFiltro { get; set; } = new List<Hist>();

        public DateTime filtro_Ini { get; set; }
        public DateTime filtro_fim { get; set; }

        //construtor
        public Motor() { }

        public void readAovivo(int[] values)
        {

        }
    }
}
