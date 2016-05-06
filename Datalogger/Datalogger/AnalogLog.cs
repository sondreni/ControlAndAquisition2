using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlAndAquisition;

namespace Datalogger
{
    class AnalogLog
    {
        public string Tag { get; }
        string[] Alarms = { "HH", "H", "L", "LL" };
        OPC[] Alarm;
        OPC OPC_PV;
        Alarm ActiveAlarms;

        public AnalogLog(string TAG)
        {
            Tag = TAG;
            OPC_PV = new OPC(Tag + "_PV");

            for(int i = 0; i < Alarm.Length; i++)
            {
                Alarm[i] = new OPC(Tag + Alarms[i]);
            }

        }



        public void Update()
        {
            
        }

        private void CheckAlarms()
        {
            for (int i = 0; i < Alarm.Length; i++)
            {
                if(Alarm[i].Read()==1)
                {

                }
            }
        }


    }
}
