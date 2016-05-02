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
        Simulator Airheater;
        PIController PI;
        OPC OPC_r;
        OPC OPC_u;
        
        
        double TimeStep = 1;
        double time = 0.0;
        double r=0;
        double y=0;
        double u=0;
        
        
        
        public Form1()
        {
            InitializeComponent();
            TT01 = new AnalogTransmitter("TT01");
            Airheater = new Simulator(0.1);
            tmrLoop.Enabled = true;
            PI = new PIController(TimeStep);
            OPC_r = new OPC("r");
            OPC_u = new OPC("u", true);


            
            

            chart1.Series.Clear();
            chart1.Series.Add("°C");
            chart1.Series["°C"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("u");
            chart1.Series["u"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("r");
            chart1.Series["r"].ChartType = SeriesChartType.Line;

        }

        

        private void tmrLoop_Tick(object sender, EventArgs e)
        {
            time += TimeStep;

            TT01.Update(Airheater.y);
            y = TT01.PV;
            r= PI.r = OPC_r.Read();
            Airheater.u = PI.Compute(TT01.PV);
            OPC_u.Write(PI.U);
            u = PI.U;

            
            txtRefrence.Text = r.ToString();
            time = Math.Round(time, 1);
            
            //y = Tempsimulator.y;
            //u = Tempsimulator.u = PI.Compute(Tempsimulator.y);

            
            
            txtuu.Text = Convert.ToString(Math.Round(u, 1));
            txtYY.Text = Convert.ToString(Math.Round(y, 1));
            if (time > 60)
            {
                chart1.Series["u"].Points.RemoveAt(0);
                chart1.Series["°C"].Points.RemoveAt(0);
                chart1.Series["r"].Points.RemoveAt(0);
            } 

            chart1.Series["u"].Points.AddXY(time, u);
            chart1.Series["°C"].Points.AddXY(time, y);
            chart1.Series["r"].Points.AddXY(time, r);
            chart1.ResetAutoValues();

            

        }
        
    }
}
