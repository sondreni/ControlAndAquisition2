using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments;
using NationalInstruments.DataInfrastructure;
//using NationalInstruments.DAQmx;
using System.Timers;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControlAndAquisition
{
    public partial class Form1 : Form
    {
        AnalogTransmitter TT01;
        Simulator SimAirheater;
        PIController PI;
        FUJIPID FU;

        bool RealAirheater=false;
        bool Fuji=false;

        string NIDAQDev = "dev31/";

        double TimeStep = 1;
            
                
        public Form1()
        {
            InitializeComponent();


            if (RealAirheater && Fuji)
            {
                FU = new FUJIPID("PID01", NIDAQDev+"ai1", NIDAQDev+"ai0", NIDAQDev + "ao0");
                TT01 = new AnalogTransmitter("TT01", NIDAQDev + "ai0", TimeStep);

            }
            else if(RealAirheater)
            {
                PI = new PIController(TimeStep, "PID01", NIDAQDev + "ai0", NIDAQDev + "ao0");
                TT01 = new AnalogTransmitter("TT01", NIDAQDev + "ai0", TimeStep);

            }
            else if (Fuji)
            {
                SimAirheater = new Simulator(0.1);
                FU = new FUJIPID("PID01", NIDAQDev + "ai1", NIDAQDev + "ao0");
                TT01 = new AnalogTransmitter("TT01", NIDAQDev + "ao0",TimeStep,true);
            }
            else
            {                
                TT01 = new AnalogTransmitter("TT01", TimeStep);
                SimAirheater = new Simulator(0.1);
                PI = new PIController(TimeStep, "PID01");
            }
            
            
            tmrLoop.Interval = Convert.ToInt16(TimeStep * 1000);
            tmrLoop.Enabled = true;
            
            
        }

        
        private void tmrLoop_Tick(object sender, EventArgs e)
        {
            
            
            if (RealAirheater && Fuji)
            {
                FU.Update();
                TT01.Update();
            }
            else if (RealAirheater)
            {
                TT01.Update();
                PI.Compute();
            }
            else if (Fuji)
            {
                TT01.Update(SimAirheater.y,true);
                SimAirheater.u= FU.Update(TT01.PV);
                
            }
            else
            {
                TT01.Update(SimAirheater.y);
                SimAirheater.u = PI.Compute(TT01.PV);
            }

        }
        
    }
}
