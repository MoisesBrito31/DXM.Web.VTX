using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DXM.OEE;

namespace DXM.Protocolo
{
    public class Script
    {
        public string pasta { get; set; }
        public string nomeArquivo { get; set; }
        public string arquivo { get; set; }
        public List<string> buffer { get; set; }
        public List<Linha> linhas { get; set; }
        public int log { get; set; }
        public Script()
        {
            inicia();
        }
        public Script(List<Linha> _linhas)
        {
            linhas = _linhas;
            inicia();
        }

        public Script(List<Linha> _linhas, int _log)
        {
            linhas = _linhas;
            log = _log;
            inicia();
        }
        private void inicia()
        {
            pasta = string.Format("{0}wwwroot\\script\\", AppContext.BaseDirectory);
            nomeArquivo = "OEE.sb";
            arquivo = pasta + nomeArquivo;
            buffer = new List<string>();
            carregaArquivo();
        }
        public bool carregaArquivo()
        {
            try
            {
                buffer = new List<string>();
                StreamReader rd = new StreamReader(arquivo);
                while (!rd.EndOfStream)
                {
                    buffer.Add(rd.ReadLine());
                }
                rd.Close();
                return true;
            }

            catch { return false; }
        }
        public bool salvaArquivo()
        {
            try
            {
                copilaBuffer();
                if (File.Exists(arquivo)) { File.Delete(arquivo); }
                StreamWriter wr = new StreamWriter(arquivo);
                for (int x = 0; x < buffer.Count; x++)
                {
                    wr.WriteLine(buffer[x]);
                }
                wr.Close();
                return true;
            }

            catch { return false; }
        }
        private void copilaBuffer()
        {
            try
            {
                List<string> temp1 = subBufferIni();               
                List<string> temp2 = subBufferFim();
                List<string> tempFinal = new List<string>();
                for (int x = 0; x < temp1.Count; x++) { tempFinal.Add(temp1[x]); }
                for (int x = 0; x < temp2.Count; x++) { tempFinal.Add(temp2[x]); }               
                buffer = tempFinal;
            }
            catch { }

        }
        private List<string> subBufferIni()
        {
            List<string> ret = new List<string>();
            ret.Add(string.Format("linhas={0}",linhas.Count));
            try
            {
                for (int x = 0; x < linhas.Count; x++)
                {
                    ret.Add(string.Format("vel_esp[{0}]={1}",x,linhas[x].vel_esp));
                    ret.Add(string.Format("forma[{0}]={1}",x,linhas[x].forma));
                    ret.Add(string.Format("t_p_prog[{0}]={1}",x,linhas[x].t_p_prog));
                }
                ret.Add(string.Format("trig_log={0}", (int)log/60));
                return ret;
            }
            catch { return ret; }
        }
        private List<string> subBufferFim()
        {
            List<string> ret = new List<string>();
            try
            {
                bool inicia = false;
                for (int x = 0; x < buffer.Count; x++)
                {
                    if (buffer[x].Contains("'inicio")) { inicia = true; }
                    if (inicia)
                    {
                        ret.Add(buffer[x]);
                    }
                }
                return ret;
            }
            catch { return ret; }
        }

    }
}
