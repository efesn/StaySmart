using System.Data.Common;

namespace StaySmart
{
    public partial class LoginForm : Form
    {

        DbFunction db = new DbFunction();
        public LoginForm()
        {
            InitializeComponent();
            loginPassword.UseSystemPasswordChar = true;
            db = new DbFunction();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = loginUsername.Text.Trim();
            string password = loginPassword.Text.Trim();

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
                UserDashboard userDashboard = new UserDashboard(username);
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
            loginPassword.UseSystemPasswordChar = false;
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            loginPassword.UseSystemPasswordChar = true;
            pictureBoxShow.Show();
        }
    }
}
