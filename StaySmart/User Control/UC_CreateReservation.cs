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
        OTPUtility otpUtility;


        public UC_CreateReservation()
        {

            InitializeComponent();
            LoadPlaces();
            email = new Email("smtp.gmail.com", 587, "", "");
            otpUtility = new OTPUtility();
            btnCheckin.Value = DateTime.Today;
            btnCheckOut.Value = DateTime.Today;

            txtName.MaxLength = 50; 
            txtContact.MaxLength = 15; 
            txtEmail.MaxLength = 100; 

        }

        public void LoadPlacesFromDataGridView(DataGridView dataGridView1)
        {

            //LoadPlaces();
            comboBoxPlaceName.Items.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string placeId = row.Cells[0].Value.ToString();
                    comboBoxPlaceName.Items.Add(placeId);
                }
            }
        }


        public void LoadPlaces()
        {
            query = "SELECT placeId FROM Add_Place";
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                comboBoxPlaceName.Items.Add(sdr.GetInt32(0).ToString());
            }
            sdr.Close();
        }


        public void RefreshPlaces()
        {

            //LoadPlaces();

        }

        private void comboBoxPlaceName_SelectedIndexChanged(object sender, EventArgs e)
        {

            //LoadPlaces();

            string selectedPlaceName = comboBoxPlaceName.SelectedItem.ToString();
            MessageBox.Show("Selected Place: " + selectedPlaceName);
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            if (comboBoxPlaceName.SelectedIndex != -1 && txtName.Text != "" && txtContact.Text != "" && txtEmail.Text != "" && genderCombobox.Text != "" && txtCheckin.Text != "")
            {
                string placeId = comboBoxPlaceName.SelectedItem.ToString();
                string customerName = txtName.Text;
                string customerContact = txtContact.Text;
                string customerGender = genderCombobox.Text;
                string customerEmail = txtEmail.Text;
                string checkIn = btnCheckin.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string checkOut = btnCheckOut.Value != null ? btnCheckOut.Value.ToString("yyyy-MM-dd HH:mm:ss") : "NULL";
                string otp = OTPUtility.GenerateOTP();

                int userId = CreateUserAndGetId(customerEmail, otp);

                if (userId != -1)
                {
                    query = "INSERT INTO New_Reservation (User_ID, placeId, customerName, customerContact, customerEmail, gender, checkin, checkout, otp) VALUES (" + userId + ",'" + placeId + "','" + customerName + "','" + customerContact + "','" + customerEmail + "','" + customerGender + "','" + checkIn + "','" + checkOut + "','" + otp + "')";
                    fn.setData(query, "Reservation Created Successfully");
                }
                else
                {
                    MessageBox.Show("Failed to create a new user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int CreateUserAndGetId(string email, string otp)
        {
            int userId = -1;
            try
            {
                using (SqlConnection con = fn.getConnection())
                {
                    con.Open();
                    string insertQuery = "INSERT INTO User_Table (User_Name, User_Password, UserRole, Email, OTP) VALUES (@UserName, @Password, @UserRole, @Email, @OTP); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@UserName", email); 
                    cmd.Parameters.AddWithValue("@Password", ""); 
                    cmd.Parameters.AddWithValue("@UserRole", "User"); 
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@OTP", otp);
                    userId = Convert.ToInt32(cmd.ExecuteScalar()); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return userId;
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
            //LoadPlaces();
            comboBoxPlaceName.Items.Clear();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            comboBoxPlaceName.Items.Clear();
            LoadPlaces();
        }

        private void btnCheckOut_ValueChanged(object sender, EventArgs e)
        {
            DateTime checkInDate = btnCheckin.Value;
            DateTime checkOutDate = btnCheckOut.Value;

            if (checkOutDate < checkInDate)
            {
                MessageBox.Show("Check Out Date cannot be earlier than Check In Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCheckOut.Value = checkInDate;
            }
        }

    }
}

