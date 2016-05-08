using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlAndAquisition;
using System.Data.SqlClient;
using (SqlConnection openCon = new SqlConnection(DatabaseConnection));
namespace Datalogger
{
    class AnalogLog
    {
        public string Tag { get; }
        string[] Alarms = { "HH", "H", "L", "LL" };
        OPC[] Alarm;
        OPC OPC_PV;
        bool ActiveAlarm = false;
        string DatabaseConnection;


        public AnalogLog(string TAG,string DatabaseConnectionString)
        {
            Tag = TAG;
            DatabaseConnection = DatabaseConnectionString;
            OPC_PV = new OPC(Tag + "_PV");
            Alarm = new OPC[Alarms.Length];
            for(int i = 0; i < Alarms.Length; i++)
            {
                Alarm[i] = new OPC(Tag +"_"+ Alarms[i]);
            }
            
        }



        public void Update()
        {
            CheckAlarms();
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


                //List<TempValue> TempValueList = new List<TempValue>();
                //TempValue tempValue = new TempValue();

                //TempValueList = tempValue.GetTempValue(connectionString);
            }

        }

        private void SetAlarm(string Alarm)
        {

            
            {
                string NewActiveAlarm = "INSERT INTO AlarmLog (Time,Active,AlarmTag) VALUES (getdate(),1,@Alarmtag)";

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
        private void LogTemp()
        {
            using (SqlConnection openCon = new SqlConnection(DatabaseConnection))
            {
                string NewActiveAlarm = "INSERT INTO AlarmLog (Time,Active,AlarmTag) VALUES (getdate(),1,@Alarmtag)";

                using (SqlCommand queryAddActive = new SqlCommand(NewActiveAlarm))
                {
                    queryAddActive.Connection = openCon;
                    queryAddActive.Parameters.Add("@Alarmtag", System.Data.SqlDbType.VarChar, 30).Value = Tag + "_" + Alarm;
                    openCon.Open();
                    queryAddActive.ExecuteNonQuery();
                    openCon.Close();
                }
            }

        }


    }
}
