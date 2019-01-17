namespace Application
{
    partial class ChangePasswordRequiredForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordRequiredForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.ConfirmPasswordTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.NewPasswordTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShowPasswordImg2 = new System.Windows.Forms.PictureBox();
            this.ShowPasswordImg1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.White;
            this.bunifuCards1.Controls.Add(this.ConfirmPasswordTextbox);
            this.bunifuCards1.Controls.Add(this.NewPasswordTextbox);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.ShowPasswordImg2);
            this.bunifuCards1.Controls.Add(this.ShowPasswordImg1);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.ChangeButton);
            this.bunifuCards1.Controls.Add(this.bunifuSeparator1);
            this.bunifuCards1.LeftSahddow = true;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(555, 283);
            this.bunifuCards1.TabIndex = 0;
            // 
            // ConfirmPasswordTextbox
            // 
            this.ConfirmPasswordTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.ConfirmPasswordTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmPasswordTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmPasswordTextbox.BorderThickness = 2;
            this.ConfirmPasswordTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ConfirmPasswordTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmPasswordTextbox.isPassword = true;
            this.ConfirmPasswordTextbox.Location = new System.Drawing.Point(39, 163);
            this.ConfirmPasswordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmPasswordTextbox.Name = "ConfirmPasswordTextbox";
            this.ConfirmPasswordTextbox.Size = new System.Drawing.Size(360, 35);
            this.ConfirmPasswordTextbox.TabIndex = 5;
            this.ConfirmPasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConfirmPasswordTextbox.OnValueChanged += new System.EventHandler(this.ConfirmPasswordTextbox_OnValueChanged);
            this.ConfirmPasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfirmPasswordTextbox_KeyDown);
            // 
            // NewPasswordTextbox
            // 
            this.NewPasswordTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.NewPasswordTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewPasswordTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewPasswordTextbox.BorderThickness = 2;
            this.NewPasswordTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewPasswordTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewPasswordTextbox.isPassword = true;
            this.NewPasswordTextbox.Location = new System.Drawing.Point(39, 97);
            this.NewPasswordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.NewPasswordTextbox.Name = "NewPasswordTextbox";
            this.NewPasswordTextbox.Size = new System.Drawing.Size(360, 35);
            this.NewPasswordTextbox.TabIndex = 3;
            this.NewPasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NewPasswordTextbox.OnValueChanged += new System.EventHandler(this.NewPasswordTextbox_OnValueChanged);
            this.NewPasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewPasswordTextbox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF UI Display", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 48);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ShowPasswordImg2
            // 
            this.ShowPasswordImg2.BackColor = System.Drawing.Color.Transparent;
            this.ShowPasswordImg2.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowPasswordImg2.ErrorImage = null;
            this.ShowPasswordImg2.Image = global::Application.Properties.Resources.Show;
            this.ShowPasswordImg2.InitialImage = null;
            this.ShowPasswordImg2.Location = new System.Drawing.Point(406, 171);
            this.ShowPasswordImg2.Name = "ShowPasswordImg2";
            this.ShowPasswordImg2.Size = new System.Drawing.Size(20, 20);
            this.ShowPasswordImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordImg2.TabIndex = 56;
            this.ShowPasswordImg2.TabStop = false;
            this.ShowPasswordImg2.Visible = false;
            this.ShowPasswordImg2.Click += new System.EventHandler(this.ShowPasswordImg2_Click);
            this.ShowPasswordImg2.MouseLeave += new System.EventHandler(this.ShowPasswordImg2_MouseLeave);
            this.ShowPasswordImg2.MouseHover += new System.EventHandler(this.ShowPasswordImg2_MouseHover);
            // 
            // ShowPasswordImg1
            // 
            this.ShowPasswordImg1.BackColor = System.Drawing.Color.Transparent;
            this.ShowPasswordImg1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowPasswordImg1.ErrorImage = null;
            this.ShowPasswordImg1.Image = global::Application.Properties.Resources.Show;
            this.ShowPasswordImg1.InitialImage = null;
            this.ShowPasswordImg1.Location = new System.Drawing.Point(406, 105);
            this.ShowPasswordImg1.Name = "ShowPasswordImg1";
            this.ShowPasswordImg1.Size = new System.Drawing.Size(20, 20);
            this.ShowPasswordImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordImg1.TabIndex = 55;
            this.ShowPasswordImg1.TabStop = false;
            this.ShowPasswordImg1.Visible = false;
            this.ShowPasswordImg1.Click += new System.EventHandler(this.ShowPasswordImg1_Click);
            this.ShowPasswordImg1.MouseLeave += new System.EventHandler(this.ShowPasswordImg1_MouseLeave);
            this.ShowPasswordImg1.MouseHover += new System.EventHandler(this.ShowPasswordImg1_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "CONFIRM PASSWORD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "NEW PASSWORD:";
            // 
            // ChangeButton
            // 
            this.ChangeButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ChangeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChangeButton.BorderRadius = 2;
            this.ChangeButton.ButtonText = "UPDATE";
            this.ChangeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChangeButton.DisabledColor = System.Drawing.Color.Gray;
            this.ChangeButton.Iconcolor = System.Drawing.Color.Transparent;
            this.ChangeButton.Iconimage = null;
            this.ChangeButton.Iconimage_right = null;
            this.ChangeButton.Iconimage_right_Selected = null;
            this.ChangeButton.Iconimage_Selected = null;
            this.ChangeButton.IconMarginLeft = 0;
            this.ChangeButton.IconMarginRight = 0;
            this.ChangeButton.IconRightVisible = false;
            this.ChangeButton.IconRightZoom = 0D;
            this.ChangeButton.IconVisible = false;
            this.ChangeButton.IconZoom = 90D;
            this.ChangeButton.IsTab = false;
            this.ChangeButton.Location = new System.Drawing.Point(448, 239);
            this.ChangeButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ChangeButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ChangeButton.OnHoverTextColor = System.Drawing.Color.White;
            this.ChangeButton.selected = false;
            this.ChangeButton.Size = new System.Drawing.Size(90, 30);
            this.ChangeButton.TabIndex = 7;
            this.ChangeButton.Text = "UPDATE";
            this.ChangeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChangeButton.Textcolor = System.Drawing.Color.White;
            this.ChangeButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            this.ChangeButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangePasswordRequiredForm_KeyDown);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(17, 222);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(521, 11);
            this.bunifuSeparator1.TabIndex = 6;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangePasswordRequiredForm_KeyDown);
            // 
            // ChangePasswordRequiredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(579, 307);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(595, 346);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(595, 346);
            this.Name = "ChangePasswordRequiredForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REQUIRED ACTIONS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangePasswordRequiredForm_FormClosing);
            this.Load += new System.EventHandler(this.ChangePasswordRequiredForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangePasswordRequiredForm_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuFlatButton ChangeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ShowPasswordImg2;
        private System.Windows.Forms.PictureBox ShowPasswordImg1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMetroTextbox NewPasswordTextbox;
        private Bunifu.Framework.UI.BunifuMetroTextbox ConfirmPasswordTextbox;
    }
}