namespace StaySmart.User_Control
{
    partial class UC_ViewReservations
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewReservations = new Guna.UI2.WinForms.Guna2DataGridView();
            label1 = new Label();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            ((System.ComponentModel.ISupportInitialize)DataGridViewReservations).BeginInit();
            SuspendLayout();
            // 
            // DataGridViewReservations
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            DataGridViewReservations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            DataGridViewReservations.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            DataGridViewReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            DataGridViewReservations.ColumnHeadersHeight = 4;
            DataGridViewReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            DataGridViewReservations.DefaultCellStyle = dataGridViewCellStyle6;
            DataGridViewReservations.GridColor = Color.FromArgb(231, 229, 255);
            DataGridViewReservations.Location = new Point(12, 52);
            DataGridViewReservations.Name = "DataGridViewReservations";
            DataGridViewReservations.RowHeadersVisible = false;
            DataGridViewReservations.Size = new Size(939, 488);
            DataGridViewReservations.TabIndex = 0;
            DataGridViewReservations.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            DataGridViewReservations.ThemeStyle.AlternatingRowsStyle.Font = null;
            DataGridViewReservations.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            DataGridViewReservations.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            DataGridViewReservations.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            DataGridViewReservations.ThemeStyle.BackColor = Color.White;
            DataGridViewReservations.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            DataGridViewReservations.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            DataGridViewReservations.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGridViewReservations.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            DataGridViewReservations.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            DataGridViewReservations.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DataGridViewReservations.ThemeStyle.HeaderStyle.Height = 4;
            DataGridViewReservations.ThemeStyle.ReadOnly = false;
            DataGridViewReservations.ThemeStyle.RowsStyle.BackColor = Color.White;
            DataGridViewReservations.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGridViewReservations.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            DataGridViewReservations.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DataGridViewReservations.ThemeStyle.RowsStyle.Height = 25;
            DataGridViewReservations.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DataGridViewReservations.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(399, 12);
            label1.Name = "label1";
            label1.Size = new Size(165, 37);
            label1.TabIndex = 2;
            label1.Text = "Reservations";
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 30;
            guna2Elipse1.TargetControl = this;
            // 
            // UC_ViewReservations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(DataGridViewReservations);
            Name = "UC_ViewReservations";
            Size = new Size(961, 551);
            Load += UC_ViewReservations_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView DataGridViewReservations;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
