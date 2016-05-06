using ControlAndAquisition;
using Datalogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCADAHMI
{
    public partial class Form1 : Form
    {
        string sqlConnectionstring= "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";

        PIDhmi PID01 = new PIDhmi("PID01");
        AnalogHMI TT01 = new AnalogHMI("TT01");

        #region Initialize SQL Alarm Communication
        Alarm alarms = new Alarm();
        #endregion

        #region Initialize parameters
        double Y;
        double R;
        double U;
        double time = 0;


        AlarmHistory alarmHist = new AlarmHistory();
        
        #endregion

        public Form1()
        {
            InitializeComponent();
            alarmHist.Hide();



            #region Initialize Chart
            chart1.Series.Clear();
            chart1.Series.Add("°C");
            chart1.Series["°C"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("u");
            chart1.Series["u"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("r");
            chart1.Series["r"].ChartType = SeriesChartType.Line;
            #endregion
        }


        private void btnStartHMI_Click(object sender, EventArgs e)
        {
            tmrHMI.Start();
        }

        private void tmrHMI_Tick(object sender, EventArgs e)
        {
            DoCharting();
        }
        public void DoCharting()
        {
            if (time > 60)
            {
                chart1.Series["u"].Points.RemoveAt(0);
                chart1.Series["°C"].Points.RemoveAt(0);
                chart1.Series["r"].Points.RemoveAt(0);
            }
            time++;
            Y = TT01.ReadY();
            R = PID01.ReadR();
            U = PID01.ReadU();
            txtValueTemp.Text = Y.ToString();

            chart1.Series["u"].Points.AddXY(time, U);
            chart1.Series["°C"].Points.AddXY(time, Y);
            chart1.Series["r"].Points.AddXY(time, R);
            chart1.ResetAutoValues();
        }//Executes charting

        private void btnUpdateLim_Click(object sender, EventArgs e)
        {
           

        }

        private void btnUpdateSetPoint_Click(object sender, EventArgs e)
        {
            R = Convert.ToDouble(txtUpdateSetPoint.Text);
            PID01.UpdateR(R);
        }

        private void btnAckHHAlrm_Click(object sender, EventArgs e)
        {

        }

        public void AckAlarm()
        {
            alarms.GetAlarms(sqlConnectionstring);

        }

        private void btnShowAlrmHist_Click(object sender, EventArgs e)
        {
            alarmHist.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
