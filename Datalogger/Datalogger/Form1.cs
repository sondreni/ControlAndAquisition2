using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ControlAndAquisition;

namespace Datalogger
{
    public partial class Form1 : Form
    {
        double r = 0;
        double y = 0;
        double u = 0;
        OPC uOPC;
        OPC yOPC;
        OPC rOPC;

        OPC HHOPC;
        OPC HOPC;
        OPC LOPC;
        OPC LLOPC;

        bool DBHH;
        bool DBH;
        bool DBL;
        bool DBLL;




        SqlConnection sqlConnection1 = new SqlConnection();
        string SQLConnectionString= "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";

        SqlCommand cmd = new SqlCommand();
            


        public Form1()
        {
            InitializeComponent();
            uOPC = new OPC("u");
            yOPC = new OPC("y");
            rOPC = new OPC("r");

            HHOPC = new OPC("HH");
            HOPC = new OPC("H");
            LOPC = new OPC("L");
            LLOPC = new OPC("LL");



            trmUpdate.Enabled = true;
            sqlConnection1.ConnectionString = SQLConnectionString;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }
        private void getData()
        {
            y = yOPC.Read();
            u = uOPC.Read();
            r = rOPC.Read();
        }

        private void WriteLogValues()
        {


            //PROVIDER=SQLOLEDB;DATA SOURCE=SONDRES\CITADEL;UID=Sondre;PWD=;DATABASE=SensorDatabase2
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT Templog (Time, y,r,u) VALUES (getdate(),@y,@r,@u)";
            cmd.Parameters.AddWithValue("@y", y);
            cmd.Parameters.AddWithValue("@r", r);
            cmd.Parameters.AddWithValue("@u", u);
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }


        private void CheckAlarms()
        {
            List<Alarm> AlarmList = new List<Alarm>();
            Alarm alarm = new Alarm();

            AlarmList = alarm.GetAlarms(SQLConnectionString);
            gridAlarms.DataSource = AlarmList;
            
            DBHH = false;
            DBH = false;
            DBL = false;
            DBLL = false;
            
            for(int i=0; i< AlarmList.Count; i++)
            {
                switch (AlarmList[i].Tag)
                {
                    case "HH":
                        DBHH = true;
                        break;
                    case "H":
                        DBH = true;
                        break;
                    case "L":
                        DBL = true;
                        break;
                    case "LL":
                        DBLL = true;
                        break;

                }
                
            }
                        
        }
        private void CheckOPCAlarms()
        {
            if (HHOPC.Read() == 1 && DBHH == false)
            {
                SetAlarm("HH");
            }
            if (HOPC.Read() == 1 && DBH == false)
            {
                SetAlarm("H");
            }
            if (LOPC.Read() == 1 && DBL == false)
            {
                SetAlarm("L");
            }
            if (LLOPC.Read() == 1 && DBLL == false)
            {
                SetAlarm("LL");
            }
        }
        private void SetAlarm(string tag)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT AlarmLog (Time, Active,AlarmTag) VALUES (getdate(),@Active,@Tag)";
            cmd.Parameters.AddWithValue("@Active", 1);
            cmd.Parameters.AddWithValue("@Tag", tag);
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
            WriteLogValues();

        }

        private void trmUpdate_Tick(object sender, EventArgs e)
        {
            CheckAlarms();
            CheckOPCAlarms();
        }
    }
}
