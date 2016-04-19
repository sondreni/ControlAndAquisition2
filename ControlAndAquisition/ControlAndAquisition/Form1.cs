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
using System.Timers;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControlAndAquisition
{
    public partial class Form1 : Form
    {
        PIController PI;
        Simulator Tempsimulator;
        System.Timers.Timer aTimer;
        double TimeStep = 0.1;
        double time = 0.0;
        double r;
        public Form1()
        {


            InitializeComponent();
            Tempsimulator = new Simulator(TimeStep);
            System.Timers.Timer aTimer = new System.Timers.Timer(TimeStep * 1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            PI = new PIController(TimeStep);



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
            time += TimeStep;
            PI.r = Convert.ToDouble(txtRefrence.Text);
            Tempsimulator.u = PI.Compute(Tempsimulator.y);

            //chart1.Series["u"].Points.AddXY(time, PI.U);
            //chart1.Series["°C"].Points.AddXY(time, Tempsimulator.y);
            //chart1.Series["r"].Points.AddXY(time, PI.r);
        }
    }
}
