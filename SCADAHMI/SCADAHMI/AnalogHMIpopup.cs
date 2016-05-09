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
using ControlAndAquisition;
using Datalogger;

namespace SCADAHMI
{
    public partial class AnalogHMIpopup : Form
    {
        //Create variables.
        public string TagID { get; }
        string[] Alarms = { "HH", "H", "L", "LL" };
        OPC[] Alarm;
        OPC[] AlarmLimits;
        OPC OPC_PV;
        OPC OPC_R;
        OPC OPC_U;

        bool ActiveAlarm = false;

        public double time;
        public double Y;
        public double U;
        public double R;
        public bool AlarmActive;/***Test****/
        string sqlConnectionstring = "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";




        public AnalogHMIpopup(string SensorTag, string ControllerTAG)
        {
            InitializeComponent();
            TagID = SensorTag;
            InitializeCharts();

            Alarm = new OPC[Alarms.Length];
            AlarmLimits = new OPC[Alarms.Length];
            for (int i = 0; i < Alarms.Length; i++)
            {
                Alarm[i] = new OPC(TagID + "_" + Alarms[i]);
                AlarmLimits[i] = new OPC(TagID + "_" + Alarms[i] + "_Lim", true);
            }
            OPC_PV = new OPC(TagID + "_PV");
            OPC_R = new OPC(ControllerTAG + "_R");
            OPC_U = new OPC(ControllerTAG + "_U");
        }

        private void InitializeCharts()
        {

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
            Y = OPC_PV.Value;
            R = OPC_R.Value;
            U = OPC_U.Value;
            txtValueTemp.Text = Y.ToString();

            chart2.Series["u"].Points.AddXY(time, U);
            chart1.Series["°C"].Points.AddXY(time, Y);
            chart1.Series["r"].Points.AddXY(time, R);
            chart1.ResetAutoValues();
            chart2.ResetAutoValues();


        }//Executes charting


        private bool GetDBAlarm(string AlarmTag)
        {

            List<Alarm> AlarmList = new List<Alarm>();
            Alarm Alarmvalue = new Alarm();

            AlarmList = Alarmvalue.GetSingleAlarm(sqlConnectionstring, TagID + "_" + AlarmTag);


            if (AlarmList.Count > 0)
            {
                ActiveAlarm = AlarmList[0].Active;
            }
            else
            {
                ActiveAlarm = false;
            }

            return ActiveAlarm;
        }


        private void CheckActiveAlarms()
        {
            chkHHActive.Checked = GetDBAlarm("HH");
            chkHActive.Checked = GetDBAlarm("H");
            chkLActive.Checked = GetDBAlarm("L");
            chkLLActive.Checked = GetDBAlarm("LL");
        }
        private void AnalogHMIpopup_Load(object sender, EventArgs e)
        {


            #region Initialize Limits
            txtHHLim.Text = "30";
            txtHLim.Text = "28";
            txtLLim.Text = "22";
            txtLLLim.Text = "20";

            UpdateLims();
            #endregion
        }

        private void tmrAnalogHMIpopup_Tick(object sender, EventArgs e)
        {

            
        }

        public void Updat()
        {

            DoCharting();
            txtValueTemp.Text = OPC_PV.Value.ToString();
            CheckActiveAlarms();



        }

        private void UpdateLims()
        {
            #region Check if Limits are Numeric and send to OPC
            string HH_Lim = txtHHLim.Text;
            string H_Lim = txtHLim.Text;
            string L_Lim = txtLLim.Text;
            string LL_Lim = txtLLLim.Text;
            double HHLim;
            double HLim;
            double LLim;
            double LLLim;

            
            bool isNumeric = double.TryParse(HH_Lim, out HHLim);
            if (isNumeric)
            {
                HHLim = Convert.ToDouble(HH_Lim);
                AlarmLimits[0].Value = HHLim;

            }
            else
            {
                MessageBox.Show("High High Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(H_Lim, out HLim);
            if (isNumeric)
            {
                HLim = Convert.ToDouble(H_Lim);
                AlarmLimits[1].Value = HLim;

            }
            else
            {
                MessageBox.Show("High Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(L_Lim, out LLim);
            if (isNumeric)
            {
                LLim = Convert.ToDouble(L_Lim);
                AlarmLimits[2].Value = LLim;

            }
            else
            {
                MessageBox.Show("Low Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(LL_Lim, out LLLim);
            if (isNumeric)
            {
                LLLim = Convert.ToDouble(LL_Lim);
                AlarmLimits[3].Value = LLLim;

            }
            else
            {
                MessageBox.Show("Low Low Limit must be a numeric value.", "SCADA HMI");
            }
            #endregion
        }


        private void btnUpdateLim_Click(object sender, EventArgs e)
        {
            UpdateLims();



        }

        private void btnAckHHAlrm_Click(object sender, EventArgs e)
        {
            
            if (chkHHActive.Checked)
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
            if (chkHActive.Checked)
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
            if (chkLActive.Checked)
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
            if (chkLLActive.Checked)
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
