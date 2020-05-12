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
        public int comando { get; set; }

        //leituras
        public float V_Rms_Vel_X{ get; set; }
        public float V_Pico_Vel_X{ get; set; }
        public float V_Rms_Vel_Z { get; set; }
        public float V_Pico_Vel_Z { get; set; }
        public int V_Pico_HighFreq_X { get; set; }

        public float V_Rms_Acc_X { get; set; }
        public float V_Pico_Acc_X { get; set; }
        public float V_Rms_Acc_Z { get; set; }
        public float V_Pico_Acc_Z { get; set; }
        public int V_Pico_HighFreq_Z { get; set; }

        public float Temperatura { get; set; }

        // limites (falhas)

        public float alert_tempe { get; set; }
        public float alert_v_Rms_Vel_X { get; set; }
        public float alert_v_Rms_Vel_Z { get; set; }


        //historicos
        public List<VT_hist> historico { get; set; } = new List<VT_hist>();
        public List<VT_hist> histFiltro { get; set; } = new List<VT_hist>();

        public DateTime filtro_Ini { get; set; }
        public DateTime filtro_fim { get; set; }

        //construtor
        public Motor() { }

        public void readAovivo(int[] values)
        {
            V_Rms_Vel_X = values[0];
            V_Pico_Vel_X = values[1];
            V_Rms_Vel_Z = values[2];
            V_Pico_Vel_Z = values[3];
            Temperatura = values[4];
            alert_tempe = values[5];
            alert_v_Rms_Vel_X = values[6];
            alert_v_Rms_Vel_Z = values[7];
            switch (values[8])
            {
                case 0:
                    Estado = "OffLine";
                    break;
                case 1:
                    Estado = "OK";
                    break;
                case 2:
                    Estado = "Falha";
                    break;
                case 3:
                    Estado = "Alerta";
                    break;
                case 4:
                    Estado = "Aprendendo";
                    break;
                default:
                    Estado = "desconhecido";
                    break;
            }
            
        }


        public string get_log_time(bool filtro)
        {
            string ret = "";
            if (!filtro)
            {
                for (int x = 0; x < historico.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("\'{0} {1}\'", historico[x].time.ToShortDateString(), historico[x].time.ToShortTimeString());
                    }
                    else
                    {
                        ret = ret + string.Format("\'{0} {1}\',", historico[x].time.ToShortDateString(), historico[x].time.ToShortTimeString());
                    }
                }
            }
            else
            {
                for (int x = 0; x < histFiltro.Count; x++)
                {
                    if (x == histFiltro.Count - 1)
                    {
                        ret = ret + string.Format("\'{0} {1}\'", histFiltro[x].time.ToShortDateString(), histFiltro[x].time.ToShortTimeString());
                    }
                    else
                    {
                        ret = ret + string.Format("\'{0} {1}\',", histFiltro[x].time.ToShortDateString(), histFiltro[x].time.ToShortTimeString());
                    }
                }
            }
            return ret;

        }

        public string get_log_vx(bool filtro)
        {
            string ret = "";
            if (!filtro)
            {
                for (int x = 0; x < historico.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", historico[x].V_Rms_Vel_X);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", historico[x].V_Rms_Vel_X);
                    }
                }
            }
            else
            {
                for (int x = 0; x < histFiltro.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", histFiltro[x].V_Rms_Vel_X);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", histFiltro[x].V_Rms_Vel_X);
                    }
                }
            }

            return ret;
        }
        public string get_log_a_vx(bool filtro)
        {
            string ret = "";
            if (!filtro)
            {
                for (int x = 0; x < historico.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", historico[x].alert_v_Rms_Vel_X);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", historico[x].alert_v_Rms_Vel_X);
                    }
                }
            }
            else
            {
                for (int x = 0; x < histFiltro.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", histFiltro[x].alert_v_Rms_Vel_X);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", histFiltro[x].alert_v_Rms_Vel_X);
                    }
                }
            }

            return ret;
        }
        public string get_log_vz(bool filtro)
        {
            string ret = "";
            if (!filtro)
            {
                for (int x = 0; x < historico.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", historico[x].V_Rms_Vel_Z);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", historico[x].V_Rms_Vel_Z);
                    }
                }
            }
            else
            {
                for (int x = 0; x < histFiltro.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", histFiltro[x].V_Rms_Vel_Z);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", histFiltro[x].V_Rms_Vel_Z);
                    }
                }
            }

            return ret;
        }
        public string get_log_a_vz(bool filtro)
        {
            string ret = "";
            if (!filtro)
            {
                for (int x = 0; x < historico.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", historico[x].alert_v_Rms_Vel_Z);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", historico[x].alert_v_Rms_Vel_Z);
                    }
                }
            }
            else
            {
                for (int x = 0; x < histFiltro.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", histFiltro[x].alert_v_Rms_Vel_Z);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", histFiltro[x].alert_v_Rms_Vel_Z);
                    }
                }
            }

            return ret;
        }
        public string get_log_temp(bool filtro)
        {
            string ret = "";
            if (!filtro)
            {
                for (int x = 0; x < historico.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", historico[x].temperatura);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", historico[x].temperatura);
                    }
                }
            }
            else
            {
                for (int x = 0; x < histFiltro.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", histFiltro[x].temperatura);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", histFiltro[x].temperatura);
                    }
                }
            }

            return ret;
        }
        public string get_log_a_temp(bool filtro)
        {
            string ret = "";
            if (!filtro)
            {
                for (int x = 0; x < historico.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", historico[x].alert_tempe);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", historico[x].alert_tempe);
                    }
                }
            }
            else
            {
                for (int x = 0; x < histFiltro.Count; x++)
                {
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", histFiltro[x].alert_tempe);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", histFiltro[x].alert_tempe);
                    }
                }
            }

            return ret;
        }
    }
}
