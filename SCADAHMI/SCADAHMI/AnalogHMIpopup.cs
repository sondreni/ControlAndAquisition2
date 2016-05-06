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
    public partial class AnalogHMIpopup : Form
    {
        //Create variables.
        public double time;
        public double Y;
        public double U;
        public double R;
        public bool AlarmActive=true;/***Test****/

        AnalogHMI TT01 = new AnalogHMI("TT01");
        PIDhmi PID01 = new PIDhmi("PID01");
        public AnalogHMIpopup()
        {
            InitializeComponent();

            #region Initialize Chart
            chart1.Series.Clear();
            chart1.Series.Add("°C");
            chart1.Series["°C"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("u");
            chart1.Series["u"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("r");
            chart1.Series["r"].ChartType = SeriesChartType.Line;
            #endregion
        }

        public void DoCharting()
        {
            if (time > 60)
            {
                chart1.Series["u"].Points.RemoveAt(0);
                chart1.Series["°C"].Points.RemoveAt(0);
                chart1.Series["r"].Points.RemoveAt(0);
            }
            time++;
            Y = TT01.Y;
            R = PID01.R;
            U = PID01.U;
            txtValueTemp.Text = Y.ToString();

            chart1.Series["u"].Points.AddXY(time, U);
            chart1.Series["°C"].Points.AddXY(time, Y);
            chart1.Series["r"].Points.AddXY(time, R);
            chart1.ResetAutoValues();
        }//Executes charting

        private void AnalogHMIpopup_Load(object sender, EventArgs e)
        {
            
            tmrAnalogHMIpopup.Start(); //Starts timer which starts updating plot.
            #region Initialize Limits
            txtHHLim.Text = "30";
            txtHLim.Text = "28";
            txtLLim.Text = "22";
            txtLLLim.Text = "20";

            TT01.UpdateLim(txtHHLim.Text, txtHLim.Text, txtLLim.Text, txtLLLim.Text);
            #endregion
        }

        private void tmrAnalogHMIpopup_Tick(object sender, EventArgs e)
        {

            DoCharting();
            txtValueTemp.Text = TT01.Y.ToString();
        }

        private void btnUpdateLim_Click(object sender, EventArgs e)
        {
            TT01.UpdateLim(txtHHLim.Text, txtHLim.Text, txtLLim.Text, txtLLLim.Text);

        }
    }
}
