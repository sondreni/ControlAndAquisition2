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
    public partial class Form1 : Form
    {
        string sqlConnectionstring;
        
        public Form1()
        {
            InitializeComponent();
            txtHHLim.Text = "30";
            txtHLim.Text = "28";
            txtLLim.Text = "22";
            txtLLLim.Text = "20";

        }

        private void btnAckHHAlrm_Click(object sender, EventArgs e)
        {

        }

        private void txtHHLim_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void btnStartHMI_Click(object sender, EventArgs e)
        {
            tmrHMI.Start();
        }

        private void tmrHMI_Tick(object sender, EventArgs e)
        {
            txtHLim.Text = txtHHLim.Text;
        }
        
    }
}
