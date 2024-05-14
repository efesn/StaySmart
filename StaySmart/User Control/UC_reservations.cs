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
        UC_CreateReservation createReservation;

        public static DataTable DataSource { get; internal set; }

        public UC_reservations()
        {
            InitializeComponent();
            //UC_reservations_Load(this, null);
            //UC_CreateReservation createReservation = new UC_CreateReservation();
            createReservation = new UC_CreateReservation();
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
            if (placeName.Text != "" && placeAddress.Text != "")
            {
                String name = placeName.Text;
                String address = placeAddress.Text;
                String contact = placeContact.Text;

                // only numeric characters
                if (contact.All(char.IsDigit))
                {
                    if (contact.Length >= 3 && contact.Length <= 15)
                    {
                        query = "INSERT INTO Add_Place (placeName, placeAddress, placeContact) VALUES ('" + name + "','" + address + "','" + contact + "')";
                        fn.setData(query, "Reservation Place Added Successfully");

                        RefreshPlaceListInCreateReservationForm();

                        clearAll();
                        UC_reservations_Load(this, null);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid phone number between 3 and 15 digits!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric phone number!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void RefreshPlaceListInCreateReservationForm()
        {
            var createReservationForm = Application.OpenForms.OfType<UC_CreateReservation>().FirstOrDefault();
            if (createReservationForm != null)
            {
                createReservationForm.RefreshPlaces();
            }
        }



        public void clearAll() 
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

        private void btnDeletePlace_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                // Get the ID of the selected place
                int placeId = Convert.ToInt32(DataGridView1.SelectedRows[0].Cells[0].Value);

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this place?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Delete the place from the database
                    string deleteQuery = "DELETE FROM Add_Place WHERE placeId = " + placeId;
                    fn.setData(deleteQuery, "Place Deleted Successfully");

                    // Refresh the DataGridView
                    UC_reservations_Load(sender, e);

                    // Clear the form fields
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Please select a place to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
