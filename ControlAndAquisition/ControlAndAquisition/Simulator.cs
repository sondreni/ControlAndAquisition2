using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using

namespace ControlAndAquisition
{
    class Simulator
    {
        private double y;
        private double enviroment { get; set; }
        private double[] delayu;
        private double u { get; set; }
        private double TimeConstant { get; set; }
        private double tau { get; set; }
        private double ts { get; set; }
        private double gain { get; set; }

        public Simulator(double TimeStep)
        {
            enviroment = y = 20;
            
            TimeConstant = 19.7241;
            gain = 5.4828;
            tau = 2.3;
            ts = TimeStep;
            delayu = new double[Convert.ToInt16(tau / ts)];
            for (int i = 0; i < delayu.Length; i++)
            {
                delayu[i] = 0;
            }
            
        }

        private void updatey()
        {
            for (int i = 0; i < delayu.Length-1; i++)
            {
                delayu[i+1] = delayu[i];
            }
            delayu[0] = u;
            y = enviroment + y * (1 - (ts / TimeConstant)) + (ts / TimeConstant) * gain * delayu[delayu.Length - 1];
        }
        
    }
}
