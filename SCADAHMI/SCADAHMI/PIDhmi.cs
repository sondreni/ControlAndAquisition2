using ControlAndAquisition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADAHMI
{
    class PIDhmi
    {
       
        

        OPC opcR;
        OPC opcU;
        public PIDhmi(string PIDtag)
        {
            opcR = new OPC(PIDtag + "_R", true);
            opcU = new OPC(PIDtag + "_U");
        }


        public double R
        {
            get
            {
                return opcR.Value;
            }
            set
            {
                opcR.Value = value;
            }
        }
        public double U
        {
            get
            {
                return opcU.Value;
            }
        }
    }
}
