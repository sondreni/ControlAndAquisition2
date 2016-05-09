namespace ControlAndAquisition
{
    class FUJIPID
    {
        OPC OPC_R;
        OPC OPC_U;//Communication with the OPC server for sending the control signal and reciving the reference
        NIDAQ NI_R;
        NIDAQ NI_U;//Communication out with the Fuji controller
        NIDAQ NI_PV;

        public FUJIPID(string OPCTag, string NIDAQConnect_U, string NIDAQConnect_PV) //Constructor with overloading for different simulator/real process 
        {
            OPC_U = new OPC(OPCTag + "_U", true);
            OPC_R = new OPC(OPCTag + "_R");

            NI_U = new NIDAQ(NIDAQConnect_U);
            NI_PV = new NIDAQ(NIDAQConnect_PV);
        }

        public FUJIPID(string OPCTag, string NIDAQConnect_U, string NIDAQConnect_PV,string NIDAQConnect_R) : this(OPCTag, NIDAQConnect_U, NIDAQConnect_PV)
        {
            NI_R = new NIDAQ(NIDAQConnect_R);
        }

        public void Update()//For real processs
        {
            NI_R.Value= (OPC_R.Read()*4/50+1);
            OPC_U.Write(NI_U.Value);
        }
        public double Update(double PV)//For simulator
        {
            NI_PV.Value = ((PV*4/50)+1);
            PV = NI_U.Value;
            OPC_U.Write(PV);
            return PV;
        }
    }
}
