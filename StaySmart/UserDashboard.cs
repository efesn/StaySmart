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
        private DbFunction db = new DbFunction(); // Assuming you have an instance of DbFunction to interact with the database

        public UserDashboard()
        {
            InitializeComponent();
            LoadReservationData();
        }

        private void LoadReservationData()
        {
            // Fetch reservation data for the current user's email
            string userEmail = "user@example.com"; // Example email, replace with actual user's email
            DataTable reservationData = db.GetReservationData(userEmail); // Method to fetch reservation data based on email

            // Bind the DataGridView to the reservation data
            dataGridView1.DataSource = reservationData;
        }
    }
}