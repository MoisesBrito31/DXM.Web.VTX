using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace DXM.Protocolo
{
    public class Xml
    {
        public string pasta { get; set; } 
        public string nomeArquivo { get; set; } 
        public string arquivo { get; set; }

        public List<string> buffer { get; set; }
        public Mapa mapa { get; set; }

        public Xml()
        {
            inicia();
        }
        public Xml(Mapa _mapa)
        {
            inicia();
            mapa = _mapa;
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
                for(int x = 0; x < buffer.Count; x++)
                {
                    wr.WriteLine(buffer[x]);
                }
                wr.Close();
                return true;
            }

            catch { return false; }
        }

        private void inicia()
        {
            pasta = string.Format("{0}wwwroot\\script\\", AppContext.BaseDirectory);
            nomeArquivo = "DXM_OEE.xml";
            arquivo = pasta + nomeArquivo;
            buffer = new List<string>();
            carregaArquivo();
        }
        private void copilaBuffer()
        {
            try
            {
                List<string> temp1 = subBufferIni();
                List<string> temp2 = subBufferRegs();
                List<string> temp3 = subBufferRegsWrite();
                List<string> temp4 = subBufferRegsEvents();
                List<string> temp5 = subBufferFim();
                List<string> tempFinal = new List<string>();
                for (int x = 0; x < temp1.Count; x++) { tempFinal.Add(temp1[x]); }
                for (int x = 0; x < temp2.Count; x++) { tempFinal.Add(temp2[x]); }
                for (int x = 0; x < temp3.Count; x++) { tempFinal.Add(temp3[x]); }
                for (int x = 0; x < temp4.Count; x++) { tempFinal.Add(temp4[x]); }
                for (int x = 0; x < temp5.Count; x++) { tempFinal.Add(temp5[x]); }
                buffer = tempFinal;
            }
            catch { }

        }
        private List<string> subBufferIni()
        {
            List<string> ret = new List<string>();
            try
            {
                for (int x = 0; x < buffer.Count; x++)
                {
                    if (buffer[x].Contains("<rtu_read>") || buffer[x].Contains("<rtu_read />")) { return ret; }
                    ret.Add(buffer[x]);                    
                }
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
                    if (inicia)
                    {
                        ret.Add(buffer[x]);
                    }
                    if (buffer[x].Contains("</sched_events>") || buffer[x].Contains("<sched_events />")) { inicia = true; }
                    
                }
                return ret;
            }
            catch { return ret; }
        }
        private List<string> subBufferRegs()
        {
            List<string> ret = new List<string>();
            try {
                ret.Add(" <rtu_read>");
                string dword = "";
            float ciclo = 0.5f;
            string cicloStr = "";
                string temp = ";";
            int reg = 0;
            for (int x = 0; x < mapa.qndLinhas; x++)
            {
                    if (mapa.linhas[x].regList[0].ativo)
                    {
                        if (mapa.linhas[x].regList[0].dword) { dword = "2"; }
                        else { dword = "1"; }
                        temp = "";
                        ciclo = mapa.linhas[x].regList[0].ciclo / 1000f;
                        cicloStr = Convert.ToString(ciclo);
                        if (cicloStr.Length > 4) { cicloStr = cicloStr.Substring(0, 4); }
                        for (int x1 = 0; x1 < cicloStr.Length; x1++)
                        {
                            if (cicloStr.Substring(x1, 1).Contains(",")) { temp = string.Format("{0}{1}", temp, "."); }
                            else { temp = string.Format("{0}{1}", temp, cicloStr.Substring(x1, 1)); }
                        }
                        cicloStr = temp;
                        reg = mapa.linhas[x].regList[0].reg;
                        ret.Add(string.Format("  <rule count=\"{0}\" mask=\"0\" name=\"contagem_entrada\" offset=\"0\" poll=\"{1}\" remfmt=\"int\" remreg=\"{2}\" remtype=\"hold_reg\" scale=\"0\" swapped=\"0\" unit=\"1\" localreg=\"{3}\" maxfail=\"0\" default=\"0\" />",
                            dword, cicloStr, reg, (x * 5) + 1));
                    }

                    if (mapa.linhas[x].regList[1].ativo){
                        if (mapa.linhas[x].regList[1].dword) { dword = "2"; }
                        else { dword = "1"; }
                        ciclo = mapa.linhas[x].regList[1].ciclo / 1000f;
                        temp = "";
                        cicloStr = Convert.ToString(ciclo);
                        if (cicloStr.Length > 4) { cicloStr = cicloStr.Substring(0, 4); }
                        for (int x1 = 0; x1 < cicloStr.Length; x1++)
                        {
                            if (cicloStr.Substring(x1, 1).Contains(",")) { temp = string.Format("{0}{1}", temp, "."); }
                            else { temp = string.Format("{0}{1}", temp, cicloStr.Substring(x1, 1)); }
                        }
                        cicloStr = temp;
                        reg = mapa.linhas[x].regList[1].reg;
                        ret.Add(string.Format("  <rule count=\"{0}\" mask=\"0\" name=\"contagem_saida\" offset=\"0\" poll=\"{1}\" remfmt=\"int\" remreg=\"{2}\" remtype=\"hold_reg\" scale=\"0\" swapped=\"0\" unit=\"1\" localreg=\"{3}\" maxfail=\"0\" default=\"0\" />",
                            dword, cicloStr, reg, (x * 5) + 3)); 
                    }

                    if (mapa.linhas[x].regList[2].ativo) {
                        dword = "1";
                        temp = "";
                        ciclo = mapa.linhas[x].regList[2].ciclo / 1000f;
                        reg = mapa.linhas[x].regList[2].reg;
                        cicloStr = Convert.ToString(ciclo);
                        if (cicloStr.Length > 4) { cicloStr = cicloStr.Substring(0, 4); }
                        for (int x1 = 0; x1 < cicloStr.Length; x1++)
                        {
                            if (cicloStr.Substring(x1, 1).Contains(",")) { temp = string.Format("{0}{1}", temp, "."); }
                            else { temp = string.Format("{0}{1}", temp, cicloStr.Substring(x1, 1)); }
                        }
                        cicloStr = temp;
                        ret.Add(string.Format("  <rule count=\"{0}\" mask=\"0\" name=\"maquina_parada\" offset=\"0\" poll=\"{1}\" remfmt=\"int\" remreg=\"{2}\" remtype=\"hold_reg\" scale=\"0\" swapped=\"0\" unit=\"1\" localreg=\"{3}\" maxfail=\"0\" default=\"0\" />",
                        dword, cicloStr, reg, (x * 5) + 5)); 
                    }

            }
                ret.Add(" </rtu_read>");
                return ret;
            }
            catch {
                ret.Add(" </rtu_read>");
                return ret; }
        }
        private List<string> subBufferRegsWrite()
        {
            List<string> ret = new List<string>();
            try
            {
                ret.Add(" <rtu_write>");
                string dword = "";
                float ciclo = 0.5f;
                string cicloStr = "";
                string temp = ";";
                int reg = 0;
                for (int x = 0; x < mapa.qndLinhas; x++)
                {
                    if (mapa.linhas[x].regList[0].ativo)
                    {
                        dword = "1";
                        temp = "";
                        ciclo = mapa.linhas[x].regList[0].ciclo / 1000f;
                        cicloStr = Convert.ToString(ciclo);
                        if (cicloStr.Length > 4) { cicloStr = cicloStr.Substring(0, 4); }
                        for (int x1 = 0; x1 < cicloStr.Length; x1++)
                        {
                            if (cicloStr.Substring(x1, 1).Contains(",")) { temp = string.Format("{0}{1}", temp, "."); }
                            else { temp = string.Format("{0}{1}", temp, cicloStr.Substring(x1, 1)); }
                        }
                        cicloStr = temp;
                        reg = (mapa.linhas[x].regList[0].reg/16)*16+14;
                        ret.Add(string.Format("  <rule count=\"{0}\" mask=\"0\" name=\"zerar_conEnt\" offset=\"0\" poll=\"{1}\" remfmt=\"int\" remreg=\"{2}\" remtype=\"hold_reg\" scale=\"0\" swapped=\"0\" unit=\"1\" localreg=\"{3}\" fill=\"0\" />",
                            dword, cicloStr, reg, (x * 13) + 109));
                    }

                    if (mapa.linhas[x].regList[1].ativo)
                    {
                        dword = "1";
                        ciclo = mapa.linhas[x].regList[1].ciclo / 1000f;
                        temp = "";
                        cicloStr = Convert.ToString(ciclo);
                        if (cicloStr.Length > 4) { cicloStr = cicloStr.Substring(0, 4); }
                        for (int x1 = 0; x1 < cicloStr.Length; x1++)
                        {
                            if (cicloStr.Substring(x1, 1).Contains(",")) { temp = string.Format("{0}{1}", temp, "."); }
                            else { temp = string.Format("{0}{1}", temp, cicloStr.Substring(x1, 1)); }
                        }
                        cicloStr = temp;
                        reg = (mapa.linhas[x].regList[1].reg / 16)*16 + 14;
                        ret.Add(string.Format("  <rule count=\"{0}\" mask=\"0\" name=\"zerar_conEnt\" offset=\"0\" poll=\"{1}\" remfmt=\"int\" remreg=\"{2}\" remtype=\"hold_reg\" scale=\"0\" swapped=\"0\" unit=\"1\" localreg=\"{3}\" fill=\"0\" />",
                            dword, cicloStr, reg, (x * 13) + 109));
                    }   
                }
                ret.Add(" </rtu_write>");
              
                for(int x = 0; x < ret.Count; x++)
                {
                    for (int y = x; y < ret.Count; y++)
                    {
                        if (y != x)
                        {
                            if (ret[x] == ret[y]) { ret[x] = ""; }
                        }
                    }
                }

                return ret;
            }
            catch {
                ret.Add("</rtu_write>");
                return ret; 
            }
        }
        private List<string> subBufferRegsEvents()
        {
            List<string> ret = new List<string>();
            try
            {
                ret.Add(" <sched_holidays />");
                ret.Add(" <sched_commands />");
                ret.Add(" <sched_events>");                
                for (int x = 0; x < mapa.turnos.Count; x++)
                {
                    string temp = mapa.turnos[x].getXml();
                    if (temp != "") { ret.Add(temp); }
                }
                ret.Add(" </sched_events>");     
                return ret;
            }
            catch
            {
                ret.Add("</sched_events>");
                return ret;
            }
        }
    }
}
