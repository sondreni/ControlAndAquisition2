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
        double Kp;
        double e;
        double Ts;
        double Ti;
        double I;
        double U;
        double MaxU;
        double MinU;

        double Compute()
        {
            P = Kp * e;
            I = I + e * (Kp * Ts) / Ti;


            if (I > MaxU)
            {
                I = MaxU;

            }
            else if(I<MinU)
            {
                    I = MinU;
                
            }

            if (P + I > MaxU)
            {
                U = MaxU;
            }

            else if (P + I < MinU)
            {

            }
            else
            {
                U = P + I;
            }

            return U;
        }
    }
}
