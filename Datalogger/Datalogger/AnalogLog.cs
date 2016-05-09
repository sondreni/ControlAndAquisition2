using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlAndAquisition;
using System.Data.SqlClient;

namespace Datalogger
{
    class AnalogLog
    {
        public string Tag { get; }
        string[] Alarms = { "HH", "H", "L", "LL" };
        OPC[] Alarm;
        OPC OPC_PV;
        OPC OPC_R;
        OPC OPC_U;
        bool withPID = false;

        bool ActiveAlarm = false;
        string DatabaseConnection;

        public AnalogLog(string TransmitterTAG,string DatabaseConnectionString, string ControllerTAG)
        {
            Tag = TransmitterTAG;
            DatabaseConnection = DatabaseConnectionString;
            OPC_PV = new OPC(Tag + "_PV");
            OPC_R = new OPC(ControllerTAG + "_R");
            OPC_U = new OPC(ControllerTAG + "_U");

            Alarm = new OPC[Alarms.Length];
            for(int i = 0; i < Alarms.Length; i++)
            {
                Alarm[i] = new OPC(Tag +"_"+ Alarms[i]);
            }

            withPID = true;

        }

        public AnalogLog(string TransmitterTAG, string DatabaseConnectionString)
        {
            Tag = TransmitterTAG;
            DatabaseConnection = DatabaseConnectionString;
            OPC_PV = new OPC(Tag + "_PV");
            

            Alarm = new OPC[Alarms.Length];
            for (int i = 0; i < Alarms.Length; i++)
            {
                Alarm[i] = new OPC(Tag + "_" + Alarms[i]);
            }

            

        }



        public void Update()
        {
            CheckAlarms();
            if (withPID)
            {
                LogTempPID();
            }
            else
            {
                LogTemp();
            }

        }





        private void CheckAlarms()
        {
            for (int i = 0; i < Alarm.Length; i++)
            {

                List<Alarm> AlarmList = new List<Alarm>();
                Alarm Alarmvalue = new Alarm();

                AlarmList = Alarmvalue.GetSingleAlarm(DatabaseConnection, Tag + "_" + Alarms[i]);

                
                if (AlarmList.Count > 0)
                {
                    ActiveAlarm = AlarmList[0].Active;
                }
                else
                {
                    ActiveAlarm = false;
                }

                if(Alarm[i].Value==1 && ActiveAlarm == false)
                {
                    SetAlarm(Alarms[i]);
                }

                
            }

        }


        private void SetAlarm(string Alarm)
        {

            using (SqlConnection openCon = new SqlConnection(DatabaseConnection))
            {
                string NewActiveAlarm = "INSERT INTO ALARMLOG (Time,Active,AlarmTag) VALUES (getdate(),1,@Alarmtag)";

                using (SqlCommand queryAddActive = new SqlCommand(NewActiveAlarm))
                {
                    queryAddActive.Connection = openCon;
                    queryAddActive.Parameters.Add("@Alarmtag", System.Data.SqlDbType.VarChar, 30).Value = Tag+"_"+Alarm;
                    openCon.Open();
                    queryAddActive.ExecuteNonQuery();
                    openCon.Close();
                }
            }


        }
        private void LogTempPID()
        {
            using (SqlConnection openCon = new SqlConnection(DatabaseConnection))
            {
                string NewActiveAlarm = "INSERT INTO TEMPERATURELOG (Time,TT01_PV,PID01_R,PID01_U) VALUES (getdate(),@PV,@R,@U)";

                using (SqlCommand queryAddActive = new SqlCommand(NewActiveAlarm))
                {
                    queryAddActive.Connection = openCon;
                    queryAddActive.Parameters.Add("@PV", System.Data.SqlDbType.Float, 30).Value = OPC_PV.Value;
                    queryAddActive.Parameters.Add("@R", System.Data.SqlDbType.Float, 30).Value = OPC_R.Value;
                    queryAddActive.Parameters.Add("@U", System.Data.SqlDbType.Float, 30).Value = OPC_U.Value;
                    openCon.Open();
                    queryAddActive.ExecuteNonQuery();
                    openCon.Close();
                }
            }

        }
        private void LogTemp()
        {
            using (SqlConnection openCon = new SqlConnection(DatabaseConnection))
            {
                string NewActiveAlarm = "INSERT INTO TEMPLOG (Time,TT01_PV) VALUES (getdate(),@PV)";

                using (SqlCommand queryAddActive = new SqlCommand(NewActiveAlarm))
                {
                    queryAddActive.Connection = openCon;
                    queryAddActive.Parameters.Add("@PV", System.Data.SqlDbType.Float, 30).Value = OPC_PV.Value;
                    
                    openCon.Open();
                    queryAddActive.ExecuteNonQuery();
                    openCon.Close();
                }
            }

        }


    }
}
