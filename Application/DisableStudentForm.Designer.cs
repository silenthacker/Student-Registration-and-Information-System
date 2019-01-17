namespace Application
{
    partial class DisableStudentForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisableStudentForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.bunifuCards3 = new Bunifu.Framework.UI.BunifuCards();
            this.UsersListGridView = new System.Windows.Forms.DataGridView();
            this.ColumnUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsPwdChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.UserIDTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RefreshPicture = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCards1.SuspendLayout();
            this.bunifuCards3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersListGridView)).BeginInit();
            this.bunifuCards2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.bunifuCards3);
            this.bunifuCards1.Controls.Add(this.bunifuCards2);
            this.bunifuCards1.LeftSahddow = true;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(1010, 507);
            this.bunifuCards1.TabIndex = 0;
            // 
            // bunifuCards3
            // 
            this.bunifuCards3.BackColor = System.Drawing.Color.White;
            this.bunifuCards3.BorderRadius = 0;
            this.bunifuCards3.BottomSahddow = false;
            this.bunifuCards3.color = System.Drawing.Color.Tomato;
            this.bunifuCards3.Controls.Add(this.UsersListGridView);
            this.bunifuCards3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards3.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCards3.LeftSahddow = false;
            this.bunifuCards3.Location = new System.Drawing.Point(0, 55);
            this.bunifuCards3.Name = "bunifuCards3";
            this.bunifuCards3.RightSahddow = false;
            this.bunifuCards3.ShadowDepth = 5;
            this.bunifuCards3.Size = new System.Drawing.Size(1010, 452);
            this.bunifuCards3.TabIndex = 2;
            // 
            // UsersListGridView
            // 
            this.UsersListGridView.AllowUserToAddRows = false;
            this.UsersListGridView.AllowUserToDeleteRows = false;
            this.UsersListGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.UsersListGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsersListGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UsersListGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UsersListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersListGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUserID,
            this.ColumnUsername,
            this.ColumnPassword,
            this.ColumnAccountStatus,
            this.ColumnAccountType,
            this.ColumnLastLogin,
            this.ColumnIsPwdChanged});
            this.UsersListGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersListGridView.EnableHeadersVisualStyles = false;
            this.UsersListGridView.GridColor = System.Drawing.Color.Silver;
            this.UsersListGridView.Location = new System.Drawing.Point(0, 0);
            this.UsersListGridView.Name = "UsersListGridView";
            this.UsersListGridView.ReadOnly = true;
            this.UsersListGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UsersListGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.UsersListGridView.RowHeadersWidth = 35;
            this.UsersListGridView.Size = new System.Drawing.Size(1010, 452);
            this.UsersListGridView.TabIndex = 3;
            this.UsersListGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisableStudentForm_KeyDown);
            // 
            // ColumnUserID
            // 
            this.ColumnUserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUserID.DataPropertyName = "USER ID";
            this.ColumnUserID.FillWeight = 83F;
            this.ColumnUserID.HeaderText = "USER ID";
            this.ColumnUserID.Name = "ColumnUserID";
            this.ColumnUserID.ReadOnly = true;
            // 
            // ColumnUsername
            // 
            this.ColumnUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUsername.DataPropertyName = "USERNAME";
            this.ColumnUsername.FillWeight = 97.84784F;
            this.ColumnUsername.HeaderText = "USERNAME";
            this.ColumnUsername.Name = "ColumnUsername";
            this.ColumnUsername.ReadOnly = true;
            // 
            // ColumnPassword
            // 
            this.ColumnPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPassword.DataPropertyName = "PASSWORD";
            this.ColumnPassword.FillWeight = 97.84784F;
            this.ColumnPassword.HeaderText = "PASSWORD";
            this.ColumnPassword.Name = "ColumnPassword";
            this.ColumnPassword.ReadOnly = true;
            // 
            // ColumnAccountStatus
            // 
            this.ColumnAccountStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAccountStatus.DataPropertyName = "ACCOUNT STATUS";
            this.ColumnAccountStatus.FillWeight = 70F;
            this.ColumnAccountStatus.HeaderText = "STATUS";
            this.ColumnAccountStatus.Name = "ColumnAccountStatus";
            this.ColumnAccountStatus.ReadOnly = true;
            // 
            // ColumnAccountType
            // 
            this.ColumnAccountType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAccountType.DataPropertyName = "ACCOUNT TYPE";
            this.ColumnAccountType.FillWeight = 71.95042F;
            this.ColumnAccountType.HeaderText = "ACC. TYPE";
            this.ColumnAccountType.Name = "ColumnAccountType";
            this.ColumnAccountType.ReadOnly = true;
            // 
            // ColumnLastLogin
            // 
            this.ColumnLastLogin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnLastLogin.DataPropertyName = "LAST LOGIN";
            this.ColumnLastLogin.FillWeight = 131.9767F;
            this.ColumnLastLogin.HeaderText = "LAST LOGIN";
            this.ColumnLastLogin.Name = "ColumnLastLogin";
            this.ColumnLastLogin.ReadOnly = true;
            // 
            // ColumnIsPwdChanged
            // 
            this.ColumnIsPwdChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIsPwdChanged.DataPropertyName = "IS PWD CHANGED";
            this.ColumnIsPwdChanged.FillWeight = 140F;
            this.ColumnIsPwdChanged.HeaderText = "PASSWORD CHANGED";
            this.ColumnIsPwdChanged.Name = "ColumnIsPwdChanged";
            this.ColumnIsPwdChanged.ReadOnly = true;
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.BackColor = System.Drawing.Color.White;
            this.bunifuCards2.BorderRadius = 0;
            this.bunifuCards2.BottomSahddow = false;
            this.bunifuCards2.color = System.Drawing.Color.White;
            this.bunifuCards2.Controls.Add(this.UserIDTextbox);
            this.bunifuCards2.Controls.Add(this.pictureBox2);
            this.bunifuCards2.Controls.Add(this.RefreshPicture);
            this.bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = false;
            this.bunifuCards2.ShadowDepth = 5;
            this.bunifuCards2.Size = new System.Drawing.Size(1010, 55);
            this.bunifuCards2.TabIndex = 1;
            // 
            // UserIDTextbox
            // 
            this.UserIDTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserIDTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserIDTextbox.Font = new System.Drawing.Font("SF UI Display", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UserIDTextbox.HintForeColor = System.Drawing.Color.DarkGray;
            this.UserIDTextbox.HintText = "Enter user id to disable";
            this.UserIDTextbox.isPassword = false;
            this.UserIDTextbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.UserIDTextbox.LineIdleColor = System.Drawing.Color.Gray;
            this.UserIDTextbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.UserIDTextbox.LineThickness = 3;
            this.UserIDTextbox.Location = new System.Drawing.Point(104, 12);
            this.UserIDTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.UserIDTextbox.Name = "UserIDTextbox";
            this.UserIDTextbox.Size = new System.Drawing.Size(340, 33);
            this.UserIDTextbox.TabIndex = 0;
            this.UserIDTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UserIDTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserIDTextbox_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::Application.Properties.Resources.disable;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(57, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 93;
            this.pictureBox2.TabStop = false;
            // 
            // RefreshPicture
            // 
            this.RefreshPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshPicture.BackColor = System.Drawing.Color.Transparent;
            this.RefreshPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.RefreshPicture.ErrorImage = null;
            this.RefreshPicture.Image = global::Application.Properties.Resources.refresh;
            this.RefreshPicture.InitialImage = null;
            this.RefreshPicture.Location = new System.Drawing.Point(13, 10);
            this.RefreshPicture.Name = "RefreshPicture";
            this.RefreshPicture.Size = new System.Drawing.Size(39, 39);
            this.RefreshPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RefreshPicture.TabIndex = 92;
            this.RefreshPicture.TabStop = false;
            this.RefreshPicture.Click += new System.EventHandler(this.RefreshPicture_Click);
            this.RefreshPicture.MouseLeave += new System.EventHandler(this.RefreshPicture_MouseLeave);
            this.RefreshPicture.MouseHover += new System.EventHandler(this.RefreshPicture_MouseHover);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this.UserIDTextbox;
            // 
            // DisableStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1034, 531);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1050, 570);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1050, 570);
            this.Name = "DisableStudentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DISABLE STUDENT";
            this.Load += new System.EventHandler(this.DisableStudentForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisableStudentForm_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersListGridView)).EndInit();
            this.bunifuCards2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private Bunifu.Framework.UI.BunifuCards bunifuCards3;
        private System.Windows.Forms.PictureBox RefreshPicture;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox UserIDTextbox;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.DataGridView UsersListGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsPwdChanged;
    }
}