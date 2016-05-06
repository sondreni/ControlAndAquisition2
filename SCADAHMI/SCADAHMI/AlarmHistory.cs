using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCADAHMI
{
    public partial class AlarmHistory : Form
    {
        AnalogHMI TT01 = new AnalogHMI("TT01");  //Construct TT01
        public AlarmHistory()
        {
            InitializeComponent();

            #region Initialize Limits
            txtHHLim.Text = "30";
            txtHLim.Text = "28";
            txtLLim.Text = "22";
            txtLLLim.Text = "20";

            TT01.UpdateLim(txtHHLim.Text, txtHLim.Text, txtLLim.Text, txtLLLim.Text);
            #endregion
        }
    }
}
