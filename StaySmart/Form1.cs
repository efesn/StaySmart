namespace StaySmart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "efesn" && textBox2.Text == "1234")
            {
                MessageBox.Show("Login Successful!, Redirecting to the Dashboard");
                Dashboard ds = new Dashboard();
                this.Hide();
                ds.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                textBox2.Clear();
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
