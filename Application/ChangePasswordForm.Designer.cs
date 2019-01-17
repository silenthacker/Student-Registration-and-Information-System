namespace Application
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.ConfirmPasswordTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.NewPasswordTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.OldPasswordTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.ShowPasswordImg3 = new System.Windows.Forms.PictureBox();
            this.ShowPasswordImg2 = new System.Windows.Forms.PictureBox();
            this.ShowPasswordImg1 = new System.Windows.Forms.PictureBox();
            this.SubmitButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.CloseButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg3)).BeginInit();
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
            this.bunifuCards1.Controls.Add(this.OldPasswordTextbox);
            this.bunifuCards1.Controls.Add(this.ShowPasswordImg3);
            this.bunifuCards1.Controls.Add(this.ShowPasswordImg2);
            this.bunifuCards1.Controls.Add(this.ShowPasswordImg1);
            this.bunifuCards1.Controls.Add(this.SubmitButton);
            this.bunifuCards1.Controls.Add(this.CloseButton);
            this.bunifuCards1.Controls.Add(this.bunifuSeparator1);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.LeftSahddow = true;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(555, 282);
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
            this.ConfirmPasswordTextbox.Location = new System.Drawing.Point(39, 164);
            this.ConfirmPasswordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmPasswordTextbox.Name = "ConfirmPasswordTextbox";
            this.ConfirmPasswordTextbox.Size = new System.Drawing.Size(360, 35);
            this.ConfirmPasswordTextbox.TabIndex = 2;
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
            this.NewPasswordTextbox.Location = new System.Drawing.Point(39, 106);
            this.NewPasswordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.NewPasswordTextbox.Name = "NewPasswordTextbox";
            this.NewPasswordTextbox.Size = new System.Drawing.Size(360, 35);
            this.NewPasswordTextbox.TabIndex = 1;
            this.NewPasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NewPasswordTextbox.OnValueChanged += new System.EventHandler(this.NewPasswordTextbox_OnValueChanged);
            this.NewPasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewPasswordTextbox_KeyDown);
            // 
            // OldPasswordTextbox
            // 
            this.OldPasswordTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.OldPasswordTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OldPasswordTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OldPasswordTextbox.BorderThickness = 2;
            this.OldPasswordTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OldPasswordTextbox.Enabled = false;
            this.OldPasswordTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OldPasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OldPasswordTextbox.isPassword = true;
            this.OldPasswordTextbox.Location = new System.Drawing.Point(39, 48);
            this.OldPasswordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.OldPasswordTextbox.Name = "OldPasswordTextbox";
            this.OldPasswordTextbox.Size = new System.Drawing.Size(360, 35);
            this.OldPasswordTextbox.TabIndex = 0;
            this.OldPasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OldPasswordTextbox.OnValueChanged += new System.EventHandler(this.OldPasswordTextbox_OnValueChanged);
            this.OldPasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OldPasswordTextbox_KeyDown);
            // 
            // ShowPasswordImg3
            // 
            this.ShowPasswordImg3.BackColor = System.Drawing.Color.Transparent;
            this.ShowPasswordImg3.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowPasswordImg3.ErrorImage = null;
            this.ShowPasswordImg3.Image = global::Application.Properties.Resources.Show;
            this.ShowPasswordImg3.InitialImage = null;
            this.ShowPasswordImg3.Location = new System.Drawing.Point(406, 173);
            this.ShowPasswordImg3.Name = "ShowPasswordImg3";
            this.ShowPasswordImg3.Size = new System.Drawing.Size(20, 20);
            this.ShowPasswordImg3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordImg3.TabIndex = 56;
            this.ShowPasswordImg3.TabStop = false;
            this.ShowPasswordImg3.Visible = false;
            this.ShowPasswordImg3.Click += new System.EventHandler(this.ShowPasswordImg3_Click);
            this.ShowPasswordImg3.MouseLeave += new System.EventHandler(this.ShowPasswordImg3_MouseLeave);
            this.ShowPasswordImg3.MouseHover += new System.EventHandler(this.ShowPasswordImg3_MouseHover);
            // 
            // ShowPasswordImg2
            // 
            this.ShowPasswordImg2.BackColor = System.Drawing.Color.Transparent;
            this.ShowPasswordImg2.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowPasswordImg2.ErrorImage = null;
            this.ShowPasswordImg2.Image = global::Application.Properties.Resources.Show;
            this.ShowPasswordImg2.InitialImage = null;
            this.ShowPasswordImg2.Location = new System.Drawing.Point(406, 115);
            this.ShowPasswordImg2.Name = "ShowPasswordImg2";
            this.ShowPasswordImg2.Size = new System.Drawing.Size(20, 20);
            this.ShowPasswordImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordImg2.TabIndex = 55;
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
            this.ShowPasswordImg1.Location = new System.Drawing.Point(406, 57);
            this.ShowPasswordImg1.Name = "ShowPasswordImg1";
            this.ShowPasswordImg1.Size = new System.Drawing.Size(20, 20);
            this.ShowPasswordImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordImg1.TabIndex = 54;
            this.ShowPasswordImg1.TabStop = false;
            this.ShowPasswordImg1.Click += new System.EventHandler(this.ShowPasswordImg1_Click);
            this.ShowPasswordImg1.MouseLeave += new System.EventHandler(this.ShowPasswordImg1_MouseLeave);
            this.ShowPasswordImg1.MouseHover += new System.EventHandler(this.ShowPasswordImg1_MouseHover);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SubmitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubmitButton.BorderRadius = 2;
            this.SubmitButton.ButtonText = "UPDATE";
            this.SubmitButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SubmitButton.DisabledColor = System.Drawing.Color.Gray;
            this.SubmitButton.Iconcolor = System.Drawing.Color.Transparent;
            this.SubmitButton.Iconimage = null;
            this.SubmitButton.Iconimage_right = null;
            this.SubmitButton.Iconimage_right_Selected = null;
            this.SubmitButton.Iconimage_Selected = null;
            this.SubmitButton.IconMarginLeft = 0;
            this.SubmitButton.IconMarginRight = 0;
            this.SubmitButton.IconRightVisible = false;
            this.SubmitButton.IconRightZoom = 0D;
            this.SubmitButton.IconVisible = false;
            this.SubmitButton.IconZoom = 90D;
            this.SubmitButton.IsTab = false;
            this.SubmitButton.Location = new System.Drawing.Point(348, 239);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SubmitButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.SubmitButton.OnHoverTextColor = System.Drawing.Color.White;
            this.SubmitButton.selected = false;
            this.SubmitButton.Size = new System.Drawing.Size(90, 30);
            this.SubmitButton.TabIndex = 0;
            this.SubmitButton.Text = "UPDATE";
            this.SubmitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SubmitButton.Textcolor = System.Drawing.Color.White;
            this.SubmitButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            this.SubmitButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OldPasswordTextbox_KeyDown);
            // 
            // CloseButton
            // 
            this.CloseButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseButton.BorderRadius = 2;
            this.CloseButton.ButtonText = "CLOSE";
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.CloseButton.DisabledColor = System.Drawing.Color.Gray;
            this.CloseButton.Iconcolor = System.Drawing.Color.Transparent;
            this.CloseButton.Iconimage = null;
            this.CloseButton.Iconimage_right = null;
            this.CloseButton.Iconimage_right_Selected = null;
            this.CloseButton.Iconimage_Selected = null;
            this.CloseButton.IconMarginLeft = 0;
            this.CloseButton.IconMarginRight = 0;
            this.CloseButton.IconRightVisible = false;
            this.CloseButton.IconRightZoom = 0D;
            this.CloseButton.IconVisible = false;
            this.CloseButton.IconZoom = 90D;
            this.CloseButton.IsTab = false;
            this.CloseButton.Location = new System.Drawing.Point(448, 239);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.CloseButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.CloseButton.OnHoverTextColor = System.Drawing.Color.White;
            this.CloseButton.selected = false;
            this.CloseButton.Size = new System.Drawing.Size(90, 30);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Textcolor = System.Drawing.Color.White;
            this.CloseButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OldPasswordTextbox_KeyDown);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(17, 222);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(521, 11);
            this.bunifuSeparator1.TabIndex = 0;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OldPasswordTextbox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "NEW PASSWORD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "CONFIRM PASSWORD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "OLD PASSWORD:";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(579, 307);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(595, 346);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(595, 346);
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHANGE PASSWORD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangePasswordForm_FormClosing);
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuFlatButton SubmitButton;
        private Bunifu.Framework.UI.BunifuFlatButton CloseButton;
        private System.Windows.Forms.PictureBox ShowPasswordImg3;
        private System.Windows.Forms.PictureBox ShowPasswordImg2;
        private System.Windows.Forms.PictureBox ShowPasswordImg1;
        private Bunifu.Framework.UI.BunifuMetroTextbox ConfirmPasswordTextbox;
        private Bunifu.Framework.UI.BunifuMetroTextbox NewPasswordTextbox;
        private Bunifu.Framework.UI.BunifuMetroTextbox OldPasswordTextbox;
    }
}