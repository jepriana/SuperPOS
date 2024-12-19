namespace SuperPOS.Views.Users
{
    partial class UserForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iconButtonAdd = new FontAwesome.Sharp.IconButton();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.iconButtonPrint = new FontAwesome.Sharp.IconButton();
            this.iconButtonDownload = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Username,
            this.FirstName,
            this.LastName,
            this.EmailAddress,
            this.Phone,
            this.IsAdmin});
            this.dataGridViewMain.Location = new System.Drawing.Point(12, 58);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.Size = new System.Drawing.Size(776, 380);
            this.dataGridViewMain.TabIndex = 0;
            this.dataGridViewMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellClick);
            this.dataGridViewMain.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewMain_CellPainting);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 150;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.Width = 150;
            // 
            // EmailAddress
            // 
            this.EmailAddress.HeaderText = "Email Address";
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Width = 150;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // IsAdmin
            // 
            this.IsAdmin.HeaderText = "Is Admin?";
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.Width = 75;
            // 
            // iconButtonAdd
            // 
            this.iconButtonAdd.BackColor = System.Drawing.Color.DarkViolet;
            this.iconButtonAdd.FlatAppearance.BorderSize = 0;
            this.iconButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.iconButtonAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonAdd.IconColor = System.Drawing.SystemColors.Control;
            this.iconButtonAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonAdd.IconSize = 32;
            this.iconButtonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonAdd.Location = new System.Drawing.Point(12, 12);
            this.iconButtonAdd.Name = "iconButtonAdd";
            this.iconButtonAdd.Size = new System.Drawing.Size(100, 40);
            this.iconButtonAdd.TabIndex = 1;
            this.iconButtonAdd.Text = "New";
            this.iconButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonAdd.UseVisualStyleBackColor = false;
            this.iconButtonAdd.Click += new System.EventHandler(this.iconButtonAdd_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSearch.Controls.Add(this.iconButton1);
            this.panelSearch.Controls.Add(this.textBoxUsername);
            this.panelSearch.Location = new System.Drawing.Point(488, 12);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(300, 40);
            this.panelSearch.TabIndex = 2;
            // 
            // iconButton1
            // 
            this.iconButton1.Enabled = false;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconButton1.IconColor = System.Drawing.Color.DarkViolet;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.Location = new System.Drawing.Point(0, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(40, 40);
            this.iconButton1.TabIndex = 8;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(46, 6);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(245, 28);
            this.textBoxUsername.TabIndex = 7;
            // 
            // iconButtonPrint
            // 
            this.iconButtonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButtonPrint.FlatAppearance.BorderSize = 0;
            this.iconButtonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconButtonPrint.IconColor = System.Drawing.Color.DarkViolet;
            this.iconButtonPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonPrint.IconSize = 32;
            this.iconButtonPrint.Location = new System.Drawing.Point(396, 12);
            this.iconButtonPrint.Name = "iconButtonPrint";
            this.iconButtonPrint.Size = new System.Drawing.Size(40, 40);
            this.iconButtonPrint.TabIndex = 9;
            this.iconButtonPrint.UseVisualStyleBackColor = true;
            this.iconButtonPrint.Click += new System.EventHandler(this.iconButtonPrint_Click);
            // 
            // iconButtonDownload
            // 
            this.iconButtonDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButtonDownload.FlatAppearance.BorderSize = 0;
            this.iconButtonDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonDownload.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.iconButtonDownload.IconColor = System.Drawing.Color.DarkViolet;
            this.iconButtonDownload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonDownload.IconSize = 32;
            this.iconButtonDownload.Location = new System.Drawing.Point(442, 12);
            this.iconButtonDownload.Name = "iconButtonDownload";
            this.iconButtonDownload.Size = new System.Drawing.Size(40, 40);
            this.iconButtonDownload.TabIndex = 10;
            this.iconButtonDownload.UseVisualStyleBackColor = true;
            this.iconButtonDownload.Click += new System.EventHandler(this.iconButtonDownload_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.iconButtonDownload);
            this.Controls.Add(this.iconButtonPrint);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.iconButtonAdd);
            this.Controls.Add(this.dataGridViewMain);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMain;
        private FontAwesome.Sharp.IconButton iconButtonAdd;
        private System.Windows.Forms.Panel panelSearch;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox textBoxUsername;
        private FontAwesome.Sharp.IconButton iconButtonPrint;
        private FontAwesome.Sharp.IconButton iconButtonDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAdmin;
    }
}