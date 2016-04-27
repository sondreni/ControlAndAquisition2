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
        double r = 0;
        double y = 0;
        double u = 0;
        OPC uOPC;
        OPC yOPC;
        OPC rOPC;
        SqlConnection sqlConnection1 = new SqlConnection();


        public Form1()
        {
            InitializeComponent();
            uOPC = new OPC("u");
            yOPC = new OPC("y");
            rOPC = new OPC("r");

            trmUpdate.Enabled = true;
            sqlConnection1.ConnectionString = "Data Source=SONDRES\\CITADEL;" + "Initial Catalog=SCADADatabase;" + "User id=Sondre;" + "Password=;";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }
        private void getData()
        {
            y = yOPC.Read();
            u = uOPC.Read();
            r = rOPC.Read();
        }

        private void WriteLogValues()
        {
            
                       
            //PROVIDER=SQLOLEDB;DATA SOURCE=SONDRES\CITADEL;UID=Sondre;PWD=;DATABASE=SensorDatabase2
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT Templog (Time, y,r,u) VALUES (getdate(),@y,@r,@u)";
            cmd.Parameters.AddWithValue("@y", y);
            cmd.Parameters.AddWithValue("@r", r);
            cmd.Parameters.AddWithValue("@u", u);
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }



 

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
            WriteLogValues();

        }

        private void trmUpdate_Tick(object sender, EventArgs e)
        {

        }
    }
}
