using System.Data.Common;

namespace StaySmart
{
    public partial class Form1 : Form
    {

        DbFunction db = new DbFunction();
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            db = new DbFunction();

            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all the fields", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            
            string role = db.GetUserRole(username, password);

            if (role == "Admin")
            {
                MessageBox.Show("Login Successful! Redirecting to the Admin Dashboard");
                Dashboard ds = new Dashboard();
                ds.Show();
                this.Hide();
            }
            else if (role == "User")
            {
                MessageBox.Show("Login Successful! Redirecting to the User Dashboard");
                UserDashboard userDashboard = new UserDashboard();
                userDashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBoxShow_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(pictureBoxShow, "Show Password");
        }

        private void pictureBoxHide_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(pictureBoxHide, "Hide Password");
        }

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {
            pictureBoxShow.Hide();
            textBox2.UseSystemPasswordChar = false;
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            textBox2.UseSystemPasswordChar = true;
            pictureBoxShow.Show();
        }
    }
}
