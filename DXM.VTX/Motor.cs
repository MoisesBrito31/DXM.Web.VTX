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
            V_Rms_Vel_X =  (float)values[0]/1000;
            V_Pico_Vel_X = values[1];
            V_Rms_Vel_Z = (float)values[2]/1000;
            V_Pico_Vel_Z = values[3];
            Temperatura = (float)values[4]/20;
            alert_tempe = (float)values[5]/20;
            alert_v_Rms_Vel_X = (float)values[6]/1000;
            alert_v_Rms_Vel_Z = (float)values[7]/1000;
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
                    string temp = Convert.ToString(historico[x].V_Rms_Vel_X);
                    temp.Replace(",", ".");
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", temp);
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", temp);
                    }
                }
            }
            else
            {
                for (int x = 0; x < histFiltro.Count; x++)
                {
                    StringBuilder temp = new StringBuilder(Convert.ToString(histFiltro[x].V_Rms_Vel_X));
                    temp.Replace(',', '.');
                   
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", temp.ToString());
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", temp.ToString());
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
                    StringBuilder temp = new StringBuilder(histFiltro[x].alert_v_Rms_Vel_X.ToString());
                    temp.Replace(',', '.');
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}",temp.ToString() );
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", temp.ToString());
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
                    StringBuilder temp = new StringBuilder(histFiltro[x].V_Rms_Vel_Z.ToString());
                    temp.Replace(',', '.');
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", temp.ToString());
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", temp.ToString());
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
                    StringBuilder temp = new StringBuilder(histFiltro[x].alert_v_Rms_Vel_Z.ToString());
                    temp.Replace(',', '.');
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", temp.ToString());
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", temp.ToString());
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
                    StringBuilder temp = new StringBuilder(histFiltro[x].temperatura.ToString());
                    temp.Replace(',', '.');
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", temp.ToString());
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", temp.ToString());
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
                    StringBuilder temp = new StringBuilder(histFiltro[x].alert_tempe.ToString());
                    temp.Replace(',', '.');
                    if (x == historico.Count - 1)
                    {
                        ret = ret + string.Format("{0}", temp.ToString());
                    }
                    else
                    {
                        ret = ret + string.Format("{0},", temp.ToString());
                    }
                }
            }

            return ret;
        }
    }
}
