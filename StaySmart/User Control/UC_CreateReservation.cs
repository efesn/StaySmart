﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StaySmart.User_Control
{
    public partial class UC_CreateReservation : UserControl
    {
        DbFunction fn = new DbFunction();
        string query;
        Email email;

        public UC_CreateReservation()
        {
            InitializeComponent();
            LoadPlaces();
            email = new Email("smtp.gmail.com", 587, "", "");
        }

        private void LoadPlaces()
        {
            query = "SELECT placeName FROM Add_Place";
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                comboBoxPlaceName.Items.Add(sdr.GetString(0));
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
                string customerGender = genderCombobox.Text;
                string customerEmail = txtEmail.Text;
                //string gender = genderCombobox.Text;
                string checkIn = btnCheckin.Text;
                string checkOut = btnCheckOut.Text;

                query = "INSERT INTO New_Reservation (placeName, customerName, customerContact, customerEmail, gender, checkin, checkout) VALUES ('" + placeName + "','" + customerName + "','" + customerContact + "','" + customerEmail + "','" + customerGender + "','" + checkIn + "','" + checkOut + "')";
                fn.setData(query, "Reservation Created Successfully");

                email.SendEmail(customerEmail, customerName, placeName, checkIn, checkOut);



                //UC_ViewReservations ucViewReservations = (UC_ViewReservations)ParentForm.Controls["uc_ViewReservations"];


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
            genderCombobox.SelectedIndex = -1;
            txtEmail.Clear();
            btnCheckin.ResetText();
            btnCheckOut.ResetText();
        }

        private void UC_CreateReservation_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_CreateReservation_Load(object sender, EventArgs e)
        {
            LoadPlaces();
        }
    }
}
