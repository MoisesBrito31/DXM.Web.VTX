using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;

namespace DXM.Protocolo
{
    public class DXM_Procotolo
    {
        public IPAddress DxmIp { get; set; }
        public IPEndPoint Dxm { get; set; }
        public int porta { get; set; }
        private Socket transmision {get;set;}
        private byte[] bytes { get; set; } = new byte[1024];
        private int resposta { get; set; }
        public DXM_Procotolo() { }
        public DXM_Procotolo(string _dxmIp)
        {
            porta = 8844;
            try
            {
                DxmIp = IPAddress.Parse(_dxmIp);
            }
            catch { DxmIp = IPAddress.Parse("192.168.0.1"); }

            Dxm = new IPEndPoint(DxmIp, porta);

            transmision = new Socket(DxmIp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);



        }
        public string getMac(){return comandoSimples("CMD0112",false);  }
        public DateTime getRelogio()
        {
            DateTime ret = Convert.ToDateTime("00:00:00");           
            try
            {
                transmision.Connect(Dxm);
                byte[] msg = Encoding.ASCII.GetBytes("CMD0102");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                string temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                string temp2 = temp.Substring(7, temp.Length - 7);
                ret = Convert.ToDateTime(temp2);
                TimeSpan fuso = new TimeSpan(3, 0, 0);
                ret = ret - fuso;
                transmision.Disconnect(true);
                transmision.Close();
                return ret;
            }
            catch {   }
            return ret;
        }
        public string setRelogio()
        {
            string ok = "falha";
            DateTime ret = DateTime.Now;
            try
            {
                TimeSpan fuso = new TimeSpan(3, 0, 0);
                ret = ret + fuso;
                transmision.Connect(Dxm);
                string msgStr = string.Format("CMD0101{0},{1},{2},{3},{4},{5}", ret.Year, ret.Month, ret.Day, ret.Hour, ret.Minute, ret.Second);
                byte[] msg = Encoding.ASCII.GetBytes(msgStr);
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                string temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if(temp== "RSP0101") { ok = "ok"; }
                
                transmision.Disconnect(true);
                transmision.Close();
                return ok;
            }
            catch { }
            return ok;
        }
        public string getSerialNumber(){return comandoSimples("CMD0113",false);}
        public bool reset() { return comandoSemRetorno("CMD0200"); }
        public bool rebot() { return comandoSemRetorno("CMD020055S"); }
        public bool EnviaArquivo(string nomeArquivo, string path)
        {            
            byte[] msg;
            string temp = "";
            try
            {
                List<string> colecao = estruturaArquivo(nomeArquivo, path);
                transmision.Connect(Dxm);

                msg = Encoding.ASCII.GetBytes("CMD1003");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP1003")
                {
                    return false;
                }

                msg = Encoding.ASCII.GetBytes(colecao[0]);
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP1001OK")
                {
                    return false;
                }

                for (int x = 1; x < colecao.Count; x++)
                {
                    msg = Encoding.ASCII.GetBytes(colecao[x]);
                    transmision.Send(msg);
                    resposta = transmision.Receive(bytes);
                    temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                    if (temp != "RSP1002")
                    {
                        return false;
                    }
                }

                msg = Encoding.ASCII.GetBytes("CMD1003");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP1003")
                {
                    return false;
                }

                if (nomeArquivo.Contains(".xml"))
                {
                    msg = Encoding.ASCII.GetBytes("CMD020055S");
                    transmision.Send(msg);
                    Thread.Sleep(500);
                }            

                transmision.Disconnect(true);
                transmision.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool travar()
        {
                    byte[] msg;
                    string temp = "";
                    try
                    {                        
                        transmision.Connect(Dxm);

                        msg = Encoding.ASCII.GetBytes("CMD0449");
                        transmision.Send(msg);
                        resposta = transmision.Receive(bytes);
                        temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                        if (temp != "RSP04490")
                        {
                    transmision.Disconnect(true);
                    transmision.Close();
                    return false;
                        }

                        msg = Encoding.ASCII.GetBytes("CMD045055YmV0aW01MTY=");
                        transmision.Send(msg);
                        resposta = transmision.Receive(bytes);
                        temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                        if (temp != "RSP0450")
                        {
                    transmision.Disconnect(true);
                    transmision.Close();
                    return false;
                        }

                        //msg = Encoding.ASCII.GetBytes("CMD020055S");
                        //transmision.Send(msg);
                        //Thread.Sleep(500);

                        transmision.Disconnect(true);
                        transmision.Close();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
        public bool destravar()
        {
            byte[] msg;
            string temp = "";
            try
            {
                transmision.Connect(Dxm);

                msg = Encoding.ASCII.GetBytes("CMD0449");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP04491")
                {
                    transmision.Disconnect(true);
                    transmision.Close();
                    return false;
                }

                msg = Encoding.ASCII.GetBytes("CMD0451YmV0aW01MTY=");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP0451")
                {
                    transmision.Disconnect(true);
                    transmision.Close();
                    return false;
                }

                msg = Encoding.ASCII.GetBytes("CMD0452");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP0452")
                {
                    transmision.Disconnect(true);
                    transmision.Close();
                    return false;
                }

                //msg = Encoding.ASCII.GetBytes("CMD020055S");
                //transmision.Send(msg);
                //Thread.Sleep(500);

                transmision.Disconnect(true);
                transmision.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool verificaTrava()
        {
            byte[] msg;
            string temp = "";
            try
            {
               
                transmision.Connect(Dxm);
                msg = Encoding.ASCII.GetBytes("CMD0449");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP04491")
                {
                    return false;
                }
                transmision.Disconnect(true);
                transmision.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteFile(string Nome)
        {
            return comandoSemRetorno(string.Format("CMD1006 {0}", Nome));
        }
        public bool FileExist(string Nome)
        {
            if (comandoSimples(string.Format("CMD1005 {0}", Nome), true) == "51") { return true; }
            else { return false; }
        }
        public List<string> getFile(string nome)
        {
            List<string> ret = new List<string>();
            byte[] msg;
            string temp = "";
            try
            {                
                transmision.Connect(Dxm);

                msg = Encoding.ASCII.GetBytes("CMD1003");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP1003")
                {
                    return ret;
                }

                msg = Encoding.ASCII.GetBytes(string.Format("CMD1001/{0},0,0,1",nome));
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (!temp.Contains("RSP1001"))
                {
                    return ret;
                }
                int index = 1;
                string auxiliar = "";
                while (temp!= "RSP10020,ffff,EOF")
                {
                    msg = Encoding.ASCII.GetBytes(string.Format("CMD1002{0}",index));
                    transmision.Send(msg);
                    resposta = transmision.Receive(bytes);
                    temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                    if (temp != "RSP10020,ffff,EOF")
                    {
                        auxiliar = tratamentoString(temp);
                        if (auxiliar != "falha")
                        {
                            ret.Add(auxiliar);
                            index++;
                        }
                        else { return new List<string>(); }
                    }
                }

                msg = Encoding.ASCII.GetBytes("CMD1003");
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (temp != "RSP1003")
                {
                    return ret;
                }
                transmision.Disconnect(true);
                transmision.Close();
                return tratamentoFinal(ret);
            }
            catch
            {
                return new List<string>();
            }            
        }
        private string comandoSimples(string cmd, bool format)
        {
            string ret = "falha";
            try
            {
                transmision.Connect(Dxm);
                byte[] msg = Encoding.ASCII.GetBytes(cmd);
                transmision.Send(msg);
                resposta = transmision.Receive(bytes);
                string temp = Encoding.ASCII.GetString(bytes, 0, resposta);
                if (format) { ret = temp.Substring(6, temp.Length - 6); }
                else { ret = temp; }
                transmision.Disconnect(true);
                transmision.Close();
                return ret;
            }
            catch(Exception ex)
            {
                return ret + " " + ex.Message;
            }
        }
        private bool comandoSemRetorno(string cmd)
        {
            try
            {
                transmision.Connect(Dxm);
                byte[] msg = Encoding.ASCII.GetBytes(cmd);
                transmision.Send(msg);               
                transmision.Disconnect(true);
                transmision.Close();                
            }
            catch
            {
                return false;
            }
            return true;
        }
        private List<string> estruturaArquivo(string nomeArquivo,string path)
        {
            List<string> colecao = new List<string>();           
            bool existe = System.IO.File.Exists(path+nomeArquivo);
            colecao = new List<string>();
            char[] buffer = new char[512];

            if (existe)
            {
                try
                {
                    StreamReader rd = new StreamReader(path + nomeArquivo);
                    string tempStr = "";
                    string leitura = rd.ReadToEnd();
                    rd.Close();
                    int tamnaho = leitura.Length;
                    int loops = tamnaho / 512;
                    int resto = tamnaho % 512;
                    buffer = new char[tamnaho];

                    //cabeçalio:
                    if (nomeArquivo.Contains(".xml")) { nomeArquivo = "WLConfig.xml"; }
                    colecao.Add(string.Format("CMD1001{0},1,{1},0", nomeArquivo,Convert.ToString(tamnaho)));

                    for (int x = 0; x < tamnaho; x++)
                    {
                        buffer[x] = Convert.ToChar(leitura.Substring(x, 1));
                        if (buffer[x] == '\r') { buffer[x] = ''; }
                        if (buffer[x] == '\n') { buffer[x] = ''; }
                    }


                    for (int y = 0; y < loops; y++)
                    {
                        for (int x = 0; x < 512; x++)
                        {
                            if (buffer[x + (y * 512)] != '\0') { tempStr = string.Format("{0}{1}", tempStr, buffer[x + (y * 512)]); }
                        }
                        colecao.Add(tempStr);
                        tempStr = "";
                    }

                    for (int x = 0; x < resto; x++)
                    {
                        if (buffer[x + (loops * 512)] != '\0') { tempStr = string.Format("{0}{1}", tempStr, buffer[x + (loops * 512)]); }
                    }
                    colecao.Add(tempStr);
                    tempStr = "";

                    for (int x = 1; x < colecao.Count; x++)
                    {
                        string crcReal = Crc(colecao[x]);
                        colecao[x] = string.Format("CMD1002{0},{1},{2},{3}", colecao[x].Length, crcReal, x, colecao[x]);
                    }
                    tempStr = "";

                }
                catch (Exception ex)
                {
                    string i = ex.Message;
                }
            }

            return colecao;
        }
        private string tratamentoString(string rcp)
        {
            try
            {
                string temp = "";
                string dados = "";
                string crc = "";
                string crcIdeal = "";
                int index = rcp.IndexOf(',');
                temp = rcp.Substring(index + 1, rcp.Length - (index + 1));
                index = temp.IndexOf(',');
                crc = temp.Substring(0, index);
                dados = temp.Substring(index + 1, temp.Length - (index + 1));
                crcIdeal = Crc(dados);
                if (crcIdeal.ToUpper() == crc.ToUpper()) { return dados; }
                else { return "falha"; }
            }
            catch { 
                return"falha"; 
            }
        }
        private List<string> tratamentoFinal(List<string> dados)
        {
            List<string> temp = new List<string>();
            string tempStg = "";
            for (int y = 0; y < dados.Count; y++)
            {
                char[] arrayChar = new char[dados[y].Length];
                tempStg = "";
                for (int x = 0; x < dados[y].Length; x++)
                {
                    arrayChar[x] = Convert.ToChar(dados[y].Substring(x, 1));
                    if (arrayChar[x] == '') { arrayChar[x] = '\r'; }
                    if (arrayChar[x] == '') { arrayChar[x] = '\n'; }
                    tempStg = tempStg + arrayChar[x];
                }
                temp.Add(tempStg);
            }
            return temp;
        }
        private string Crc(string valor)
        {
            string ret = "0000";
            string crc= CheckSun.ComputeCrc(Encoding.ASCII.GetBytes(valor)).ToString("X");
            while(crc.Length < 4) { crc = "0" + crc; }
            ret = string.Format("{0}{1}", crc.Substring(2, 2), crc.Substring(0, 2));
            return ret;
        }
    }
}
