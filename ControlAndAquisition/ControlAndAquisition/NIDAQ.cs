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
        public NIDAQ()
        {

        }

        public double GetValue()
        {
            Task analogInTask = new Task();
            AIChannel myAIChannel;
            myAIChannel = analogInTask.AIChannels.CreateVoltageChannel("dev1/ai0", "myAIChannel", AITerminalConfiguration.Rse, 0, 5, AIVoltageUnits.Volts);
            AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);
            double analogDataIn = reader.ReadSingleSample();
            return analogDataIn;
        }
        









    }
}
