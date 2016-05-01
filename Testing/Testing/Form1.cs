using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlAndAquisition;

namespace Testing
{
    public partial class Form1 : Form
    {
        AnalogTransmitter TT01;
        Simulator Airheater;
        PIController PI;
        OPC OPC_r;
        OPC OPC_u;
        public Form1()
        {
            InitializeComponent();
            TT01 = new AnalogTransmitter("TT01");
            Airheater = new Simulator(0.1);
            trmTick.Enabled = true;
            PI = new PIController(1);
            OPC_r = new OPC("r");
            OPC_u = new OPC("u",true);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trmTick_Tick(object sender, EventArgs e)
        {
            TT01.Update(Airheater.y);
            PI.r = OPC_r.Read();
            Airheater.u = PI.Compute(TT01.PV);
            OPC_u.Write(PI.U);

        }
    }
}
