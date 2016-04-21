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
        public string opcurlY = "opc://localhost/Matrikon.OPC.Simulation.1/Bucket Brigade.y";
        public string opcurlU = "opc://localhost/Matrikon.OPC.Simulation.1/Bucket Brigade.u";
        public string opcurlR = "opc://localhost/Matrikon.OPC.Simulation.1/Bucket Brigade.r";
       

        DataSocket dataSocketY = new DataSocket();
        DataSocket dataSocketU = new DataSocket();
        DataSocket dataSocketR = new DataSocket();

        public void opcConnectSockets()
        {
            if (dataSocketY.IsConnected)
            { dataSocketY.Disconnect(); }
            dataSocketY.Connect(opcurlY, AccessMode.Write);//Connect Y

            if (dataSocketU.IsConnected)
            { dataSocketU.Disconnect(); }
            dataSocketU.Connect(opcurlU, AccessMode.Write);//Connect U

            if (dataSocketR.IsConnected)
            { dataSocketR.Disconnect(); }
            dataSocketR.Connect(opcurlR, AccessMode.Read);//Connect R
        }

        public void opcSendData(double opcY, double opcU)
        {
            //Send Y value to OPC
            dataSocketY.Data.Value = opcY;
            dataSocketY.Update();
            //Y value sent

            //Send U value to OPC
            dataSocketU.Data.Value = opcU;
            dataSocketU.Update();
            //U value sent
        }

        public double opcGetRef() //Get reference value from OPC
        {
            //Read reference from OPC
            dataSocketR.Update();
            return Convert.ToDouble(dataSocketR.Data.Value);
            
            //Ref has been read
        }
    }
}
