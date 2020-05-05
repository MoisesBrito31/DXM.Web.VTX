using System;
using System.Collections.Generic;
using System.Text;

namespace DXM.VTX
{
    public class VTX
    {

        public List<Motor> motores { get; set; } = new List<Motor>();
        public int quantidade { get; set; } = 0;
        public string DXM_Status { get; set; } = "";
        public string DXM_Endress { get; set; } = "192.168.0.4";
        public bool DXM_Tcp { get; set; } = true;
        public int emulador { get; set; } = 0;
        public int tickLog { get; set; } = 30;

        
        //
        public VTX() { }

    }
}
