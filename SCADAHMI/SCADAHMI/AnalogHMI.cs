using ControlAndAquisition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCADAHMI
{
    class AnalogHMI
    {
        double HHLim;
        double HLim;
        double LLim;
        double LLLim;
        double Y;

        OPC opcY;
        OPC opcHHLim;
        OPC opcHLim;
        OPC opcLLim;
        OPC opcLLLim;
        public AnalogHMI(string SensorTag)
        {
            #region Initialize OPC communication
            opcY = new OPC(SensorTag + "_PV");
            opcHHLim = new OPC(SensorTag + "_HH_Lim", true);
            opcHLim = new OPC(SensorTag + "_H_Lim", true);
            opcLLim = new OPC(SensorTag + "_L_Lim", true);
            opcLLLim = new OPC(SensorTag + "_LL_Lim", true);
            #endregion

           
        }

        public double ReadY()
        {
            Y = opcY.Read();
            return Y;
        }

        public void UpdateLim(string HH_Lim,string H_Lim, string L_Lim,string LL_Lim)
        {
            #region Check if Limits are Numeric and send to OPC
            bool isNumeric = double.TryParse(HH_Lim, out HHLim);
            if (isNumeric)
            {
                HHLim = Convert.ToDouble(HH_Lim);
                opcHHLim.Write(HHLim);
            }
            else
            {
                MessageBox.Show("High High Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(H_Lim, out HLim);
            if (isNumeric)
            {
                HLim = Convert.ToDouble(H_Lim);
                opcHLim.Write(HLim);
            }
            else
            {
                MessageBox.Show("High Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(L_Lim, out LLim);
            if (isNumeric)
            {
                LLim = Convert.ToDouble(L_Lim);
                opcLLim.Write(LLim);
            }
            else
            {
                MessageBox.Show("Low Limit must be a numeric value.", "SCADA HMI");
            }

            isNumeric = double.TryParse(LL_Lim, out LLLim);
            if (isNumeric)
            {
                LLLim = Convert.ToDouble(LL_Lim);
                opcLLLim.Write(LLLim);
            }
            else
            {
                MessageBox.Show("Low Low Limit must be a numeric value.", "SCADA HMI");
            }
            #endregion
        }
    }
}
