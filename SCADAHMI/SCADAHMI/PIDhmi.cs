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
       
        double U;

        OPC opcR;
        OPC opcU;
        public PIDhmi(string PIDtag)
        {
            opcR = new OPC(PIDtag + "_R", true);
            opcU = new OPC(PIDtag + "_U");
        }
        public void UpdateR(double SetPoint)
        {
            opcR.Write(SetPoint);
        }
    
        public double ReadU()
        {
            U = opcU.Read();
            return U;
        }
        public double R
        {
            get
            {
                return opcR.Value;
            }
        }
    }
}
