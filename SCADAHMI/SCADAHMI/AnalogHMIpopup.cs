using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCADAHMI
{
    public partial class AnalogHMIpopup : Form
    {
        //Create variables.
        public double time;
        public double Y;
        public double U;
        public double R;
        public bool AlarmActive;/***Test****/
        string sqlConnectionstring = "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";
        

        AnalogHMI TT01 = new AnalogHMI("TT01");
        PIDhmi PID01 = new PIDhmi("PID01");
        public AnalogHMIpopup()
        {
            InitializeComponent();

            #region Initialize Chart
            chart1.Series.Clear();
            chart1.Series.Add("°C");
            chart1.Series["°C"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("r");
            chart1.Series["r"].ChartType = SeriesChartType.Line;            
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;

            chart2.Series.Clear();
            chart2.Series.Add("u");
            chart2.Series["u"].ChartType = SeriesChartType.Line;
            chart2.ChartAreas[0].AxisY.IsStartedFromZero = false;
            #endregion
        }

        public void DoCharting()
        {
            if (time > 60)
            {
                chart2.Series["u"].Points.RemoveAt(0);
                chart1.Series["°C"].Points.RemoveAt(0);
                chart1.Series["r"].Points.RemoveAt(0);
            }
            time++;
            Y = TT01.Y;
            R = PID01.R;
            U = PID01.U;
            txtValueTemp.Text = Y.ToString();

            chart2.Series["u"].Points.AddXY(time, U);
            chart1.Series["°C"].Points.AddXY(time, Y);
            chart1.Series["r"].Points.AddXY(time, R);
            chart1.ResetAutoValues();
            chart2.ResetAutoValues();
            
            
        }//Executes charting

        private void CheckActiveAlarms()//0=HH,1=H,2=L,3=LL
        {

            if (TT01.GetActiveAlarm(0) == 1)
            {
                chkHHActive.Checked = true;
                chkHActive.Checked = true;
                AlarmActive = true;
            }
            else if (TT01.GetActiveAlarm(1) == 1)
            {
                chkHActive.Checked = true;
                AlarmActive = true;
            }
            else if (TT01.GetActiveAlarm(3) == 1)
            {
                chkLLActive.Checked = true;
                chkLActive.Checked = true;
                AlarmActive = true;
            }
            else if (TT01.GetActiveAlarm(2) == 1)
            {
                chkLActive.Checked = true;
                AlarmActive = true;
            }

        }
        private void AnalogHMIpopup_Load(object sender, EventArgs e)
        {

            tmrAnalogHMIpopup.Start(); //Starts timer which starts updating plot.
            #region Initialize Limits
            txtHHLim.Text = "30";
            txtHLim.Text = "28";
            txtLLim.Text = "22";
            txtLLLim.Text = "20";

            TT01.UpdateLim(txtHHLim.Text, txtHLim.Text, txtLLim.Text, txtLLLim.Text);
            #endregion
        }

        private void tmrAnalogHMIpopup_Tick(object sender, EventArgs e)
        {

            DoCharting();
            txtValueTemp.Text = TT01.Y.ToString();
        }


        private void btnUpdateLim_Click(object sender, EventArgs e)
        {
            TT01.UpdateLim(txtHHLim.Text, txtHLim.Text, txtLLim.Text, txtLLLim.Text);

        }

        private void btnAckHHAlrm_Click(object sender, EventArgs e)
        {
            if (TT01.GetActiveAlarm(0) == 0)
            {
                //Write to SQL here****************************************

                using (SqlConnection openCon = new SqlConnection(sqlConnectionstring))
                {
                    string AckowledgeActiveAlarm = "UPDATE ALARMLOG SET Active = 0, AcknowledgeTime = getdate() WHERE AlarmTag = @AlarmTag AND Active = 1";

                    using (SqlCommand queryAddActive = new SqlCommand(AckowledgeActiveAlarm))
                    {
                        queryAddActive.Connection = openCon;
                        queryAddActive.Parameters.Add("@Alarmtag", System.Data.SqlDbType.VarChar, 30).Value = "TT01_HH";
                        openCon.Open();
                        queryAddActive.ExecuteNonQuery();
                        openCon.Close();
                    }
                }



                //
                chkHHActive.Checked = false;
                AlarmActive = false;
            }
        }

        private void btnAckHAlrm_Click(object sender, EventArgs e)
        {
            if (TT01.GetActiveAlarm(1) == 0)
            {
                //Write to SQL here****************************************
                using (SqlConnection openCon = new SqlConnection(sqlConnectionstring))
                {
                    string AckowledgeActiveAlarm = "UPDATE ALARMLOG SET Active = 0, AcknowledgeTime = getdate() WHERE AlarmTag = @AlarmTag AND Active = 1";

                    using (SqlCommand queryAddActive = new SqlCommand(AckowledgeActiveAlarm))
                    {
                        queryAddActive.Connection = openCon;
                        queryAddActive.Parameters.Add("@Alarmtag", System.Data.SqlDbType.VarChar, 30).Value = "TT01_H";
                        openCon.Open();
                        queryAddActive.ExecuteNonQuery();
                        openCon.Close();
                    }
                }

                //
                chkHHActive.Checked = false;
                AlarmActive = false;
            }
        }

        private void btnAckLAlrm_Click(object sender, EventArgs e)
        {
            if (TT01.GetActiveAlarm(2) == 0)
            {
                //Write to SQL here****************************************
                using (SqlConnection openCon = new SqlConnection(sqlConnectionstring))
                {
                    string AckowledgeActiveAlarm = "UPDATE ALARMLOG SET Active = 0, AcknowledgeTime = getdate() WHERE AlarmTag = @AlarmTag AND Active = 1";

                    using (SqlCommand queryAddActive = new SqlCommand(AckowledgeActiveAlarm))
                    {
                        queryAddActive.Connection = openCon;
                        queryAddActive.Parameters.Add("@Alarmtag", System.Data.SqlDbType.VarChar, 30).Value = "TT01_L";
                        openCon.Open();
                        queryAddActive.ExecuteNonQuery();
                        openCon.Close();
                    }
                }

                //
                chkLActive.Checked = false;
                AlarmActive = false;
            }
        }

        private void btnAckLLAlrm_Click(object sender, EventArgs e)
        {
            if (TT01.GetActiveAlarm(3) == 0)
            {
                //Write to SQL here****************************************
                using (SqlConnection openCon = new SqlConnection(sqlConnectionstring))
                {
                    string AckowledgeActiveAlarm = "UPDATE ALARMLOG SET Active = 0, AcknowledgeTime = getdate() WHERE AlarmTag = @AlarmTag AND Active = 1";

                    using (SqlCommand queryAddActive = new SqlCommand(AckowledgeActiveAlarm))
                    {
                        queryAddActive.Connection = openCon;
                        queryAddActive.Parameters.Add("@Alarmtag", System.Data.SqlDbType.VarChar, 30).Value = "TT01_LL";
                        openCon.Open();
                        queryAddActive.ExecuteNonQuery();
                        openCon.Close();
                    }
                }

                //
                chkLLActive.Checked = false;
                AlarmActive = false;
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();

        }
    }
}
