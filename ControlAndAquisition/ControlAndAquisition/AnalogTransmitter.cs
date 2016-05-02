using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAndAquisition
{
    class AnalogTransmitter
    {
        private string TAG;
        private double _PV;
        private OPC OPC_PV;
        private string[] Alarms = { "HH", "H", "L", "LL" };
        private OPC[] Alarm;
        private OPC[] AlarmLim;
        private double HYS = 1;
        private NIDAQ Read;
        private NIDAQ Write;
        LowPassFilter Filter;


        public AnalogTransmitter(string TagID, double Timestep)
        {
            TAG = TagID;
            OPC_PV = new OPC(TagID + "_PV", true);
            Alarm = new OPC[Alarms.Length];
            AlarmLim = new OPC[Alarms.Length];
            Filter = new LowPassFilter(Timestep);
            

            for (int i = 0; i < Alarms.Length; i++)
            {
                Alarm[i] = new OPC(TAG + "_" + Alarms[i], true);
                AlarmLim[i] = new OPC(TAG + "_" + Alarms[i] + "_Lim");
            }


        }
        public AnalogTransmitter(string TagID, string NIDAQConnect_PV,double Timestep) : this(TagID,Timestep)
        {
            Read = new NIDAQ(NIDAQConnect_PV);
            
        }
        public AnalogTransmitter(string TagID, string NIDAQConnect_PV, double Timestep,bool write) : this(TagID,Timestep)
        {
            Write = new NIDAQ(NIDAQConnect_PV);
        }

        public void Update()
        {
            _PV = Filter.FilterValue((Read.Value-1)*50/4);

            UpdateAlarms();
            OPC_PV.Write(_PV);
        }
        public void Update(double NewPV)
        {
            _PV = Filter.FilterValue(NewPV);
            UpdateAlarms();
            OPC_PV.Write(_PV);
        }
        public void Update(double NewPV, bool write)
        {
            Write.Value = ((NewPV*4/50)+1);
            Update(NewPV);
        }
        public double PV
        {
            get
            {
                return _PV;
            }
            set
            {
                _PV = value;
            }
        }


        private void UpdateAlarms()
        {
            for (int i = 0; i < Alarms.Length; i++)
            {
                if (Alarm[i].Read() == 1)
                {
                    if (Alarms[i] == "HH" || Alarms[i] == "H")
                    {
                        if ((_PV + HYS) < AlarmLim[i].Read())
                        {
                            Alarm[i].Write(0);
                        }
                    }
                    if (Alarms[i] == "LL" || Alarms[i] == "L")
                    {
                        if ((_PV - HYS) > AlarmLim[i].Read())
                        {
                            Alarm[i].Write(0);
                        }
                    }
                }
                else
                {
                    if (Alarms[i] == "HH" || Alarms[i] == "H")
                    {
                        if ((_PV) > AlarmLim[i].Read())
                        {
                            Alarm[i].Write(1);
                        }
                    }
                    if (Alarms[i] == "LL" || Alarms[i] == "L")
                    {
                        if ((_PV) < AlarmLim[i].Read())
                        {
                            Alarm[i].Write(1);
                        }
                    }
                }

            }
        }

    }
}
