using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlAndAquisition
{
    class PIController
    {

        public double P { get; set; }
        double Kp = 0.7755;
        double Ts;
        double Ti = 20.2041;
        public double I { get; set; }
        public double U { get; set; }
        double MaxU = 5.0;
        double MinU = 0.0;
        public double r { get; set; }
        double e = 0.0;

        OPC OPC_R;
        OPC OPC_U;
        NIDAQ NI_R;
        NIDAQ NI_U;


        public PIController(double TimeStep)
        {
            Ts = TimeStep;
        }

        public PIController(double TimeStep, string NI_R_Connect, string NI_U_Connect,string OPCTag):this(TimeStep) 
        {
            NI_R = new NIDAQ(NI_R_Connect);
            NI_U = new NIDAQ(NI_U_Connect);
            OPC_R = new OPC(OPCTag + "_R");
            OPC_U = new OPC(OPCTag + "_U",true);

        }

        public PIController(double TimeStep, string NI_U_Connect, string OPCTag) : this(TimeStep)
        {

        }



        public double Compute(double PV)
        {
            e = r - PV;
            P = Kp * e;
            I = I + e * (Kp * Ts) / Ti;

            if (I > MaxU)
            {
                I = MaxU;
            }
            else if (I < MinU)
            {
                I = MinU;
            }

            if (P + I > MaxU)
            {
                U = MaxU;
            }

            else if (P + I < MinU)
            {
                U = MinU;
            }

            else
            {
                U = P + I;
            }

            return U;
        }
    }
}
