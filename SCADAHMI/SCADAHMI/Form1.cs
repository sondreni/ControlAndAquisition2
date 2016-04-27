using ControlAndAquisition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCADAHMI
{
    public partial class Form1 : Form
    {
        string sqlConnectionstring;
        OPC opcY = new OPC("y");
        OPC opcR = new OPC("r");
        OPC opcU = new OPC("u");
        OPC opcHHLim = new OPC("HHLim");
        OPC opcHLim = new OPC("HLim");
        OPC opcLLim = new OPC("LLim");
        OPC opcLLLim = new OPC("LLLim");

        double Y;
        double R;
        double U;
        double time = 0;
        

        public Form1()
        {
            InitializeComponent();
            txtHHLim.Text = "30";
            txtHLim.Text = "28";
            txtLLim.Text = "22";
            txtLLLim.Text = "20";

            chart1.Series.Clear();
            chart1.Series.Add("°C");
            chart1.Series["°C"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("u");
            chart1.Series["u"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("r");
            chart1.Series["r"].ChartType = SeriesChartType.Line;

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
            if (time > 60)
            {
                chart1.Series["u"].Points.RemoveAt(0);
                chart1.Series["°C"].Points.RemoveAt(0);
                chart1.Series["r"].Points.RemoveAt(0);
            }
            time++;
            Y = opcY.Read();
            R = opcR.Read();
            U = opcU.Read();
            txtValueTemp.Text = Y.ToString();


            chart1.Series["u"].Points.AddXY(time, U);
            chart1.Series["°C"].Points.AddXY(time, Y);
            chart1.Series["r"].Points.AddXY(time, R);
            chart1.ResetAutoValues();
        }

        private void btnUpdateLim_Click(object sender, EventArgs e)
        {
            
            opcHHLim.Write(Convert.ToDouble(txtHHLim.Text));
            opcHLim.Write(Convert.ToDouble(txtHLim.Text));
            opcLLim.Write(Convert.ToDouble(txtLLim.Text));
            opcLLLim.Write(Convert.ToDouble(txtLLLim.Text));
        }
    }
}
