using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments;
using NationalInstruments.DAQmx;

namespace ControlAndAquisition
{
    class NIDAQ
    {

        private string _Connection;
        
        public NIDAQ()
        {

        }
        public NIDAQ(string Connection)
        {
            _Connection = Connection;
        }


        public double Value
        {
            get
            {
                Task analogInTask = new Task();
                AIChannel myAIChannel;
                myAIChannel = analogInTask.AIChannels.CreateVoltageChannel(_Connection, "myAIChannel", AITerminalConfiguration.Rse, 0, 5, AIVoltageUnits.Volts);
                AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);
                double analogDataIn = reader.ReadSingleSample();
                return analogDataIn;
            }
            set
            {
                double analogDataOut = value;
                Task analogOutTask = new Task();
                AOChannel myAOChannel;
                myAOChannel = analogOutTask.AOChannels.CreateVoltageChannel(_Connection, "myAOChannel", 0, 5, AOVoltageUnits.Volts);
                AnalogSingleChannelWriter writer = new
                AnalogSingleChannelWriter(analogOutTask.Stream);

                writer.WriteSingleSample(true, analogDataOut);
            }
        }
        
        


    }
}
