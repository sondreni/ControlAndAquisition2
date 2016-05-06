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
        #region Initialize OPC communication
        OPC opcY = new OPC("y");
        OPC opcR = new OPC("r", true);
        OPC opcU = new OPC("u");
        OPC opcHHLim = new OPC("HHLim",true);
        OPC opcHLim = new OPC("HLim", true);
        OPC opcLLim = new OPC("LLim", true);
        OPC opcLLLim = new OPC("LLLim", true);
        #endregion

        #region Initialize SQL Alarm Communication
        Alarm alarms = new Alarm();

        #endregion

        #region Initialize parameters
        double Y;
        double R;
        double U;
        double time = 0;
        double HHLim;
        double HLim;
        double LLim;
        double LLLim;

        AlarmHistory alarmHist = new AlarmHistory();
        
        #endregion

        public Form1()
        {
            InitializeComponent();
            alarmHist.Hide();

            #region Initialize Limits
            txtHHLim.Text = "30";
            txtHLim.Text = "28";
            txtLLim.Text = "22";
            txtLLLim.Text = "20";
            opcHHLim.Write(Convert.ToDouble(txtHHLim.Text));
            opcHLim.Write(Convert.ToDouble(txtHLim.Text));
            opcLLim.Write(Convert.ToDouble(txtLLim.Text));
            opcLLLim.Write(Convert.ToDouble(txtLLLim.Text));
            #endregion

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
            Y = opcY.Read();
            R = opcR.Read();
            U = opcU.Read();
            txtValueTemp.Text = Y.ToString();


            chart1.Series["u"].Points.AddXY(time, U);
            chart1.Series["°C"].Points.AddXY(time, Y);
            chart1.Series["r"].Points.AddXY(time, R);
            chart1.ResetAutoValues();
        }//Executes charting

        private void btnUpdateLim_Click(object sender, EventArgs e)
        {
            #region Check if Limits are Numeric and send to OPC
            bool isNumeric = double.TryParse(txtHHLim.Text, out HHLim);
            if (isNumeric)
            {
                HHLim = Convert.ToDouble(txtHHLim.Text);
                opcHHLim.Write(HHLim);
            }
            else
            {
                MessageBox.Show("High High Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(txtHLim.Text, out HLim);
            if (isNumeric)
            {
                HLim = Convert.ToDouble(txtHHLim.Text);
                opcHLim.Write(HLim);
            }
            else
            {
                MessageBox.Show("High Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(txtLLim.Text, out LLim);
            if (isNumeric)
            {
                LLim = Convert.ToDouble(txtLLim.Text);
                opcLLim.Write(LLim);
            }
            else
            {
                MessageBox.Show("Low Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(txtLLLim.Text, out LLLim);
            if (isNumeric)
            {
                LLLim = Convert.ToDouble(txtLLLim.Text);
                opcLLLim.Write(LLLim);
            }
            else
            {
                MessageBox.Show("Low Low Limit must be a numeric value.", "SCADA HMI");
            }
            #endregion

        }

        private void btnUpdateSetPoint_Click(object sender, EventArgs e)
        {
            R = Convert.ToDouble(txtUpdateSetPoint.Text);
            opcR.Write(R);
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
