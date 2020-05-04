using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using DXM.OEE;

namespace DXM.Protocolo
{
    public class Mapa
    {
        public string nome { get; set; }
        public string pasta { get; set; }
        public string nomeArquivo { get; set; }
        public string arquivo { get; set; }
        public List<Bloco> linhas { get; set; } = new List<Bloco>();
        public List<Evento> turnos { get; set; } = new List<Evento>();
        public int qndLinhas { get; set; }
        

        private string Status;

        public Mapa() {            
        }
        public Mapa(string _nome, string _nomeArquivo)
        {
            pasta = string.Format(@"{0}store\Mapas\", AppContext.BaseDirectory);
            arquivo = pasta + _nomeArquivo;
            nome = _nome;           
            nomeArquivo = _nomeArquivo;
            carregaArquivo();

        }
        public Mapa(string _nome ,string _nomeArquivo,string _pasta)
        {
            arquivo = _pasta + _nomeArquivo;          
            nome = _nome;
            pasta = _pasta;
            nomeArquivo = _nomeArquivo;
            carregaArquivo();
          
        }
        public Mapa(string _nome, string _pasta,string _nomeArquivo,List<Bloco> _linhas)
        {
            arquivo = _pasta + _nomeArquivo;
            qndLinhas = _linhas.Count;
            nome = _nome;
            pasta = _pasta;
            nomeArquivo = _nomeArquivo;
            linhas = _linhas;

        }


       
        public void carregaArquivo()
        {
            if (verificaArquivo())
            {
                try
                {
                    StreamReader rd = new StreamReader(arquivo);
                    string json = rd.ReadToEnd();
                    Mapa mapa = JsonConvert.DeserializeObject<Mapa>(json);
                    nome = mapa.nome;
                    pasta = mapa.pasta;
                    nomeArquivo = mapa.nomeArquivo;
                    arquivo = mapa.arquivo;
                    linhas = mapa.linhas;
                    qndLinhas = mapa.qndLinhas;
                    turnos = mapa.turnos;
                    rd.Close();
                    Status = "ok";
                }
                catch (Exception ex) { Status = "falha, " + ex.Message; }
            }
        }
        public void salvaArquivo(Mapa mapa)
        {
            try
            {
                StreamWriter wr = new StreamWriter(mapa.arquivo);
                wr.Write(JsonConvert.SerializeObject(mapa));
                wr.Close();
                Status = "ok";
            }
            catch (Exception ex) { Status = "falha, " + ex.Message; }            
        }
        public bool alteraQtdLinhas(int num)
        {
            if (num > qndLinhas)
            {
                List<Regs> regs = new List<Regs>();
                Regs a = new Regs(1, 17, 1000, false);
                regs.Add(a);
                regs.Add(a);
                regs.Add(a);
               
                for (int x = 0; x < num - qndLinhas; x++)
                {
                    Bloco bloco = new Bloco("linha " + Convert.ToString(x + qndLinhas+1), regs);
                    linhas.Add(bloco);
                }
                qndLinhas = linhas.Count;
                salvaArquivo(this);
                return true;
            }
            else if (num < qndLinhas)
            {
                for (int x=qndLinhas-1; x>=num; x--)
                {
                    linhas.RemoveAt(x);
                }
                qndLinhas = linhas.Count;
                salvaArquivo(this);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void alteraNomeLinhas(OEE.OEE oee)
        {
            for(int x = 0; x < oee.Linhas.Count; x++)
            {
                linhas[x].nomeLinha = oee.Linhas[x].nome;
            }
            salvaArquivo(this);
        }
        private bool verificaArquivo()
        {
            try
            {
                if (!Directory.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                    inicia();
                }
                else if (!File.Exists(arquivo))
                {
                    inicia();
                }
                else
                {
                    Status = "ok";
                    return true;
                }               
                
            }
            catch (Exception ex) { Status = "falha, " + ex.Message; }
            Status = "ok";
            return false;

        }
        private void inicia()
        {
            if (nome == "") { nome = "basico"; }
            if (nomeArquivo == "") { nomeArquivo = "basico.mapa"; }            
            arquivo = pasta + nomeArquivo;
            if (qndLinhas == 0) { qndLinhas = 2; }
            linhas = new List<Bloco>();

            for (int x = 0; x < qndLinhas; x++)
            {
                List<Regs> regs = new List<Regs>();
                Regs a = new Regs(1, 17, 1000, false);
                Regs b = new Regs(1, 18, 1000, false);
                Regs c = new Regs(1, 19, 1000, false);
                regs.Add(a);
                regs.Add(b);
                regs.Add(c);
                Bloco bloco = new Bloco(String.Format("linha {0}", x+1), regs);
                linhas.Add(bloco);
            }

            turnos.Add(new Evento());

            salvaArquivo(this);

        }

        private void getArquivoXml()
        {
            List<string> bufer = new List<string>();
            try
            {
                StreamReader rd = new StreamReader(arquivo);
            }
            catch { }
        }



    }
}
