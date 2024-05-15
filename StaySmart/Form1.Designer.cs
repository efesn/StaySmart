namespace StaySmart
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            loginTitle = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            loginUsername = new TextBox();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            loginPassword = new TextBox();
            pictureBoxShow = new PictureBox();
            btnLogin = new Button();
            label5 = new Label();
            label6 = new Label();
            pictureBoxHide = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHide).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 432);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.Snow;
            label3.Location = new Point(12, 404);
            label3.Name = "label3";
            label3.Size = new Size(147, 19);
            label3.TabIndex = 2;
            label3.Text = "Developed By Efe Esen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.ForeColor = Color.Snow;
            label2.Location = new Point(64, 97);
            label2.Name = "label2";
            label2.Size = new Size(110, 30);
            label2.TabIndex = 1;
            label2.Text = "StaySmart";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(31, 47);
            label1.Name = "label1";
            label1.Size = new Size(180, 31);
            label1.TabIndex = 0;
            label1.Text = "Welcome To The";
            // 
            // loginTitle
            // 
            loginTitle.AutoSize = true;
            loginTitle.BackColor = Color.Transparent;
            loginTitle.Font = new Font("Segoe UI", 18F);
            loginTitle.ForeColor = Color.Black;
            loginTitle.Location = new Point(460, 97);
            loginTitle.Name = "loginTitle";
            loginTitle.Size = new Size(88, 32);
            loginTitle.TabIndex = 1;
            loginTitle.Text = "Sign In";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(loginUsername);
            panel2.Location = new Point(295, 189);
            panel2.Name = "panel2";
            panel2.Size = new Size(427, 42);
            panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(43, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // loginUsername
            // 
            loginUsername.Location = new Point(52, 10);
            loginUsername.Name = "loginUsername";
            loginUsername.Size = new Size(370, 23);
            loginUsername.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(loginPassword);
            panel3.Location = new Point(295, 280);
            panel3.Name = "panel3";
            panel3.Size = new Size(427, 42);
            panel3.TabIndex = 3;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // loginPassword
            // 
            loginPassword.Location = new Point(52, 11);
            loginPassword.Name = "loginPassword";
            loginPassword.Size = new Size(370, 23);
            loginPassword.TabIndex = 1;
            // 
            // pictureBoxShow
            // 
            pictureBoxShow.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxShow.Image = Properties.Resources.eye;
            pictureBoxShow.Location = new Point(728, 280);
            pictureBoxShow.Name = "pictureBoxShow";
            pictureBoxShow.Size = new Size(44, 42);
            pictureBoxShow.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxShow.TabIndex = 3;
            pictureBoxShow.TabStop = false;
            pictureBoxShow.Click += pictureBoxShow_Click;
            pictureBoxShow.MouseHover += pictureBoxShow_MouseHover;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Navy;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(448, 343);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(121, 46);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(291, 152);
            label5.Name = "label5";
            label5.Size = new Size(164, 25);
            label5.TabIndex = 5;
            label5.Text = "Username or Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F);
            label6.Location = new Point(291, 245);
            label6.Name = "label6";
            label6.Size = new Size(91, 25);
            label6.TabIndex = 6;
            label6.Text = "Password:";
            // 
            // pictureBoxHide
            // 
            pictureBoxHide.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHide.Image = (Image)resources.GetObject("pictureBoxHide.Image");
            pictureBoxHide.Location = new Point(733, 280);
            pictureBoxHide.Name = "pictureBoxHide";
            pictureBoxHide.Size = new Size(39, 40);
            pictureBoxHide.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxHide.TabIndex = 4;
            pictureBoxHide.TabStop = false;
            pictureBoxHide.Click += pictureBoxHide_Click;
            pictureBoxHide.MouseHover += pictureBoxHide_MouseHover;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(779, 432);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pictureBoxShow);
            Controls.Add(pictureBoxHide);
            Controls.Add(btnLogin);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(loginTitle);
            Controls.Add(panel1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHide).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label loginTitle;
        private Panel panel2;
        private TextBox loginUsername;
        private Panel panel3;
        private TextBox loginPassword;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnLogin;
        private Label label5;
        private Label label6;
        private PictureBox pictureBoxShow;
        private PictureBox pictureBoxHide;
    }
}
