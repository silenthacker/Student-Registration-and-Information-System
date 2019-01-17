namespace Application
{
    partial class ServerManualConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerManualConnectionForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TestConnectionButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.OKButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Asterisk3 = new System.Windows.Forms.Label();
            this.Asterisk4 = new System.Windows.Forms.Label();
            this.SqlServerPasswordTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.SqlServerUsernameTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DatabaseNameTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.ServerNameTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Asterisk2 = new System.Windows.Forms.Label();
            this.Asterisk1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "DATABASE NAME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "SERVER NAME:";
            // 
            // TestConnectionButton
            // 
            this.TestConnectionButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.TestConnectionButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TestConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.TestConnectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TestConnectionButton.BorderRadius = 2;
            this.TestConnectionButton.ButtonText = "TEST CONNECTION";
            this.TestConnectionButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.TestConnectionButton.DisabledColor = System.Drawing.Color.Gray;
            this.TestConnectionButton.Iconcolor = System.Drawing.Color.Transparent;
            this.TestConnectionButton.Iconimage = null;
            this.TestConnectionButton.Iconimage_right = null;
            this.TestConnectionButton.Iconimage_right_Selected = null;
            this.TestConnectionButton.Iconimage_Selected = null;
            this.TestConnectionButton.IconMarginLeft = 0;
            this.TestConnectionButton.IconMarginRight = 0;
            this.TestConnectionButton.IconRightVisible = true;
            this.TestConnectionButton.IconRightZoom = 0D;
            this.TestConnectionButton.IconVisible = true;
            this.TestConnectionButton.IconZoom = 90D;
            this.TestConnectionButton.IsTab = false;
            this.TestConnectionButton.Location = new System.Drawing.Point(196, 7);
            this.TestConnectionButton.Name = "TestConnectionButton";
            this.TestConnectionButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.TestConnectionButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.TestConnectionButton.OnHoverTextColor = System.Drawing.Color.White;
            this.TestConnectionButton.selected = false;
            this.TestConnectionButton.Size = new System.Drawing.Size(150, 30);
            this.TestConnectionButton.TabIndex = 14;
            this.TestConnectionButton.Text = "TEST CONNECTION";
            this.TestConnectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TestConnectionButton.Textcolor = System.Drawing.Color.White;
            this.TestConnectionButton.TextFont = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.TestConnectionButton.Click += new System.EventHandler(this.TestConnectionButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OKButton.BorderRadius = 2;
            this.OKButton.ButtonText = "SAVE";
            this.OKButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.OKButton.DisabledColor = System.Drawing.Color.Gray;
            this.OKButton.Iconcolor = System.Drawing.Color.Transparent;
            this.OKButton.Iconimage = null;
            this.OKButton.Iconimage_right = null;
            this.OKButton.Iconimage_right_Selected = null;
            this.OKButton.Iconimage_Selected = null;
            this.OKButton.IconMarginLeft = 0;
            this.OKButton.IconMarginRight = 0;
            this.OKButton.IconRightVisible = true;
            this.OKButton.IconRightZoom = 0D;
            this.OKButton.IconVisible = true;
            this.OKButton.IconZoom = 90D;
            this.OKButton.IsTab = false;
            this.OKButton.Location = new System.Drawing.Point(354, 7);
            this.OKButton.Name = "OKButton";
            this.OKButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.OKButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.OKButton.OnHoverTextColor = System.Drawing.Color.White;
            this.OKButton.selected = false;
            this.OKButton.Size = new System.Drawing.Size(90, 30);
            this.OKButton.TabIndex = 15;
            this.OKButton.Text = "SAVE";
            this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKButton.Textcolor = System.Drawing.Color.White;
            this.OKButton.TextFont = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.Asterisk3);
            this.groupBox1.Controls.Add(this.Asterisk4);
            this.groupBox1.Controls.Add(this.SqlServerPasswordTextbox);
            this.groupBox1.Controls.Add(this.SqlServerUsernameTextbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(45, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 185);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOG ON TO THE SERVER";
            // 
            // Asterisk3
            // 
            this.Asterisk3.AutoSize = true;
            this.Asterisk3.Font = new System.Drawing.Font("SF UI Display", 10F);
            this.Asterisk3.ForeColor = System.Drawing.Color.Red;
            this.Asterisk3.Location = new System.Drawing.Point(107, 30);
            this.Asterisk3.Name = "Asterisk3";
            this.Asterisk3.Size = new System.Drawing.Size(15, 16);
            this.Asterisk3.TabIndex = 16;
            this.Asterisk3.Text = "*";
            this.Asterisk3.Visible = false;
            // 
            // Asterisk4
            // 
            this.Asterisk4.AutoSize = true;
            this.Asterisk4.Font = new System.Drawing.Font("SF UI Display", 10F);
            this.Asterisk4.ForeColor = System.Drawing.Color.Red;
            this.Asterisk4.Location = new System.Drawing.Point(111, 95);
            this.Asterisk4.Name = "Asterisk4";
            this.Asterisk4.Size = new System.Drawing.Size(15, 16);
            this.Asterisk4.TabIndex = 17;
            this.Asterisk4.Text = "*";
            this.Asterisk4.Visible = false;
            // 
            // SqlServerPasswordTextbox
            // 
            this.SqlServerPasswordTextbox.BackColor = System.Drawing.Color.White;
            this.SqlServerPasswordTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.SqlServerPasswordTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SqlServerPasswordTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SqlServerPasswordTextbox.BorderThickness = 2;
            this.SqlServerPasswordTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SqlServerPasswordTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqlServerPasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SqlServerPasswordTextbox.isPassword = true;
            this.SqlServerPasswordTextbox.Location = new System.Drawing.Point(33, 114);
            this.SqlServerPasswordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.SqlServerPasswordTextbox.Name = "SqlServerPasswordTextbox";
            this.SqlServerPasswordTextbox.Size = new System.Drawing.Size(298, 35);
            this.SqlServerPasswordTextbox.TabIndex = 12;
            this.SqlServerPasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SqlServerPasswordTextbox.OnValueChanged += new System.EventHandler(this.SqlServerPasswordTextbox_OnValueChanged);
            this.SqlServerPasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerNameTextbox_KeyDown);
            // 
            // SqlServerUsernameTextbox
            // 
            this.SqlServerUsernameTextbox.BackColor = System.Drawing.Color.White;
            this.SqlServerUsernameTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.SqlServerUsernameTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SqlServerUsernameTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SqlServerUsernameTextbox.BorderThickness = 2;
            this.SqlServerUsernameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SqlServerUsernameTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqlServerUsernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SqlServerUsernameTextbox.isPassword = false;
            this.SqlServerUsernameTextbox.Location = new System.Drawing.Point(33, 49);
            this.SqlServerUsernameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.SqlServerUsernameTextbox.Name = "SqlServerUsernameTextbox";
            this.SqlServerUsernameTextbox.Size = new System.Drawing.Size(298, 35);
            this.SqlServerUsernameTextbox.TabIndex = 10;
            this.SqlServerUsernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SqlServerUsernameTextbox.OnValueChanged += new System.EventHandler(this.SqlServerUsernameTextbox_OnValueChanged);
            this.SqlServerUsernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerNameTextbox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "PASSWORD:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "USERNAME:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.TestConnectionButton);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 492);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 45);
            this.panel1.TabIndex = 13;
            // 
            // DatabaseNameTextbox
            // 
            this.DatabaseNameTextbox.BackColor = System.Drawing.Color.White;
            this.DatabaseNameTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.DatabaseNameTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DatabaseNameTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DatabaseNameTextbox.BorderThickness = 2;
            this.DatabaseNameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DatabaseNameTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseNameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DatabaseNameTextbox.isPassword = false;
            this.DatabaseNameTextbox.Location = new System.Drawing.Point(33, 219);
            this.DatabaseNameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.DatabaseNameTextbox.Name = "DatabaseNameTextbox";
            this.DatabaseNameTextbox.Size = new System.Drawing.Size(331, 35);
            this.DatabaseNameTextbox.TabIndex = 7;
            this.DatabaseNameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DatabaseNameTextbox.OnValueChanged += new System.EventHandler(this.DatabaseNameTextbox_OnValueChanged);
            this.DatabaseNameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerNameTextbox_KeyDown);
            // 
            // ServerNameTextbox
            // 
            this.ServerNameTextbox.BackColor = System.Drawing.Color.White;
            this.ServerNameTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.ServerNameTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ServerNameTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ServerNameTextbox.BorderThickness = 2;
            this.ServerNameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ServerNameTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerNameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ServerNameTextbox.isPassword = false;
            this.ServerNameTextbox.Location = new System.Drawing.Point(33, 156);
            this.ServerNameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.ServerNameTextbox.Name = "ServerNameTextbox";
            this.ServerNameTextbox.Size = new System.Drawing.Size(331, 35);
            this.ServerNameTextbox.TabIndex = 5;
            this.ServerNameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ServerNameTextbox.OnValueChanged += new System.EventHandler(this.ServerNameTextbox_OnValueChanged);
            this.ServerNameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerNameTextbox_KeyDown);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.panel2);
            this.bunifuCards1.Controls.Add(this.Asterisk2);
            this.bunifuCards1.Controls.Add(this.Asterisk1);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.panel1);
            this.bunifuCards1.Controls.Add(this.ServerNameTextbox);
            this.bunifuCards1.Controls.Add(this.DatabaseNameTextbox);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(455, 537);
            this.bunifuCards1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(-6, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 115);
            this.panel2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(430, 45);
            this.label3.TabIndex = 4;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "NOTE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(420, 45);
            this.label6.TabIndex = 6;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // Asterisk2
            // 
            this.Asterisk2.AutoSize = true;
            this.Asterisk2.Font = new System.Drawing.Font("SF UI Display", 10F);
            this.Asterisk2.ForeColor = System.Drawing.Color.Red;
            this.Asterisk2.Location = new System.Drawing.Point(146, 200);
            this.Asterisk2.Name = "Asterisk2";
            this.Asterisk2.Size = new System.Drawing.Size(15, 16);
            this.Asterisk2.TabIndex = 15;
            this.Asterisk2.Text = "*";
            this.Asterisk2.Visible = false;
            // 
            // Asterisk1
            // 
            this.Asterisk1.AutoSize = true;
            this.Asterisk1.Font = new System.Drawing.Font("SF UI Display", 10F);
            this.Asterisk1.ForeColor = System.Drawing.Color.Red;
            this.Asterisk1.Location = new System.Drawing.Point(128, 137);
            this.Asterisk1.Name = "Asterisk1";
            this.Asterisk1.Size = new System.Drawing.Size(15, 16);
            this.Asterisk1.TabIndex = 14;
            this.Asterisk1.Text = "*";
            this.Asterisk1.Visible = false;
            // 
            // ServerManualConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(479, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(495, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(495, 600);
            this.Name = "ServerManualConnectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATABASE MANUAL CONNECTION";
            this.Load += new System.EventHandler(this.ServerManualConnectionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton TestConnectionButton;
        private Bunifu.Framework.UI.BunifuFlatButton OKButton;
        private System.Windows.Forms.GroupBox groupBox1;
        public Bunifu.Framework.UI.BunifuMetroTextbox SqlServerPasswordTextbox;
        public Bunifu.Framework.UI.BunifuMetroTextbox SqlServerUsernameTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        public Bunifu.Framework.UI.BunifuMetroTextbox DatabaseNameTextbox;
        public Bunifu.Framework.UI.BunifuMetroTextbox ServerNameTextbox;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label Asterisk3;
        private System.Windows.Forms.Label Asterisk4;
        private System.Windows.Forms.Label Asterisk2;
        private System.Windows.Forms.Label Asterisk1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}