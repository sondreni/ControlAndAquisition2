﻿namespace ControlAndAquisition
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
        double PV;

        OPC OPC_R;
        OPC OPC_U;
        NIDAQ NI_U;
        NIDAQ NI_PV;

        public PIController(double TimeStep, string OPCTag)//KP, Ti, Max/MinU could be inputs to the constructor, but thats for another time
        {
            Ts = TimeStep;
            OPC_R = new OPC(OPCTag + "_R");
            OPC_U = new OPC(OPCTag + "_U", true);
        }

        public PIController(double TimeStep, string OPCTag, string NI_PV_Connect, string NI_U_Connect) : this(TimeStep,OPCTag) //PIController and simulator
        {
            NI_U = new NIDAQ(NI_U_Connect);
            NI_PV = new NIDAQ(NI_PV_Connect);
        }
        public double Compute()
        {
            PV = ((NI_PV.Value - 1)*50 / 4);
            U = Compute(PV);
            NI_U.Value=U;
            return U;
        }
        public double Compute(double PV)//Standard PI controller with anti wind-up
        {
            r = OPC_R.Read();
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

            OPC_U.Write(U);
            return U;

        }
    }
}
