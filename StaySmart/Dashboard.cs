using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaySmart
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            uC_reservations1.Visible = true;
            uC_reservations1.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_reservations1.Visible = false;
            btnAddPlaceNav.PerformClick();

        }
    }
}
