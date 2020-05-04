using System;
using System.Collections.Generic;
using System.Text;

namespace DXM.Protocolo
{
    public class Regs
    {
        public int id { get; set; }
        public int reg { get; set; }
        public int ciclo { get; set; }
        public bool dword { get; set; }
        public bool ativo { get; set; }
        

        public Regs() { }
        public Regs(int _id, int _reg, int _cliclo, bool _dword)
        {
            ativo = true;
            reg = _reg;
            ciclo = _cliclo;
            dword = _dword;
            id = _id;
        }


    }
}
