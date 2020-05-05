using System;
using System.Collections.Generic;
using System.Text;

namespace DXM.VTX
{
    public class Hist
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public float V_Rms_Vel_X { get; set; }
        public float V_Rms_Vel_Z { get; set; }
        public float temperatura { get; set; }

        public float alert_tempe { get; set; }
        public float alert_v_Rms_Vel_X { get; set; }
        public float alert_v_Rms_Vel_Z { get; set; }

        public string Estado { get; set; }

        public Hist() { }

        public Hist(int _id, DateTime _data, float _x, float _z,float _tempera,float _alert_x,float _alert_z,float _ale_temp,string _estado)
        {
            id = _id;
            time = _data;
            V_Rms_Vel_X = _x;
            V_Rms_Vel_Z = _z;
            temperatura = _tempera;
            alert_tempe = _ale_temp;
            alert_v_Rms_Vel_X = _alert_x;
            alert_v_Rms_Vel_Z = _alert_z;

        }
    }
}
