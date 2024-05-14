using System;
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

        }

        public void LoadPlacesFromDataGridView(DataGridView dataGridView1)
        {

            //LoadPlaces();
            comboBoxPlaceName.Items.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string placeName = row.Cells["placeName"].Value.ToString();
                    comboBoxPlaceName.Items.Add(placeName);
                }
            }
        }


        public void LoadPlaces()
        {

            query = "SELECT placeName FROM Add_Place";
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                comboBoxPlaceName.Items.Add(sdr.GetString(0));
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
                string placeName = comboBoxPlaceName.SelectedItem.ToString();
                string customerName = txtName.Text;
                string customerContact = txtContact.Text;
                string customerGender = genderCombobox.Text;
                string customerEmail = txtEmail.Text;
                string checkIn = btnCheckin.Text;
                string checkOut = btnCheckOut.Text;
                string otp = OTPUtility.GenerateOTP();

                // only numeric characters
                if (customerContact.All(char.IsDigit))
                {
                    if (customerContact.Length >= 3 && customerContact.Length <= 15)
                    {
                        // is email valid?
                        if (IsValidEmail(customerEmail))
                        {
                            query = "INSERT INTO New_Reservation (placeName, customerName, customerContact, customerEmail, gender, checkin, checkout, otp) VALUES ('" + placeName + "','" + customerName + "','" + customerContact + "','" + customerEmail + "','" + customerGender + "','" + checkIn + "','" + checkOut + "','" + otp + "')";
                            fn.setData(query, "Reservation Created Successfully");

                            query = "INSERT INTO User_Table (User_Name, User_Password, UserRole, Email, OTP) VALUES ('" + customerEmail + "','" + otp + "','User','" + customerEmail + "','" + otp + "')";
                            fn.setData(query, "User Created Successfully");

                            OTPUtility otpUtility = new OTPUtility();
                            otpUtility.SendOTPByEmail(customerEmail, otp);

                            email.SendEmail(customerEmail, customerName, placeName, checkIn, checkOut);

                            var parentForm = this.ParentForm as Form1;
                            if (parentForm != null)
                            {
                                var viewReservationsControl = parentForm.Controls["uc_ViewReservations"] as UC_ViewReservations;
                                viewReservationsControl.LoadReservationsData();
                            }

                            clearAll();
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid email address!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

            if (btnCheckOut.Value < btnCheckin.Value)
            {
                MessageBox.Show("Check Out Date cannot be less than Check In Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

