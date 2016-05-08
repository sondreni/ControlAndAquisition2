﻿using ControlAndAquisition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCADAHMI
{

    class AnalogHMI
    {
        double HHLim;
        double HLim;
        double LLim;
        double LLLim;

        string[] alarms = { "_HH", "_H", "_L", "_LL" };
        OPC[] AllAlarms;
        OPC[] AlarmLims;


        OPC opcY;


        public AnalogHMI(string SensorTag)
        {
            AlarmLims = new OPC[alarms.Length];
            AllAlarms = new OPC[alarms.Length];
            #region Initialize OPC communication
            for (int i=0; i<alarms.Length ; i++)
            {
                AlarmLims[i] = new OPC(SensorTag + alarms[i] + "_Lim", true);//0=HH,1=H,2=L,3=LL
            }

            for (int i = 0; i < alarms.Length; i++)
            {
                AllAlarms[i] = new OPC(SensorTag + alarms[i]);//0=HH,1=H,2=L,3=LL
            }
            opcY = new OPC(SensorTag + "_PV");
            
            #endregion
        }

        public double GetActiveAlarm(int i) //0=HH,1=H,2=L,3=LL
        {
            return AllAlarms[i].Value;
        }

        public double Y //Get Y
        {
            get
            {

                return opcY.Value;
            }
        }

        public void UpdateLim(string HH_Lim, string H_Lim, string L_Lim, string LL_Lim)
        {
            #region Check if Limits are Numeric and send to OPC
            bool isNumeric = double.TryParse(HH_Lim, out HHLim);
            if (isNumeric)
            {
                HHLim = Convert.ToDouble(HH_Lim);
                AlarmLims[0].Value = HHLim;
                
            }
            else
            {
                MessageBox.Show("High High Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(H_Lim, out HLim);
            if (isNumeric)
            {
                HLim = Convert.ToDouble(H_Lim);
                AlarmLims[1].Value = HLim;
                
            }
            else
            {
                MessageBox.Show("High Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(L_Lim, out LLim);
            if (isNumeric)
            {
                LLim = Convert.ToDouble(L_Lim);
                AlarmLims[2].Value = LLim;
                
            }
            else
            {
                MessageBox.Show("Low Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(LL_Lim, out LLLim);
            if (isNumeric)
            {
                LLLim = Convert.ToDouble(LL_Lim);
                AlarmLims[3].Value = LLLim;
                
            }
            else
            {
                MessageBox.Show("Low Low Limit must be a numeric value.", "SCADA HMI");
            }
            #endregion

        }

    }
}
