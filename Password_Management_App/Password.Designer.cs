namespace Password_Management_App
{
    partial class frmPassword
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
            this.lbHello = new System.Windows.Forms.Label();
            this.gridViewPassword = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAddPass = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHello
            // 
            this.lbHello.AutoSize = true;
            this.lbHello.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbHello.ForeColor = System.Drawing.Color.Red;
            this.lbHello.Location = new System.Drawing.Point(12, 9);
            this.lbHello.Name = "lbHello";
            this.lbHello.Size = new System.Drawing.Size(76, 23);
            this.lbHello.TabIndex = 0;
            this.lbHello.Text = "Greeting";
            // 
            // gridViewPassword
            // 
            this.gridViewPassword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewPassword.Location = new System.Drawing.Point(12, 167);
            this.gridViewPassword.Name = "gridViewPassword";
            this.gridViewPassword.RowHeadersWidth = 51;
            this.gridViewPassword.RowTemplate.Height = 29;
            this.gridViewPassword.Size = new System.Drawing.Size(825, 367);
            this.gridViewPassword.TabIndex = 1;
            this.gridViewPassword.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewPassword_CellClick);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.Location = new System.Drawing.Point(743, 7);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(94, 29);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAddPass
            // 
            this.btnAddPass.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAddPass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddPass.Location = new System.Drawing.Point(12, 119);
            this.btnAddPass.Name = "btnAddPass";
            this.btnAddPass.Size = new System.Drawing.Size(170, 35);
            this.btnAddPass.TabIndex = 1;
            this.btnAddPass.Text = "Add new password";
            this.btnAddPass.UseVisualStyleBackColor = false;
            this.btnAddPass.Click += new System.EventHandler(this.btnAddPass_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(743, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete ";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search website:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(132, 74);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(159, 27);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "All Passwords",
            "Work Password",
            "Personal Password"});
            this.cboCategory.Location = new System.Drawing.Point(394, 74);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(151, 28);
            this.cboCategory.TabIndex = 3;
            this.cboCategory.SelectionChangeCommitted += new System.EventHandler(this.cboCategory_SelectionChangeCommitted);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTime.Location = new System.Drawing.Point(423, 15);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(43, 15);
            this.lbTime.TabIndex = 6;
            this.lbTime.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter:";
            // 
            // frmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 546);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddPass);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.gridViewPassword);
            this.Controls.Add(this.lbHello);
            this.Name = "frmPassword";
            this.Text = "Password Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPassword_FormClosing);
            this.Load += new System.EventHandler(this.frmPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbHello;
        private DataGridView gridViewPassword;
        private Button btnLogout;
        private Button btnAddPass;
        private Button btnDelete;
        private Label label1;
        private TextBox txtSearch;
        private ComboBox cboCategory;
        private Label lbTime;
        private Label label2;
    }
}