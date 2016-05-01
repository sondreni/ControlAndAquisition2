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
        public PIController(double TimeStep)
        {
            Ts = TimeStep;
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
