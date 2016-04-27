using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAndAquisition
{
    class Alarm
    {
        string _AlarmType;
        OPC ALRM;
        OPC ALRMLim;

        public Alarm(string AlarmType)
        {
            _AlarmType = AlarmType;
            ALRM = new OPC(AlarmType,true);
            ALRMLim = new OPC(AlarmType+"Lim");
        }
        
        
        public void IsAlarm(double Value)
        {
            switch (_AlarmType)
            {
                case "HH":
                    if (Value > ALRMLim.Read())
                    {
                        ALRM.Write(1);
                    }
                    else { ALRM.Write(0); }
                    break;

                case "H":
                    if (Value > ALRMLim.Read())
                    {
                        ALRM.Write(1);
                    }
                    else { ALRM.Write(0); }
                    break;

                case "LL":
                    if (Value < ALRMLim.Read())
                    {
                        ALRM.Write(1);
                    }
                    else { ALRM.Write(0); }
                    break;

                case "L":
                    if (Value < ALRMLim.Read()) 
                    {
                        ALRM.Write(1);
                    }
                    else { ALRM.Write(0); }
                    break;

            }
            
        }
    }
}
