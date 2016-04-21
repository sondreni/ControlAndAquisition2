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
        
        public LowPassFilter(double TimeStep)
        {
            Ts = TimeStep;
        }

        public double FilterValue(double ProcessValue)
        {
            a = Ts / (Tf + Ts);
            FilteredValue = ProcessValue;
            FilteredValue = (1 - a) * FilteredValue + a * ProcessValue;

            return FilteredValue;
        }
    }
}
