namespace Application
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.LoginButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.PasswordTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.UsernameTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoginErrorMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.CloseTopButton = new System.Windows.Forms.PictureBox();
            this.MaximizeTopButton = new System.Windows.Forms.PictureBox();
            this.MinimizeTopButton = new System.Windows.Forms.PictureBox();
            this.SqlServerSettingsButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseTopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximizeTopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeTopButton)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuCards1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuCards1.BorderRadius = 4;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuCards1.Controls.Add(this.LoginButton);
            this.bunifuCards1.Controls.Add(this.PasswordTextbox);
            this.bunifuCards1.Controls.Add(this.UsernameTextbox);
            this.bunifuCards1.Controls.Add(this.label5);
            this.bunifuCards1.Controls.Add(this.label4);
            this.bunifuCards1.Controls.Add(this.LoginErrorMessage);
            this.bunifuCards1.Controls.Add(this.pictureBox1);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.LeftSahddow = true;
            this.bunifuCards1.Location = new System.Drawing.Point(453, 132);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 10;
            this.bunifuCards1.Size = new System.Drawing.Size(460, 505);
            this.bunifuCards1.TabIndex = 13;
            // 
            // LoginButton
            // 
            this.LoginButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginButton.BorderRadius = 3;
            this.LoginButton.ButtonText = "LOGIN";
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.LoginButton.DisabledColor = System.Drawing.Color.Gray;
            this.LoginButton.Iconcolor = System.Drawing.Color.Transparent;
            this.LoginButton.Iconimage = null;
            this.LoginButton.Iconimage_right = null;
            this.LoginButton.Iconimage_right_Selected = null;
            this.LoginButton.Iconimage_Selected = null;
            this.LoginButton.IconMarginLeft = 0;
            this.LoginButton.IconMarginRight = 0;
            this.LoginButton.IconRightVisible = false;
            this.LoginButton.IconRightZoom = 0D;
            this.LoginButton.IconVisible = false;
            this.LoginButton.IconZoom = 0D;
            this.LoginButton.IsTab = false;
            this.LoginButton.Location = new System.Drawing.Point(46, 413);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.LoginButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(65)))));
            this.LoginButton.OnHoverTextColor = System.Drawing.Color.White;
            this.LoginButton.selected = false;
            this.LoginButton.Size = new System.Drawing.Size(370, 48);
            this.LoginButton.TabIndex = 9;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginButton.Textcolor = System.Drawing.Color.WhiteSmoke;
            this.LoginButton.TextFont = new System.Drawing.Font("SF UI Display", 14F, System.Drawing.FontStyle.Bold);
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            this.LoginButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordTextbox.BorderThickness = 3;
            this.PasswordTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordTextbox.Font = new System.Drawing.Font("SF UI Display", 12F, System.Drawing.FontStyle.Bold);
            this.PasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordTextbox.isPassword = true;
            this.PasswordTextbox.Location = new System.Drawing.Point(48, 297);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(370, 47);
            this.PasswordTextbox.TabIndex = 8;
            this.PasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasswordTextbox.OnValueChanged += new System.EventHandler(this.PasswordTextbox_OnValueChanged);
            this.PasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextbox_KeyDown);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsernameTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsernameTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsernameTextbox.BorderThickness = 3;
            this.UsernameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameTextbox.Font = new System.Drawing.Font("SF UI Display", 12F, System.Drawing.FontStyle.Bold);
            this.UsernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsernameTextbox.isPassword = false;
            this.UsernameTextbox.Location = new System.Drawing.Point(48, 213);
            this.UsernameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(370, 47);
            this.UsernameTextbox.TabIndex = 7;
            this.UsernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameTextbox.OnValueChanged += new System.EventHandler(this.UsernameTextbox_OnValueChanged);
            this.UsernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameTextbox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("SF UI Display", 13F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(47, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "PASSWORD:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("SF UI Display", 13F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(46, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "USERNAME:";
            // 
            // LoginErrorMessage
            // 
            this.LoginErrorMessage.AutoSize = true;
            this.LoginErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.LoginErrorMessage.Font = new System.Drawing.Font("SF UI Display", 12F, System.Drawing.FontStyle.Bold);
            this.LoginErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.LoginErrorMessage.Location = new System.Drawing.Point(141, 137);
            this.LoginErrorMessage.Name = "LoginErrorMessage";
            this.LoginErrorMessage.Size = new System.Drawing.Size(181, 19);
            this.LoginErrorMessage.TabIndex = 4;
            this.LoginErrorMessage.Text = "USERNAME REQUIRED !";
            this.LoginErrorMessage.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Application.Properties.Resources.BukSU_Logo_299x300;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(46, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("SF UI Display", 9.75F);
            this.label2.Location = new System.Drawing.Point(164, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "BUKIDNON STATE UNIVERSITY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SF UI Display", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(164, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "SECONDARY LABORATORY SCHOOL";
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1366, 24);
            this.MenuStrip.TabIndex = 39;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // CloseTopButton
            // 
            this.CloseTopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseTopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.CloseTopButton.ErrorImage = null;
            this.CloseTopButton.Image = global::Application.Properties.Resources.Close_Button;
            this.CloseTopButton.InitialImage = null;
            this.CloseTopButton.Location = new System.Drawing.Point(1336, 3);
            this.CloseTopButton.Name = "CloseTopButton";
            this.CloseTopButton.Size = new System.Drawing.Size(16, 16);
            this.CloseTopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseTopButton.TabIndex = 29;
            this.CloseTopButton.TabStop = false;
            this.CloseTopButton.Click += new System.EventHandler(this.CloseTopButton_Click);
            this.CloseTopButton.MouseLeave += new System.EventHandler(this.CloseTopButton_MouseLeave);
            this.CloseTopButton.MouseHover += new System.EventHandler(this.CloseTopButton_MouseHover);
            // 
            // MaximizeTopButton
            // 
            this.MaximizeTopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeTopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.MaximizeTopButton.ErrorImage = null;
            this.MaximizeTopButton.Image = global::Application.Properties.Resources.Miximized_Button;
            this.MaximizeTopButton.InitialImage = null;
            this.MaximizeTopButton.Location = new System.Drawing.Point(1290, 3);
            this.MaximizeTopButton.Name = "MaximizeTopButton";
            this.MaximizeTopButton.Size = new System.Drawing.Size(16, 16);
            this.MaximizeTopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MaximizeTopButton.TabIndex = 28;
            this.MaximizeTopButton.TabStop = false;
            this.MaximizeTopButton.Click += new System.EventHandler(this.MaximizeTopButton_Click);
            this.MaximizeTopButton.MouseLeave += new System.EventHandler(this.MaximizeTopButton_MouseLeave);
            this.MaximizeTopButton.MouseHover += new System.EventHandler(this.MaximizeTopButton_MouseHover);
            // 
            // MinimizeTopButton
            // 
            this.MinimizeTopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeTopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.MinimizeTopButton.ErrorImage = null;
            this.MinimizeTopButton.Image = global::Application.Properties.Resources.Minimized_Button;
            this.MinimizeTopButton.InitialImage = null;
            this.MinimizeTopButton.Location = new System.Drawing.Point(1313, 3);
            this.MinimizeTopButton.Name = "MinimizeTopButton";
            this.MinimizeTopButton.Size = new System.Drawing.Size(16, 16);
            this.MinimizeTopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MinimizeTopButton.TabIndex = 27;
            this.MinimizeTopButton.TabStop = false;
            this.MinimizeTopButton.Click += new System.EventHandler(this.MinimizeTopButton_Click);
            this.MinimizeTopButton.MouseLeave += new System.EventHandler(this.MinimizeTopButton_MouseLeave);
            this.MinimizeTopButton.MouseHover += new System.EventHandler(this.MinimizeTopButton_MouseHover);
            // 
            // SqlServerSettingsButton
            // 
            this.SqlServerSettingsButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(94)))), ((int)(((byte)(70)))));
            this.SqlServerSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SqlServerSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(94)))), ((int)(((byte)(70)))));
            this.SqlServerSettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SqlServerSettingsButton.BorderRadius = 2;
            this.SqlServerSettingsButton.ButtonText = "SQL SERVER CONFIGURATION";
            this.SqlServerSettingsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SqlServerSettingsButton.DisabledColor = System.Drawing.Color.Gray;
            this.SqlServerSettingsButton.Iconcolor = System.Drawing.Color.Transparent;
            this.SqlServerSettingsButton.Iconimage = global::Application.Properties.Resources.settings;
            this.SqlServerSettingsButton.Iconimage_right = null;
            this.SqlServerSettingsButton.Iconimage_right_Selected = null;
            this.SqlServerSettingsButton.Iconimage_Selected = null;
            this.SqlServerSettingsButton.IconMarginLeft = 0;
            this.SqlServerSettingsButton.IconMarginRight = 0;
            this.SqlServerSettingsButton.IconRightVisible = true;
            this.SqlServerSettingsButton.IconRightZoom = 0D;
            this.SqlServerSettingsButton.IconVisible = true;
            this.SqlServerSettingsButton.IconZoom = 40D;
            this.SqlServerSettingsButton.IsTab = false;
            this.SqlServerSettingsButton.Location = new System.Drawing.Point(1127, 30);
            this.SqlServerSettingsButton.Name = "SqlServerSettingsButton";
            this.SqlServerSettingsButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(94)))), ((int)(((byte)(70)))));
            this.SqlServerSettingsButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(84)))), ((int)(((byte)(62)))));
            this.SqlServerSettingsButton.OnHoverTextColor = System.Drawing.Color.White;
            this.SqlServerSettingsButton.selected = false;
            this.SqlServerSettingsButton.Size = new System.Drawing.Size(235, 29);
            this.SqlServerSettingsButton.TabIndex = 12;
            this.SqlServerSettingsButton.Text = "SQL SERVER CONFIGURATION";
            this.SqlServerSettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SqlServerSettingsButton.Textcolor = System.Drawing.Color.White;
            this.SqlServerSettingsButton.TextFont = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.SqlServerSettingsButton.Click += new System.EventHandler(this.SqlServerSettingsButton_Click);
            this.SqlServerSettingsButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.CloseTopButton);
            this.Controls.Add(this.MaximizeTopButton);
            this.Controls.Add(this.MinimizeTopButton);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.SqlServerSettingsButton);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STUDENT REGISTRATION AND INFORMATION SYSTEM, JUNIOR DEPARTMENT -  MEMBER LOGIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseTopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximizeTopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeTopButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton SqlServerSettingsButton;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public Bunifu.Framework.UI.BunifuMetroTextbox PasswordTextbox;
        public Bunifu.Framework.UI.BunifuMetroTextbox UsernameTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label LoginErrorMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox CloseTopButton;
        private System.Windows.Forms.PictureBox MaximizeTopButton;
        private System.Windows.Forms.PictureBox MinimizeTopButton;
        private System.Windows.Forms.MenuStrip MenuStrip;
        public Bunifu.Framework.UI.BunifuFlatButton LoginButton;
    }
}

