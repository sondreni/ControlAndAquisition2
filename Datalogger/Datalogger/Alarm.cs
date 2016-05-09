using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datalogger
{
    class Alarm
    {
        public string Tag { get; set; }
        public string Time { get; set; }
        public bool Active { get; set; }
        public string AcknowledgeTime { get; set; }
        public string AlarmText { get; set; }

        public bool CheckAlarm(string connectionString, string Alarmtag)
        {
            Alarm Active = new Alarm();
            SqlConnection sqlConnection1 = new SqlConnection();
            sqlConnection1.ConnectionString = connectionString;
            string selectSQL = "SELECT Active, AlarmTag  FROM AlarmLog  WHERE  AlarmTag = 'TT01_HH' AND Active = 1";
            //SELECT AlarmTag, Active FROM AlarmLog  WHERE Active = 1 AND AlarmTag = 'TT01_HH' 
            //SELECT Active, AlarmTag  FROM AlarmLog  WHERE  AlarmTag = 'TT01_HH' AND Active = 1
            //SELECT Active, AlarmTag  FROM AlarmLog  WHERE  AlarmTag = '" + Alarmtag + "' AND Active = 1

            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                bool test= Convert.ToBoolean(dr["Active"]);
                return test;
            }
            else
            {
                return false;
            }


        }

        public List<Alarm> GetSingleAlarm(string connectionString, string Alarmtag)
        {
            List<Alarm> AlarmList = new List<Alarm>();
            SqlConnection sqlConnection1 = new SqlConnection();
            sqlConnection1.ConnectionString = connectionString;
            string selectSQL = "SELECT Top 1 AlarmTag, Time, Active, AlarmText FROM ALARMHISTORY  WHERE Active = 1 AND AlarmTag = '" + Alarmtag + "' ORDER BY Time DESC";
            //SELECT Active, AlarmTag  FROM AlarmLog  WHERE  AlarmTag = '" + Alarmtag + "' AND Active = 1

            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Alarm alarm = new Alarm();
                    alarm.Tag = Convert.ToString(dr["AlarmTag"]);
                    alarm.Time = Convert.ToString(dr["Time"]);
                    alarm.Active = Convert.ToBoolean(dr["Active"]);
                    alarm.AlarmText = dr["AlarmText"].ToString();
                    AlarmList.Add(alarm);
                }
            }



            sqlConnection1.Close();

            return AlarmList;
        }




        public List<Alarm> GetAllAlarms(string connectionString)
        {
            List<Alarm> AlarmList = new List<Alarm>();
            SqlConnection sqlConnection1 = new SqlConnection();
            sqlConnection1.ConnectionString = connectionString;
            string selectSQL = "SELECT Top 1000 AlarmTag, Time, Active, AcknowledgeTime, AlarmText FROM ALARMHISTORY ORDER BY Active DESC,Time DESC";
            

            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, sqlConnection1);
                      
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Alarm alarm = new Alarm();
                    alarm.Tag = Convert.ToString(dr["AlarmTag"]);
                    alarm.Time = Convert.ToString(dr["Time"]);
                    alarm.Active = Convert.ToBoolean(dr["Active"]);
                    alarm.AcknowledgeTime = Convert.ToString(dr["AcknowledgeTime"]);
                    alarm.AlarmText = dr["AlarmText"].ToString();
                    AlarmList.Add(alarm);
                }
            }

            
            
            sqlConnection1.Close();

            return AlarmList;
        }

        public List<Alarm> GetAlarms(string connectionString)
        {
            List<Alarm> AlarmList = new List<Alarm>();
            SqlConnection sqlConnection1 = new SqlConnection();
            sqlConnection1.ConnectionString = connectionString;
            string selectSQL = "SELECT Top 20 AlarmTag, Time, Active, AcknowledgeTime, AlarmText FROM ALARMHISTORY  WHERE Active = 1 ORDER BY Time DESC";


            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Alarm alarm = new Alarm();
                    alarm.Tag = Convert.ToString(dr["AlarmTag"]);
                    alarm.Time = Convert.ToString(dr["Time"]);
                    alarm.Active = Convert.ToBoolean(dr["Active"]);
                    alarm.AcknowledgeTime = Convert.ToString(dr["AcknowledgeTime"]);
                    alarm.AlarmText = dr["AlarmText"].ToString();
                    AlarmList.Add(alarm);
                }
            }



            sqlConnection1.Close();

            return AlarmList;
        }


    }
}
