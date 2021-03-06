﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datalogger;

namespace SCADAHMI
{
    public partial class AlarmHistory : Form
    {
        string SQLConnectionString = "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";

        public AlarmHistory()
        {
            InitializeComponent();
            FreshHistory();



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FreshHistory();
        }

        public void FreshHistory()
        {
            List<Alarm> AlarmList = new List<Alarm>();
            Alarm Alarmvalue = new Alarm();

            AlarmList = Alarmvalue.GetAllAlarms(SQLConnectionString);

            gridAlarmHistory.DataSource = AlarmList;
            gridAlarmHistory.AutoResizeColumns();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();

        }
    }
}
