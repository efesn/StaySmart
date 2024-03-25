using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaySmart.User_Control
{
    public partial class UC_CreateReservation : UserControl
    {
        DbFunction fn = new DbFunction();
        string query = "SELECT placeName FROM Add_Place";

        public UC_CreateReservation()
        {
            InitializeComponent();
            LoadPlaces();
        }

        private void LoadPlaces()
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                //yeni eklenen placeler güncellenmiyor burasıyla alakalı olabilir
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    comboBoxPlaceName.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void comboBoxPlaceName_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedPlaceName = comboBoxPlaceName.SelectedItem.ToString();
            MessageBox.Show("Selected Place: " + selectedPlaceName);
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            if (comboBoxPlaceName.SelectedIndex != -1 && txtName.Text != "" && txtContact.Text != "" && txtEmail.Text != "" && genderCombobox.Text != "" && txtCheckin.Text != "")
            {
                string placeName = comboBoxPlaceName.SelectedItem.ToString();
                string customerName = txtName.Text;
                string customerContact = txtContact.Text;
                string customerGender = "";
                string customerEmail = txtEmail.Text;
                string gender = genderCombobox.Text;
                string checkIn = btnCheckin.Text;
                string checkOut = btnCheckOut.Text;

                query = "INSERT INTO New_Reservation (placeName, customerName, customerContact, customerEmail, gender, checkin, checkout) VALUES ('" + placeName + "','" + customerName + "','" + customerContact + "','" + customerEmail + "','" + customerGender + "','" + checkIn + "','" + checkOut + "')";
                fn.setData(query, "Reservation Created Successfully");


            }
            else
            {
                MessageBox.Show("Please fill all the fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            comboBoxPlaceName.SelectedIndex = -1;
            txtName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            genderCombobox.SelectedIndex = -1;
            btnCheckin.ResetText();
            btnCheckOut.ResetText();
        }

        private void UC_CreateReservation_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}