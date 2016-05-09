using System;
using System.Windows.Forms;

namespace ControlAndAquisition
{
    public partial class Form1 : Form
    {
        AnalogTransmitter TT01;
        Simulator SimAirheater;
        PIController PI;
        FUJIPID FU;

        bool RealAirheater=false;//Selecting the different possible configurations
        bool Fuji=false;

        string NIDAQDev = "dev31/";

        double TimeStep = 1;
            
                
        public Form1()
        {
            InitializeComponent();
            //Initializing the different parts that is selected to use.

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
            //Communication with real/simulated air-heater, fuji/software PID controller, whatever is chosen.
            
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
