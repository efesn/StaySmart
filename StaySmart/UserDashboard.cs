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
    public partial class UserDashboard : Form
    {
        private DbFunction db = new DbFunction();
        //private string userEmail;
        public UserDashboard(string userEmail) 
        {
            InitializeComponent();
            LoadReservationData(userEmail); 
        }

        private void LoadReservationData(string userEmail)
        {
            DataTable reservationData = db.GetReservationData(userEmail); 
            dataGridView1.DataSource = reservationData; 
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                this.Close();

                Form1 login = new Form1();
                login.Show();
            }
        }
    }
}