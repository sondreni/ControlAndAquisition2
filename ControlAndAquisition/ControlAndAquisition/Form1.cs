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
        PIController PI;
        Simulator Tempsimulator;
        OPC opcR = new OPC("r");
        OPC opcu = new OPC("u", true);
        OPC opcy = new OPC("y",true);
        LowPassFilter LPFilter;
        Alarm HHalarm = new Alarm("HH");
        Alarm Halarm = new Alarm("H");
        Alarm Lalarm = new Alarm("L");
        Alarm LLalarm = new Alarm("LL");


        NIDAQ NIDAQRW;
        System.Timers.Timer aTimer;
        double TimeStep = 0.1;
        double time = 0.0;
        double r=0;
        double y=0;
        double u=0;
        double FilteredY;
        double readV;


        //Testing
        AnalogTransmitter TT01 = new AnalogTransmitter("TT01");

        //Test End
        
        public Form1()
        {
            InitializeComponent();
            Tempsimulator = new Simulator(TimeStep);
            LPFilter = new LowPassFilter(TimeStep);
            

            PI = new PIController(TimeStep);
            


            NIDAQRW = new NIDAQ();

            chart1.Series.Clear();
            chart1.Series.Add("°C");
            chart1.Series["°C"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("u");
            chart1.Series["u"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("r");
            chart1.Series["r"].ChartType = SeriesChartType.Line;

        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            

        }

        private void tmrLoop_Tick(object sender, EventArgs e)
        {
            time += TimeStep;

            r = PI.r = opcR.Read();
            txtRefrence.Text = r.ToString();
            time = Math.Round(time, 1);
            
            //y = Tempsimulator.y;
            //u = Tempsimulator.u = PI.Compute(Tempsimulator.y);


            readV = Math.Round(NIDAQRW.GetValue(),4);
            lblRead2.Text = readV.ToString();
            y = (readV-1)*50/4;
            FilteredY = LPFilter.FilterValue(y);


            u = PI.Compute(FilteredY);//using the the unfiltered value for control
            NIDAQRW.SetValue(u);


            
            opcu.Write(u);
            opcy.Write(FilteredY);
            HHalarm.IsAlarm(FilteredY);
            Halarm.IsAlarm(FilteredY);
            Lalarm.IsAlarm(FilteredY);
            LLalarm.IsAlarm(FilteredY);


            


            //waste
            lblRead1.Text = FilteredY.ToString();

            //
            
            
            txtuu.Text = Convert.ToString(Math.Round(u, 1));
            txtYY.Text = Convert.ToString(Math.Round(y, 1));
            if (time > 60)
            {
                chart1.Series["u"].Points.RemoveAt(0);
                chart1.Series["°C"].Points.RemoveAt(0);
                chart1.Series["r"].Points.RemoveAt(0);
            } 

            chart1.Series["u"].Points.AddXY(time, u);
            chart1.Series["°C"].Points.AddXY(time, FilteredY);
            chart1.Series["r"].Points.AddXY(time, r);
            chart1.ResetAutoValues();

            //Read();

        }
        private void Read()
        {
            NIDAQRW.SetValue(Tempsimulator.u);
            lblRead1.Text = Convert.ToString(NIDAQRW.GetValue());
        }
    }
}
