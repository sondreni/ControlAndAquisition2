using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ControlAndAquisition;

namespace Datalogger
{
    public partial class Form1 : Form
    {
        
        string SQLConnectionString= "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";

        AnalogLog TT01;

        public Form1()
        {
            InitializeComponent();

            TT01 = new AnalogLog("TT01", SQLConnectionString);

            trmUpdate.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            TT01.Update();
        }

        private void trmUpdate_Tick(object sender, EventArgs e)
        {
          
        }
    }
}
