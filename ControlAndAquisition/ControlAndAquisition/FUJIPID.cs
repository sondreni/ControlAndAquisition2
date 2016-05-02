using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAndAquisition
{
    class FUJIPID
    {
        OPC OPC_R;
        OPC OPC_U;

        NIDAQ NI_R;
        NIDAQ NI_U;
        NIDAQ NI_PV;
        
        
        public FUJIPID(string OPCTag, string NIDAQConnect_U, string NIDAQConnect_R) 
        {
            
            OPC_R = new OPC(OPCTag + "_R");
            OPC_U = new OPC(OPCTag + "_U", true);

            NI_U = new NIDAQ(NIDAQConnect_U);
            NI_R = new NIDAQ(NIDAQConnect_R);

        }

        public FUJIPID(string OPCTag, string NIDAQConnect_U, string NIDAQConnect_R,string NIDAQConnect_PV) : this(OPCTag, NIDAQConnect_U, NIDAQConnect_R)
        {
            NI_PV = new NIDAQ(NIDAQConnect_PV);
        }

        public void Update()
        {
            NI_R.Value= OPC_R.Read();
            OPC_U.Write(NI_U.Value);

        }
        public void Update(double PV)
        {
            NI_PV.Value = ((PV*4/50)+1);
            Update();

        }
    }
}
