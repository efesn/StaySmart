﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StaySmart.User_Control
{
    public partial class UC_ViewReservations : UserControl
    {

        DbFunction fn = new DbFunction();
        String query;
        Email email;
        public UC_ViewReservations()
        {

            InitializeComponent();
            email = new Email("smtp.gmail.com", 587, "", "");

            textName.MaxLength = 50;
            textContact.MaxLength = 15;
            textEmail.MaxLength = 100;
        }

        public void UC_ViewReservations_Load(object sender, EventArgs e)
        {
            LoadReservationsData();
            comboBoxPlace.Items.Clear();

            query = "SELECT placeId FROM Add_Place";
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                int placeId = sdr.GetInt32(0);

                comboBoxPlace.Items.Add(placeId.ToString());
            }
            sdr.Close();

            DataGridViewReservations.Columns[0].HeaderText = "ID";
            DataGridViewReservations.Columns[1].HeaderText = "Name";
            DataGridViewReservations.Columns[2].HeaderText = "Email";
            DataGridViewReservations.Columns[3].HeaderText = "Gender";
            DataGridViewReservations.Columns[4].HeaderText = "Place";
            DataGridViewReservations.Columns[5].HeaderText = "Contact";
            DataGridViewReservations.Columns[6].HeaderText = "Check In";
            DataGridViewReservations.Columns[7].HeaderText = "Check Out";
        }



        public void LoadReservationsData()
        {

            DataGridViewReservations.DataSource = null;
            //query = "SELECT * FROM New_Reservation";
            query = "SELECT newReservationId, customerName, customerEmail, gender, placeId, customerContact, checkin, checkout FROM New_Reservation";
            DataSet ds = fn.getData(query);

            DataGridViewReservations.DataSource = ds.Tables[0];
            DataGridViewReservations.Refresh();
        }

        private void DataGridViewReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = DataGridViewReservations.Rows[e.RowIndex];
                textName.Text = row.Cells[1].Value.ToString();
                textEmail.Text = row.Cells[2].Value.ToString();
                genderCombo.SelectedItem = row.Cells[3].Value;
                comboBoxPlace.SelectedItem = row.Cells[4].Value;
                textContact.Text = row.Cells[5].Value.ToString();

                // Check in
                if (DateTime.TryParse(row.Cells[6].Value.ToString(), out DateTime checkinDate))
                {
                    btnCheckin2.Value = checkinDate;
                }
                else
                {
                    MessageBox.Show("Invalid check-in date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Check out
                if (DateTime.TryParse(row.Cells[7].Value.ToString(), out DateTime checkoutDate))
                {
                    btnCheckOut2.Value = checkoutDate;
                }
                else
                {
                    MessageBox.Show("Invalid check-out date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataGridViewReservations.SelectedRows.Count > 0)
            {
                int reservationId = Convert.ToInt32(DataGridViewReservations.SelectedRows[0].Cells[0].Value);

                if (comboBoxPlace.SelectedIndex != -1 && textName.Text != "" && textContact.Text != "" && textEmail.Text != "" && genderCombo.Text != "" && btnCheckin2.Value != null && btnCheckOut2.Value != null)
                {
                    string placeName = comboBoxPlace.SelectedItem.ToString();
                    string customerName = textName.Text;
                    string customerContact = textContact.Text;
                    string customerGender = genderCombo.Text;
                    string customerEmail = textEmail.Text;
                    string checkIn = btnCheckin2.Value.ToString("yyyy-MM-dd");
                    string checkOut = btnCheckOut2.Value != null ? btnCheckOut2.Value.ToString("yyyy-MM-dd") : "";

                    // Validate email
                    if (IsValidEmail(customerEmail))
                    {
                        // Validate phone number
                        if (customerContact.All(char.IsDigit) && customerContact.Length >= 3 && customerContact.Length <= 15)
                        {
                            string query = "UPDATE New_Reservation SET placeId = '" + placeName + "', customerName = '" + customerName + "', customerContact = '" + customerContact + "', customerEmail = '" + customerEmail + "', gender = '" + customerGender + "', checkin = '" + checkIn + "', checkout = '" + checkOut + "' WHERE newReservationId = " + reservationId;
                            fn.setData(query, "Reservation Updated Successfully");

                            email.UpdateEmail(customerEmail, customerName, placeName, checkIn, checkOut);

                            UC_ViewReservations_Load(sender, e);

                            clearAll();
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid phone number between 3 and 15 digits!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid email address!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all the fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to update!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DataGridViewReservations.SelectedRows.Count > 0)
            {

                int reservationId = Convert.ToInt32(DataGridViewReservations.SelectedRows[0].Cells[0].Value);


                DialogResult result = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string deleteQuery = "DELETE FROM New_Reservation WHERE newReservationId = " + reservationId;
                    fn.setData(deleteQuery, "Reservation Deleted Successfully");

                    email.DeleteEmail(textEmail.Text, textName.Text, comboBoxPlace.SelectedItem.ToString(), btnCheckin2.Value.ToString("yyyy-MM-dd"), btnCheckOut2.Value.ToString("yyyy-MM-dd"));


                    UC_ViewReservations_Load(sender, e);

                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            comboBoxPlace.SelectedIndex = -1;
            textName.Clear();
            textContact.Clear();
            textEmail.Clear();
            genderCombo.SelectedIndex = -1;
            btnCheckin2.ResetText();
            btnCheckOut2.ResetText();
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            string placeName = getReportCombobox.Text;

            string query = "SELECT * FROM New_Reservation WHERE placeId = @PlaceName";

            DataTable reportData = fn.GetReportData(query, placeName);

            guna2DataGridView1.DataSource = reportData;
        }

        private void updateReservationsButton_Click(object sender, EventArgs e)
        {
            LoadReservationsData();
        }

        private void textContact_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
