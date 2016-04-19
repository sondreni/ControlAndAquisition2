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
        double P;
        double Kp = 0.7755;
        double PV;
        double Ts = 0.05;
        double Ti = 20.2041;
        double I;
        double U;
        double MaxU = 5.0;
        double MinU = 0.0;
        double r;
        double e;
        double Compute()
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
