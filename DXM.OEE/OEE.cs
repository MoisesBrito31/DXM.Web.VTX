using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXM.OEE
{
    public class OEE
    {
        public List<Linha> Linhas { get; set; } = new List<Linha>();
        public int quantidade { get; set; } = 0;
        public string DXM_Status { get; set; } = "";
        public string DXM_Endress { get; set; } = "192.168.0.4";
        public bool DXM_Tcp { get; set; } = true;
        public int emulador { get; set; } = 0;
        public int tickLog { get; set; } = 30;

        public OEE()
        {

        }
        public OEE(int _linhas)
        {
            for(int x = 0; x < _linhas; x++)
            {
                Linha l = new Linha();
                l.nome = string.Format("Linha produtiva {0}",x+1);
                l.id = x;
                Linhas.Add(l);
            }
            quantidade = _linhas;
        }
        public OEE(int _linhas,List<Linha> ls)
        {
            Linhas = ls;
            quantidade = _linhas;
        }
        public OEE(int _linhas, List<Linha> ls, string _endereco)
        {
            Linhas = ls;
            quantidade = _linhas;
            DXM_Endress = _endereco;
            if (_endereco.Contains("COM") || _endereco.Contains("com")) { DXM_Tcp = false; }
            else { DXM_Tcp = true; }
            
        }
        public OEE(int _linhas, List<Linha> ls, string _endereco,int _emulador,int _tickLog)
        {
            Linhas = ls;
            quantidade = _linhas;
            DXM_Endress = _endereco;
            emulador = _emulador;

            if(_tickLog==0) { _tickLog = 30; }

            tickLog = _tickLog;

            if (_endereco.Contains("COM") || _endereco.Contains("com")) { DXM_Tcp = false; }
            else { DXM_Tcp = true; }

        }


        public void DXM_insertFalha()
        {
            DXM_Status = "DXM OffLine";
            for(int x = 0; x < Linhas.Count; x++)
            {
                Linhas[x].insert_falha();
            }
        }
        public void DXM_insertOnLine()
        {
            DXM_Status = "DXM Online";
        }

        public void alteraLinhas(int quant)
        {
            if (quant == 0) { quant = 1; }
            
                int result = quant - quantidade;
                if (result > 0)
                {
                    for (int x = 0; x < result; x++)
                    {
                        Linha l = new Linha();
                        l.nome = string.Format("Linha produtiva {0}", x + quantidade + 1);
                        l.id = x+quantidade;
                        Linhas.Add(l);
                    }

                }
                if (result < 0)
                {
                   
                    for (int x = Linhas.Count - 1; x >= quant; x--)
                    {
                        Linhas.RemoveAt(x);
                    }
                }
                quantidade = Linhas.Count;
            
        }

        public void flush()
        {
            for(int x = 0; x < Linhas.Count; x++)
            {
                Linhas[x].histFiltro = new List<Hist>();
                Linhas[x].historico = new List<Hist>();
            }
        }

        public void normaliza()
        {
            if (Linhas.Count != quantidade)
            {
                alteraLinhas(quantidade);
            }
        }
    }
}
