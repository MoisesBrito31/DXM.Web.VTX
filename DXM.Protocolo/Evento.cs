using System;
using System.Collections.Generic;
using System.Text;

namespace DXM.Protocolo
{
    public class Evento
    {
        public int id { get; set; }
        public DateTime end { get; set; }
        public string nome { get; set; }
        public int reg { get; set; }
        public DateTime start { get; set; }
        public int on { get; set; }
        public int exclude { get; set; }
        public string days { get; set; }
        public int off { get; set; }

        public Evento()
        {

        }

        public Evento(string _nome, DateTime _start)
        {
            on = 1;
            off = 0;
            nome = _nome;
            reg = 91;
            exclude = 0;
            days = "SMTWHFR";
            end = _start.AddSeconds(1);
            start = _start;
        }

        public Evento(int _id, string _nome, DateTime _start)
        {
            id = _id;
            on = 1;
            off = 0;
            nome = _nome;
            reg = 91;
            exclude = 0;
            days = "SMTWHFR";
            end = _start.AddSeconds(1);
            start = _start;
        }

        public Evento(int _id,string _nome, DateTime _start, int _reg)
        {
            id = _id;
            on = 1;
            off = 0;
            nome = _nome;
            reg = _reg;
            exclude = 0;
            days = "SMTWHFR";
            end = _start.AddSeconds(1);
            start = _start;
        }

        public string getXml()
        {
            string ret = "";
            if (start != null)
            {
                ret = string.Format("<event end=\"{0}\" name=\"{1}\" reg=\"{2}\" start=\"{3}\" on=\"{4}\" exclude=\"{5}\" days=\"{6}\" off=\"{7}\" />",
                    end.ToShortTimeString(), nome,reg,start.ToShortTimeString(),on,exclude,days,off);
            }
            return ret;
        }
    }
}
