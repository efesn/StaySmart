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
            bool check = db.IsValidNamePass(textBox1.Text.Trim(), textBox2.Text.Trim());
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty)
                MessageBox.Show("Please fill all the fields", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (check)
                {
                    MessageBox.Show("Login Successful!, Redirecting to the Dashboard");
                    Dashboard ds = new Dashboard();
                    ds.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
