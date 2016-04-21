using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAndAquisition
{
    class LowPassFilter
    {
        double Ts = 0.05;
        double Tf = 0.7;
        double FilteredValue;
        double a;
        bool started = false;
        
        public LowPassFilter(double TimeStep)
        {
            Ts = TimeStep;
            a = Ts / (Tf + Ts);
        }

        public double FilterValue(double ProcessValue)
        {
            if (started)
            {
                FilteredValue = (1 - a) * FilteredValue + a * ProcessValue;
            }
            else
            {
                FilteredValue = ProcessValue;
                started = true;
            }
            
                       

            return FilteredValue;
        }
    }
}
