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
using NationalInstruments.DAQmx;
using System.Timers;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControlAndAquisition
{
    public partial class Form1 : Form
    {
        PIController PI;
        Simulator Tempsimulator;
        OPC opc;
       
        //NIDAQ ReadY;
        System.Timers.Timer aTimer;
        double TimeStep = 0.1;
        double time = 0.0;
        double r=0;
        double y=0;
        double u=0;

        public Form1()
        {


            InitializeComponent();
            Tempsimulator = new Simulator(TimeStep);
            System.Timers.Timer aTimer = new System.Timers.Timer(TimeStep * 1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            PI = new PIController(TimeStep);
            opc = new OPC();
            opc.opcConnectSockets();


            //ReadY = new NIDAQ();

            chart1.Series.Clear();
            chart1.Series.Add("°C");
            chart1.Series["°C"].ChartType = SeriesChartType.Spline;
            chart1.Series.Add("u");
            chart1.Series["u"].ChartType = SeriesChartType.Spline;
            chart1.Series.Add("r");
            chart1.Series["r"].ChartType = SeriesChartType.Spline;

        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            

            
            

            
        }

        private void tmrLoop_Tick(object sender, EventArgs e)
        {
            time += TimeStep;
            
            r = PI.r  = opc.opcGetRef();
            txtRefrence.Text = r.ToString();
            time = Math.Round(time, 1);
            
            u = Tempsimulator.u = PI.Compute(Tempsimulator.y);
            y = Tempsimulator.y;
            opc.opcSendData(y, u);
            
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
        private void Read()
        {
            //lblRead1.Text = Convert.ToString(ReadY.GetValue());
        }
    }
}
