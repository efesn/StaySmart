using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaySmart.User_Control
{
    public partial class MainDashboard : UserControl
    {

        DbFunction db;
        public MainDashboard()
        {
            InitializeComponent();
            db = new DbFunction();
        }

        public void PlaceCount()
        {
            labelPlaceCount.Text = db.GetPlaceCount().ToString();
        }

        public void ReservationCount()
        {
            labelReservationsCount.Text = db.GetReservationCount().ToString();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            PlaceCount();
            ReservationCount();
        }

        private void labelPlaceCount_Click(object sender, EventArgs e)
        {

        }

        private void updateReservationsButton_Click(object sender, EventArgs e)
        {
            PlaceCount();
            ReservationCount();
        }
    }
}
