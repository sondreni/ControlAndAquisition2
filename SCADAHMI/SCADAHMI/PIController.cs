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
    public partial class PIController : Form
    {
        double R;
        PIDhmi PID01 = new PIDhmi("PID01");

        public PIController()
        {
            InitializeComponent();


        }

        private void btnUpdateSetPoint_Click_1(object sender, EventArgs e)
        {
            bool isNumeric = double.TryParse(txtUpdateSetPoint.Text, out R);
            if (isNumeric)
            {
                R = Convert.ToDouble(txtUpdateSetPoint.Text);
                PID01.R = R;
            }
            else
            {
                MessageBox.Show("Set Point must be a numeric value.", "SCADA HMI");
            }

        }

        private void PIController_Load(object sender, EventArgs e)
        {
            tmrControllerPopup.Start();
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
                       
        }


    }
}
