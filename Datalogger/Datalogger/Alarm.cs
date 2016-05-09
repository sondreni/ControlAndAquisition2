using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datalogger
{
    class Alarm
    {
        //Creating parameters
        public string Tag { get; set; }
        public string Time { get; set; }
        public bool Active { get; set; }
        public string AcknowledgeTime { get; set; }
        public string AlarmText { get; set; }

        public List<Alarm> GetSingleAlarm(string connectionString, string Alarmtag) //Method for getting most recent active alarm from SQL database
        {
            List<Alarm> AlarmList = new List<Alarm>();
            SqlConnection sqlConnection1 = new SqlConnection();
            sqlConnection1.ConnectionString = connectionString;
            string selectSQL = "SELECT Top 1 AlarmTag, Time, Active, AlarmText FROM ALARMHISTORY  WHERE Active = 1 AND AlarmTag = '" + Alarmtag + "' ORDER BY Time DESC"; // SQL query

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

        public List<Alarm> GetAllAlarms(string connectionString) //Method for getting alarm history from SQL database
        {
            List<Alarm> AlarmList = new List<Alarm>();//Creates list for holding all alarms in alarm history
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

                    //Writing alarm information to string variables
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

        public List<Alarm> GetAlarms(string connectionString) //Gets active alarms
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

                    //Writing alarm information to string variables
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
