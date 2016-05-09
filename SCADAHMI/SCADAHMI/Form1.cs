using Datalogger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace SCADAHMI
{
    public partial class Form1 : Form
    {
        string sqlConnectionstring = "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";

        PIDhmi PID01 = new PIDhmi("PID01");//Sending the PID01 tag to the PIDhmi constructor
        AnalogHMI TT01 = new AnalogHMI("TT01","PID01");//The AnalogHMI class contains plotting of the PID in the popup so both the TT01 tag and PID01 tag is needed.

        #region Initialize SQL Alarm Communication
        Alarm alarms = new Alarm();//Creating an alarm object to get active non acknowledeged alarms
        #endregion

        #region Initialize parameters
        AlarmHistory alarmHist = new AlarmHistory();
        PIController pidPopup = new PIController();
        
        #endregion

        public Form1()
        {
            InitializeComponent();
            alarmHist.Hide();
            pidPopup.Hide();
        }


        private void tmrHMI_Tick(object sender, EventArgs e)
        {
            IfActiveAlarm();
            TT01.Update();
            lblTT01Alarm.Text = TT01.ActiveAlarm();
            txtValueTemp.Text = TT01.PV.ToString();
            txtSetPoint.Text = PID01.R.ToString();
            txtU.Text = PID01.U.ToString();
            LoadActiveAlarms();
        }
        

        private void LoadActiveAlarms()
        {
            List<Alarm> AlarmList = new List<Alarm>();
            Alarm Alarmvalue = new Alarm();
            AlarmList = Alarmvalue.GetAlarms(sqlConnectionstring);
            gridAlarms.DataSource = AlarmList;
            gridAlarms.AutoResizeColumns();
        }


        public void IfActiveAlarm()
        {
            if (TT01.ActiveAlarm() !="")
            {if (btnOpenAnalogHMI.BackColor == Color.Red)
                {
                    btnOpenAnalogHMI.BackColor = Color.LightGray;
                }
                else {
                    btnOpenAnalogHMI.BackColor = Color.Red;
                }
            }
            else
            {
                btnOpenAnalogHMI.BackColor = Color.LightGray;
            }
        }

        private void btnShowAlrmHist_Click(object sender, EventArgs e)
        {
            alarmHist.ShowDialog();
            alarmHist.FreshHistory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrHMI.Start();
        }

        private void btnOpnController_Click(object sender, EventArgs e)
        {
            pidPopup.Show();
            pidPopup.TopMost = true;
        }

        private void btnOpenAnalogHMI_Click(object sender, EventArgs e)
        {
            TT01.AnalogPopup.Show(); //Show analog sensor settings on button press.
        }
    }
}
