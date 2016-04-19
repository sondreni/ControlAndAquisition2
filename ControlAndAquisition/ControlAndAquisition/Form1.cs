using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments;
using NationalInstruments.DataInfrastructure;




namespace ControlAndAquisition
{
    public partial class Form1 : Form
    {
        PIController PI = new PIController();
        public Form1()
        {

            
            InitializeComponent();
            
        }






    }
}
