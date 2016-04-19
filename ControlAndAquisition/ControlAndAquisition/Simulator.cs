using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ControlAndAquisition
{
    class Simulator
    {
        Random rand = new Random();
        private double randChance = 0.8;
        Timer aTimer;
        public double y { get; set; }
        private double enviroment { get; set; }
        private double[] delayu;
        public double u { get; set; }
        private double TimeConstant { get; set; }
        private double tau { get; set; }
        private double ts { get; set; }
        private double gain { get; set; }

        public Simulator(double TimeStep)
        {
            enviroment = y = 20.0;
            
            TimeConstant = 19.7241;
            gain = 5.4828;
            tau = 2.3;
            ts = TimeStep;
            delayu = new double[Convert.ToInt16(tau / ts)];
            for (int i = 0; i < delayu.Length; i++)
            {
                delayu[i] = 0;
            }
            Timer aTimer = new Timer(ts * 1000);


            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            updateY();
        }

        private void updateY()
        {
            for (int i = 0; i < delayu.Length-1; i++)
            {
                delayu[i+1] = delayu[i];
            }
            delayu[0] = u;
            y = enviroment + y * (1 - (ts / TimeConstant)) + (ts / TimeConstant) * gain * delayu[delayu.Length - 1];
            if (rand.NextDouble()> randChance)
            {
                y = y + (rand.NextDouble() - 0.5)/5;
            }
        }
        
    }
}
