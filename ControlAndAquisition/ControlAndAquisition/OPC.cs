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
        
        
        public OPC(string tagID)
        {
            opcurl = opcurl + tagID;
            opcConnectSockets();
        }
        

        private void opcConnectSockets()
        {
            if (dataSocket.IsConnected) { dataSocket.Disconnect(); }
            dataSocket.Connect(opcurl, AccessMode.Write);//Connect to OPC
                        
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
            //Read from OPC
            dataSocket.Update();
            return Convert.ToDouble(dataSocket.Data.Value);
            
        }
    }
}
