using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXM.OEE
{
    public class Hist
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public int oee { get; set; }
        public int dis { get; set; }
        public int q { get; set; }
        public int per { get; set; }
        public int vel_atu { get; set; }
        public int bons { get; set; }
        public int ruins_total { get; set; }
        public int t_prod { get; set; }
        public int t_par { get; set; }
       

        public Hist()
        {

        }
        public Hist(int _id,int _oee,int _dis, int _q,int _per, int _produzido)
        {
            time = DateTime.Now.ToLocalTime();
            oee = _oee;
            dis = _dis;
            q = _q;
            per = _per;
            bons = _produzido;
            id = _id;

        }
        public Hist(int _oee, int _dis, int _q, int _per, int _produzido)
        {
            time = DateTime.Now.ToLocalTime();
            oee = _oee;
            dis = _dis;
            q = _q;
            per = _per;
            bons = _produzido;
            id = 0;
        }
        public Hist(int _oee, int _dis, int _q, int _per, int _produzido, int _ruins, int _vel,int _t_prod,int _t_par )
        {
            time = DateTime.Now.ToLocalTime();
            oee = _oee;
            dis = _dis;
            q = _q;
            per = _per;
            bons = _produzido;
            ruins_total = _ruins;
            vel_atu = _vel;
            t_prod = _t_prod;
            t_par = _t_par;
            id = 0;
        }
        public Hist(int _id,int _oee, int _dis, int _q, int _per, int _produzido, int _ruins, int _vel, int _t_prod, int _t_par)
        {
            time = DateTime.Now.ToLocalTime();
            oee = _oee;
            dis = _dis;
            q = _q;
            per = _per;
            bons = _produzido;
            ruins_total = _ruins;
            vel_atu = _vel;
            t_prod = _t_prod;
            t_par = _t_par;
            id = _id;
        }
    }
}
