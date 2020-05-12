using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using System.Web.Script.Serialization;
using DXM.VTX;

namespace DXM.Store
{
    public class Store
    {
        public string pasta { get; set; } = string.Format("{0}store\\",AppContext.BaseDirectory);
        public string Fabrica { get; set; }
        public bool linhaDisp { get; set; } = true;
        public string servicePorta { get; set; } = "";
        public bool serviceStartUp { get; set; } = false;
        

        public Store()
        {
            Directory.CreateDirectory(pasta);
            bool existe = File.Exists(pasta + "fabrica.data");
            bool serviceCongi = File.Exists(pasta + "service.data");
            
            if (!existe){
                string json = "{\"motores\":[{\"id\":0,\"nome\":\"motor 1\",\"Estado\":null,\"comando\":0,\"V_Rms_Vel_X\":0,\"V_Pico_Vel_X\":0,\"V_Rms_Vel_Z\":0,\"V_Pico_Vel_Z\":0,\"V_Pico_HighFreq_X\":0,\"V_Rms_Acc_X\":0,\"V_Pico_Acc_X\":0,\"V_Rms_Acc_Z\":0,\"V_Pico_Acc_Z\":0,\"V_Pico_HighFreq_Z\":0,\"Temperatura\":0,\"alert_tempe\":100,\"alert_v_Rms_Vel_X\":1000,\"alert_v_Rms_Vel_Z\":1000,\"historico\":[],\"histFiltro\":[],\"filtro_Ini\":\"\\/Date(-62135589600000)\\/\",\"filtro_fim\":\"\\/Date(-62135589600000)\\/\"}],\"quantidade\":0,\"DXM_Status\":\"\",\"DXM_Endress\":\"192.168.0.4\",\"DXM_Tcp\":true,\"emulador\":0,\"tickLog\":30}";
                StreamWriter wr = new StreamWriter(pasta + "fabrica.data");
                wr.WriteLine(json);
                wr.Close();
                Fabrica = json;
            }
            else{
                StreamReader rd = new StreamReader(pasta + "fabrica.data");
                Fabrica = rd.ReadLine();
                rd.Close();
            }

            if (!serviceCongi)
            {                
                StreamWriter wr = new StreamWriter(pasta + "service.data");
                wr.WriteLine("5001");
                wr.WriteLine("true");
                wr.Close();
                servicePorta = "5001";
                serviceStartUp = true;
            }
            else
            {
                StreamReader rd = new StreamReader(pasta + "service.data");
                servicePorta = rd.ReadLine();
                serviceStartUp = Convert.ToBoolean(rd.ReadLine());
                rd.Close();
            }
           
        }

        public void gravaService(string Porta,bool startup)
        {
            StreamWriter wr = new StreamWriter(pasta + "service.data");
            wr.WriteLine(Porta);
            wr.WriteLine(startup);
            wr.Close();
        }
        public bool set_fabrica(string dado)
        {
            bool ret = false;
            try
            {
                StreamWriter wr = new StreamWriter(pasta + "fabrica.data");
                wr.WriteLine(dado);
                wr.Close();
                ret = true;
                Fabrica = dado;
            }
            catch { }
            return ret;
        }

        #region OEE Service

        public bool exec_log(Motor l)
        {
            bool ret = false;
            int cont = 0;
            List<VT_hist> hist = new List<VT_hist>();
            while (!linhaDisp) { if (cont > 100000) { return ret; } }
            linhaDisp = false;

            List<string> buffer = new List<string>();
            try
            {
                if (File.Exists(pasta + l.id + ".data"))
                {
                    StreamReader rd = new StreamReader(pasta + l.id + ".data");
                    while (!rd.EndOfStream)
                    {
                        buffer.Add(rd.ReadLine());
                    }
                    rd.Close();
                    rd.Dispose();
                }
                else {}
               
            }
            catch { }
                
            try
            {
                VT_hist h = new VT_hist(l.id,l.V_Rms_Vel_X,l.V_Rms_Vel_Z,l.Temperatura,l.alert_v_Rms_Vel_X,l.alert_v_Rms_Vel_Z,l.alert_tempe,l.Estado);
                buffer.Add(JsonConvert.SerializeObject(h));
                StreamWriter wr = new StreamWriter(pasta + l.id + ".data");
                for (int x = 0; x < buffer.Count; x++)
                { 
                    wr.WriteLine(buffer[x]);
                }
                wr.Close();
                wr.Dispose();
                buffer.Clear();
                ret = true;
            }
            catch(Exception ex) { string m=ex.Message; }

            linhaDisp = true;
            return ret;
        }

        private bool exec_log_hist(Motor l)
        {
            bool ret = false;
            int cont = 0;            
            while (!linhaDisp) { if (cont > 100000) { return ret; } }
            linhaDisp = false;

            List<string> buffer = new List<string>();
            try
            {
                if (File.Exists(pasta + l.id + ".data"))
                {
                    StreamReader rd = new StreamReader(pasta + l.id + ".data");
                    while (!rd.EndOfStream)
                    {
                        buffer.Add(rd.ReadLine());
                    }
                    rd.Close();
                    rd.Dispose();
                }
                else { }

            }
            catch { }

            try
            {
               for(int x = 0; x < l.historico.Count; x++)
                {
                    buffer.Add(JsonConvert.SerializeObject(l.historico[x]));
                }                
                StreamWriter wr = new StreamWriter(pasta + l.id + ".data");
                for (int x = 0; x < buffer.Count; x++)
                {
                    wr.WriteLine(buffer[x]);
                }
                wr.Close();
                wr.Dispose();
                buffer.Clear();
                ret = true;
            }
            catch (Exception ex) { string m = ex.Message; }

            linhaDisp = true;
            return ret;
        }
        public bool exec_log(string dados,int linhas, string dadosTime)
        {
            bool ret = false;
            string trat = dadosTime.Substring(20, dadosTime.Length - 20);
            string[] arreyTime = trat.Split('\r');
            for(int x = 0; x < arreyTime.Length-1; x++)
            {
                try { 
                arreyTime[x] = arreyTime[x].Substring(1, arreyTime[x].IndexOf(',')-1);
                }
                catch { }
            }
            string[] arrey = dados.Split('\r');
            List<VT_hist> conjunto = new List<VT_hist>();
            List<Motor> fabrica = new List<Motor>();
            for(int x = 0; x < 32; x++)
            {
                fabrica.Add(new Motor());
                fabrica[x].id = x;
            }

            for(int x = 0; x < arrey.Length; x++)
            {
                if (arrey[x].Length > 20)
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    conjunto.Add(ser.Deserialize<VT_hist>(arrey[x]));                    
                    fabrica[conjunto[x].id].historico.Add(conjunto[x]);
                }
            }

            for(int x = 0; x < fabrica.Count; x++)
            {
                for (int y = 0; y < fabrica[x].historico.Count; y++)
                {                    
                    fabrica[x].historico[y].time = Convert.ToDateTime(arreyTime[y]);
                }
            }

            for (int x = 0; x < 32; x++)
            {
                if (fabrica[x].historico.Count > 0)
                {
                    exec_log_hist(fabrica[x]);
                }
            }

            return ret;
        }

        public List<VT_hist> get_linha_hist(int id)
        {
            int cont = 0;
            List<VT_hist> hist = new List<VT_hist>();
            while (!linhaDisp) { if (cont > 100000) { return hist; } }
            linhaDisp = false;
            try
            {
                string jon = "";
                StreamReader rd = new StreamReader(pasta + id + ".data");
                while (!rd.EndOfStream)
                {
                    jon = rd.ReadLine();
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    hist.Add(ser.Deserialize<VT_hist>(jon));
                }
                rd.Close();
            }
            catch { }
            
            linhaDisp = true;
            return hist;
        }
        public List<VT_hist> get_linha_hist(int id, DateTime ini, DateTime fim)
        {
            int cont = 0;
            List<VT_hist> hist = new List<VT_hist>();
            while (!linhaDisp) { if (cont > 100000) { return hist; } }          
            linhaDisp = false;
            try
            {
                string jon = "";
                StreamReader rd = new StreamReader(pasta + id + ".data");
                while (!rd.EndOfStream)
                {
                    jon = rd.ReadLine();
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    VT_hist h = ser.Deserialize<VT_hist>(jon);
                    if(h.time>=ini && h.time <= fim) { hist.Add(h); }                    
                }
                rd.Close();
            }
            catch { }
            linhaDisp = true;
            return hist;
        }
        #endregion

        #region VT-service
        #endregion
    }
}
