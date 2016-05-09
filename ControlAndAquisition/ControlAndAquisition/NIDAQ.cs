
using NationalInstruments.DAQmx;

namespace ControlAndAquisition
{
    class NIDAQ
    {

        private string _Connection;
        
        public NIDAQ(string Connection)//Nidaq for communication with fuji PID controller and airheater.
        {
            _Connection = Connection;//Connection string for selecting the Device and port
        }


        public double Value//Using Get/Set for communication
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
