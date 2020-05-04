using System;
using System.Collections.Generic;
using System.Text;

namespace DXM.Protocolo
{
    public class Bloco
    {
        public string nomeLinha { get; set; }
        public List<Regs> regList { get; set; }

        public Bloco()
        { }
        public Bloco(string _nome,List<Regs> _regs)
        {
            regList = _regs;
            nomeLinha = _nome;
        }
    }
}
