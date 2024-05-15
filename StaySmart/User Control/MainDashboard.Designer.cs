namespace StaySmart.User_Control
{
    partial class MainDashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            welcomeLabel = new Label();
            panelPlace = new Guna.UI2.WinForms.Guna2Panel();
            labelPlace = new Label();
            labelPlaceCount = new Label();
            panelReservations = new Guna.UI2.WinForms.Guna2Panel();
            labelReservations = new Label();
            labelReservationsCount = new Label();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            updateReservationsButton = new Guna.UI2.WinForms.Guna2Button();
            panelPlace.SuspendLayout();
            panelReservations.SuspendLayout();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            welcomeLabel.ForeColor = Color.White;
            welcomeLabel.Location = new Point(308, 87);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(368, 37);
            welcomeLabel.TabIndex = 6;
            welcomeLabel.Text = "Welcome To The StaySmart";
            // 
            // panelPlace
            // 
            panelPlace.BorderColor = Color.Black;
            panelPlace.BorderRadius = 20;
            panelPlace.BorderThickness = 1;
            panelPlace.Controls.Add(labelPlace);
            panelPlace.Controls.Add(labelPlaceCount);
            panelPlace.CustomizableEdges = customizableEdges7;
            panelPlace.FillColor = Color.White;
            panelPlace.Location = new Point(79, 206);
            panelPlace.Name = "panelPlace";
            panelPlace.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelPlace.Size = new Size(284, 168);
            panelPlace.TabIndex = 9;
            // 
            // labelPlace
            // 
            labelPlace.AutoSize = true;
            labelPlace.BackColor = Color.Transparent;
            labelPlace.Font = new Font("Segoe UI", 20F);
            labelPlace.Location = new Point(82, 20);
            labelPlace.Name = "labelPlace";
            labelPlace.Size = new Size(85, 37);
            labelPlace.TabIndex = 1;
            labelPlace.Text = "Place:";
            // 
            // labelPlaceCount
            // 
            labelPlaceCount.AutoSize = true;
            labelPlaceCount.BackColor = Color.Transparent;
            labelPlaceCount.Font = new Font("Segoe UI", 15F);
            labelPlaceCount.Location = new Point(94, 75);
            labelPlaceCount.Name = "labelPlaceCount";
            labelPlaceCount.Size = new Size(61, 28);
            labelPlaceCount.TabIndex = 0;
            labelPlaceCount.Text = "Place:";
            labelPlaceCount.Click += labelPlaceCount_Click;
            // 
            // panelReservations
            // 
            panelReservations.BorderColor = Color.Black;
            panelReservations.BorderRadius = 20;
            panelReservations.BorderThickness = 1;
            panelReservations.Controls.Add(labelReservations);
            panelReservations.Controls.Add(labelReservationsCount);
            panelReservations.CustomizableEdges = customizableEdges9;
            panelReservations.FillColor = Color.White;
            panelReservations.Location = new Point(621, 206);
            panelReservations.Name = "panelReservations";
            panelReservations.ShadowDecoration.CustomizableEdges = customizableEdges10;
            panelReservations.Size = new Size(288, 168);
            panelReservations.TabIndex = 10;
            // 
            // labelReservations
            // 
            labelReservations.AutoSize = true;
            labelReservations.BackColor = Color.Transparent;
            labelReservations.Font = new Font("Segoe UI", 20F);
            labelReservations.Location = new Point(64, 20);
            labelReservations.Name = "labelReservations";
            labelReservations.Size = new Size(171, 37);
            labelReservations.TabIndex = 2;
            labelReservations.Text = "Reservations:";
            // 
            // labelReservationsCount
            // 
            labelReservationsCount.AutoSize = true;
            labelReservationsCount.BackColor = Color.Transparent;
            labelReservationsCount.Font = new Font("Segoe UI", 15F);
            labelReservationsCount.Location = new Point(131, 75);
            labelReservationsCount.Name = "labelReservationsCount";
            labelReservationsCount.Size = new Size(125, 28);
            labelReservationsCount.TabIndex = 0;
            labelReservationsCount.Text = "Reservations:";
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 30;
            guna2Elipse1.TargetControl = this;
            // 
            // updateReservationsButton
            // 
            updateReservationsButton.BorderRadius = 25;
            updateReservationsButton.CustomizableEdges = customizableEdges11;
            updateReservationsButton.DisabledState.BorderColor = Color.DarkGray;
            updateReservationsButton.DisabledState.CustomBorderColor = Color.DarkGray;
            updateReservationsButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            updateReservationsButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            updateReservationsButton.FillColor = SystemColors.MenuHighlight;
            updateReservationsButton.Font = new Font("Segoe UI", 12F);
            updateReservationsButton.ForeColor = Color.White;
            updateReservationsButton.Location = new Point(421, 423);
            updateReservationsButton.Name = "updateReservationsButton";
            updateReservationsButton.ShadowDecoration.CustomizableEdges = customizableEdges12;
            updateReservationsButton.Size = new Size(126, 46);
            updateReservationsButton.TabIndex = 46;
            updateReservationsButton.Text = "🔄 Update";
            updateReservationsButton.Click += updateReservationsButton_Click;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            Controls.Add(updateReservationsButton);
            Controls.Add(panelReservations);
            Controls.Add(panelPlace);
            Controls.Add(welcomeLabel);
            Name = "MainDashboard";
            Size = new Size(961, 551);
            Load += MainDashboard_Load;
            panelPlace.ResumeLayout(false);
            panelPlace.PerformLayout();
            panelReservations.ResumeLayout(false);
            panelReservations.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        private Guna.UI2.WinForms.Guna2Panel panelPlace;
        private Label labelPlace;
        private Label labelPlaceCount;
        private Guna.UI2.WinForms.Guna2Panel panelReservations;
        private Label labelReservations;
        private Label labelReservationsCount;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button updateReservationsButton;
    }
}
