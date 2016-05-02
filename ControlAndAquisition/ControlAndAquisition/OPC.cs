using NationalInstruments.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControlAndAquisition
{
    class OPC
    {
        public string opcurl = "opc://localhost/Matrikon.OPC.Simulation.1/Bucket Brigade.";

        DataSocket dataSocket = new DataSocket();
        bool _Write = false;
        double _value;

        public OPC(string tagID)
        {
            opcurl = opcurl + tagID;
            opcReadConnectSockets();
        }
        public OPC(string tagID, bool write)
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

        public void opcWriteConnectSockets()
        {
            if (dataSocket.IsConnected) { dataSocket.Disconnect(); }
            dataSocket.Connect(opcurl, AccessMode.Write);//Connect to OPC
        }


        public void opcReadConnectSockets()
        {
            if (dataSocket.IsConnected) { dataSocket.Disconnect(); }
            dataSocket.Connect(opcurl, AccessMode.Read);//Connect to OPC

        }

        public void Write(double value)
        {
            //Send value to OPC

            dataSocket.Data.Value = value;
            dataSocket.Update();
            //value value sent

        }

        public double Read() //Get value from OPC
        {
            if (_Write)
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
            //Read from OPC




        }
    }
}
