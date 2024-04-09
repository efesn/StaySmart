using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace StaySmart.User_Control
{
    public partial class UC_reservations : UserControl
    {
        DbFunction fn = new DbFunction();
        String query;

        public static DataTable DataSource { get; internal set; }

        public UC_reservations()
        {
            InitializeComponent();
            UC_reservations_Load(this, null);
        }

        private void UC_reservations_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM Add_Place";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];

            DataGridView1.Columns[0].HeaderText = "ID";
            DataGridView1.Columns[1].HeaderText = "Place Name";
            DataGridView1.Columns[2].HeaderText = "Place Address";
            DataGridView1.Columns[3].HeaderText = "Place Contact";
            
        }



        private void btnAddPlace_Click(object sender, EventArgs e)
        {


            // place formlarını required field olarak ayarlıyoruzç
            if (placeName.Text != "" && placeAddress.Text != "" && placeContact.Text != "")
            {
                String name = placeName.Text;
                String address = placeAddress.Text;
                String contact = placeContact.Text;

                query = "INSERT INTO Add_Place (placeName, placeAddress, placeContact) VALUES ('" + name + "','" + address + "','" + contact + "')";
                fn.setData(query, "Reservation Place Added Successfully");

                UC_reservations_Load(this, null); //data ekledikten sonra datasette görünmesini sağlıyoruz

                clearAll();


            }
            else
            {
                MessageBox.Show("Please fill all the fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshPlaceListInCreateReservationForm();
        }

        private void RefreshPlaceListInCreateReservationForm()
        {
            var createReservationForm = Application.OpenForms.OfType<UC_CreateReservation>().FirstOrDefault();
            if (createReservationForm != null)
            {
                createReservationForm.LoadPlacesFromDataGridView(DataGridView1);
            }
        }





        public void clearAll() // data ekledikten sonra textboxları temizliyoruz
        {
            placeName.Clear();
            placeAddress.Clear();
            placeContact.Clear();
        }

        private void UC_reservations_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_reservations_Enter(object sender, EventArgs e)
        {
            UC_reservations_Load(this, null);
        }
    }
}
