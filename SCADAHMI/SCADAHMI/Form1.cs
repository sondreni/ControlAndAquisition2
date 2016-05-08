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
        string sqlConnectionstring = "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";

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
        PIController pidPopup = new PIController();
        AnalogHMIpopup AnalogPopup = new AnalogHMIpopup();
        #endregion

        public Form1()
        {
            InitializeComponent();
            alarmHist.Hide();
            pidPopup.Hide();
            AnalogPopup.Hide();

        }

        private void btnStartHMI_Click(object sender, EventArgs e)
        {
            tmrHMI.Start();
        }

        private void tmrHMI_Tick(object sender, EventArgs e)
        {
         
            IfActiveAlarm();
            txtValueTemp.Text = TT01.Y.ToString();
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
            if (AnalogPopup.AlarmActive)
            {if (btnOpenAnalogHMI.BackColor == Color.Red)
                {
                    btnOpenAnalogHMI.BackColor = Color.LightGray;
                }
                else {
                    btnOpenAnalogHMI.BackColor = Color.Red;
                }
            }
        }

        private void btnShowAlrmHist_Click(object sender, EventArgs e)
        {
            alarmHist.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpnController_Click(object sender, EventArgs e)
        {
            pidPopup.Show();
            
        }

        private void btnOpenAnalogHMI_Click(object sender, EventArgs e)
        {
            AnalogPopup.Show(); //Show analog sensor settings on button press.
        }
    }
}
