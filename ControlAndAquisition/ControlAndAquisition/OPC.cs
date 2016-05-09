using NationalInstruments.Net;
using System;

namespace ControlAndAquisition
{

    class OPC
    {
        //Generating parameters
        public string opcurl = "opc://localhost/Matrikon.OPC.Simulation.1/Bucket Brigade.";

        DataSocket dataSocket = new DataSocket();
        bool _Write = false;
        double _value;

        public OPC(string tagID) //Constructor generating the OPC URL and creating a read only connection.
        {
            opcurl = opcurl + tagID;
            opcReadConnectSockets();
        }
        public OPC(string tagID, bool write) //Second constructor takes two arguments, if second argument is "true" the opc value is get, set.
        {
            _Write = write;
            opcurl = opcurl + tagID;
            if (write)
            {
                opcWriteConnectSockets();
            }
            else
            {
                opcReadConnectSockets();
            }
        }
        public double Value //Get set code for OPC communication
        {
            get
            {
                return Read();
            }
            set
            {
                Write(value);
            }
        }
        public void opcWriteConnectSockets() //Method for setting OPC communication to write
        {
            if (dataSocket.IsConnected) { dataSocket.Disconnect(); }
            dataSocket.Connect(opcurl, AccessMode.Write);//Connect to OPC
        }
        public void opcReadConnectSockets()//Method for setting OPC communication to read 
        {
            if (dataSocket.IsConnected) { dataSocket.Disconnect(); }
            dataSocket.Connect(opcurl, AccessMode.Read);//Connect to OPC
        }
        public void Write(double value) //Method for writing to OPC
        {
            //Send value to OPC
            dataSocket.Data.Value = value;
            dataSocket.Update();
            //value sent
        }

        public double Read() //Read value from OPC
        {
            if (_Write)//changing to read and back to write again
            {
                opcReadConnectSockets();
                dataSocket.AccessMode.GetType();
                dataSocket.Update();
                _value = Convert.ToDouble(dataSocket.Data.Value);
                opcWriteConnectSockets();

                return _value;
            }
            else
            {
                dataSocket.AccessMode.GetType();
                dataSocket.Update();

                return Convert.ToDouble(dataSocket.Data.Value);
            }
        }
    }
}
