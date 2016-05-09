using ControlAndAquisition;

namespace SCADAHMI
{

    class AnalogHMI
    {


        string[] alarms = { "_HH", "_H", "_L", "_LL" };
        OPC[] AllAlarms;

        public AnalogHMIpopup AnalogPopup; 

        OPC OPC_PV;


        public AnalogHMI(string SensorTag,string ControllerTag)
        {

            AllAlarms = new OPC[alarms.Length];

            AnalogPopup = new AnalogHMIpopup(SensorTag, ControllerTag);
            AnalogPopup.Hide();


            #region Initialize OPC communication
            
            for (int i = 0; i < alarms.Length; i++)
            {
                AllAlarms[i] = new OPC(SensorTag + alarms[i]);//0=HH,1=H,2=L,3=LL
            }
            OPC_PV = new OPC(SensorTag + "_PV");
            
            #endregion
        }


        public string ActiveAlarm()
        {
            string Active = "";

            if (AllAlarms[1].Value == 1) { Active = "H"; }
            if (AllAlarms[2].Value == 1) { Active = "L"; }
            if (AllAlarms[3].Value == 1) { Active = "LL"; }
            if (AllAlarms[0].Value == 1) { Active = "HH"; }

            return Active;
        }




        public double PV
        {
            get
            {
                return OPC_PV.Value;
            }
        }



        public double GetActiveAlarm(int i) //0=HH,1=H,2=L,3=LL
        {
            return AllAlarms[i].Value;
        }
        public void Update()
        {
            AnalogPopup.Updat();
        }
        

    }
}
