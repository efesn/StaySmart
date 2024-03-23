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
    public partial class UC_ViewReservations : UserControl
    {

        DbFunction fn = new DbFunction();
        String query;
        public UC_ViewReservations()
        {
            InitializeComponent();
        }

        private void UC_ViewReservations_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM New_Reservation";
            DataSet ds = fn.getData(query);
            DataGridViewReservations.DataSource = ds.Tables[0];
        }
    }
}
