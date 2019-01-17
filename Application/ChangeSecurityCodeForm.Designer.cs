namespace Application
{
    partial class ChangeSecurityCodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeSecurityCodeForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.ConfirmSecurityCodeTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.NewSecurityCodeTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.CurrentSecurityCodeTextbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.ShowPasswordImg3 = new System.Windows.Forms.PictureBox();
            this.ShowPasswordImg2 = new System.Windows.Forms.PictureBox();
            this.ShowPasswordImg1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdateButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.MsgImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MsgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.ConfirmSecurityCodeTextbox);
            this.bunifuCards1.Controls.Add(this.NewSecurityCodeTextbox);
            this.bunifuCards1.Controls.Add(this.CurrentSecurityCodeTextbox);
            this.bunifuCards1.Controls.Add(this.ShowPasswordImg3);
            this.bunifuCards1.Controls.Add(this.ShowPasswordImg2);
            this.bunifuCards1.Controls.Add(this.ShowPasswordImg1);
            this.bunifuCards1.Controls.Add(this.label5);
            this.bunifuCards1.Controls.Add(this.label4);
            this.bunifuCards1.Controls.Add(this.UpdateButton);
            this.bunifuCards1.Controls.Add(this.bunifuSeparator2);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.MsgImage);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(555, 298);
            this.bunifuCards1.TabIndex = 0;
            // 
            // ConfirmSecurityCodeTextbox
            // 
            this.ConfirmSecurityCodeTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.ConfirmSecurityCodeTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmSecurityCodeTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmSecurityCodeTextbox.BorderThickness = 2;
            this.ConfirmSecurityCodeTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ConfirmSecurityCodeTextbox.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.ConfirmSecurityCodeTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmSecurityCodeTextbox.isPassword = true;
            this.ConfirmSecurityCodeTextbox.Location = new System.Drawing.Point(149, 188);
            this.ConfirmSecurityCodeTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmSecurityCodeTextbox.Name = "ConfirmSecurityCodeTextbox";
            this.ConfirmSecurityCodeTextbox.Size = new System.Drawing.Size(330, 35);
            this.ConfirmSecurityCodeTextbox.TabIndex = 8;
            this.ConfirmSecurityCodeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConfirmSecurityCodeTextbox.OnValueChanged += new System.EventHandler(this.ConfirmSecurityCodeTextbox_OnValueChanged);
            this.ConfirmSecurityCodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeSecurityCodeForm_KeyDown);
            // 
            // NewSecurityCodeTextbox
            // 
            this.NewSecurityCodeTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.NewSecurityCodeTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewSecurityCodeTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewSecurityCodeTextbox.BorderThickness = 2;
            this.NewSecurityCodeTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewSecurityCodeTextbox.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.NewSecurityCodeTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewSecurityCodeTextbox.isPassword = true;
            this.NewSecurityCodeTextbox.Location = new System.Drawing.Point(149, 127);
            this.NewSecurityCodeTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.NewSecurityCodeTextbox.Name = "NewSecurityCodeTextbox";
            this.NewSecurityCodeTextbox.Size = new System.Drawing.Size(330, 35);
            this.NewSecurityCodeTextbox.TabIndex = 6;
            this.NewSecurityCodeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NewSecurityCodeTextbox.OnValueChanged += new System.EventHandler(this.NewSecurityCodeTextbox_OnValueChanged);
            this.NewSecurityCodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeSecurityCodeForm_KeyDown);
            // 
            // CurrentSecurityCodeTextbox
            // 
            this.CurrentSecurityCodeTextbox.BorderColorFocused = System.Drawing.Color.Teal;
            this.CurrentSecurityCodeTextbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CurrentSecurityCodeTextbox.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CurrentSecurityCodeTextbox.BorderThickness = 2;
            this.CurrentSecurityCodeTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CurrentSecurityCodeTextbox.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.CurrentSecurityCodeTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CurrentSecurityCodeTextbox.isPassword = true;
            this.CurrentSecurityCodeTextbox.Location = new System.Drawing.Point(149, 66);
            this.CurrentSecurityCodeTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentSecurityCodeTextbox.Name = "CurrentSecurityCodeTextbox";
            this.CurrentSecurityCodeTextbox.Size = new System.Drawing.Size(330, 35);
            this.CurrentSecurityCodeTextbox.TabIndex = 4;
            this.CurrentSecurityCodeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CurrentSecurityCodeTextbox.OnValueChanged += new System.EventHandler(this.CurrentSecurityCodeTextbox_OnValueChanged);
            this.CurrentSecurityCodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeSecurityCodeForm_KeyDown);
            // 
            // ShowPasswordImg3
            // 
            this.ShowPasswordImg3.BackColor = System.Drawing.Color.Transparent;
            this.ShowPasswordImg3.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowPasswordImg3.ErrorImage = null;
            this.ShowPasswordImg3.Image = global::Application.Properties.Resources.Show;
            this.ShowPasswordImg3.InitialImage = null;
            this.ShowPasswordImg3.Location = new System.Drawing.Point(492, 194);
            this.ShowPasswordImg3.Name = "ShowPasswordImg3";
            this.ShowPasswordImg3.Size = new System.Drawing.Size(23, 23);
            this.ShowPasswordImg3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordImg3.TabIndex = 57;
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
            this.ShowPasswordImg2.Location = new System.Drawing.Point(492, 133);
            this.ShowPasswordImg2.Name = "ShowPasswordImg2";
            this.ShowPasswordImg2.Size = new System.Drawing.Size(23, 23);
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
            this.ShowPasswordImg1.Location = new System.Drawing.Point(492, 72);
            this.ShowPasswordImg1.Name = "ShowPasswordImg1";
            this.ShowPasswordImg1.Size = new System.Drawing.Size(23, 23);
            this.ShowPasswordImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordImg1.TabIndex = 55;
            this.ShowPasswordImg1.TabStop = false;
            this.ShowPasswordImg1.Visible = false;
            this.ShowPasswordImg1.Click += new System.EventHandler(this.ShowPasswordImg1_Click);
            this.ShowPasswordImg1.MouseLeave += new System.EventHandler(this.ShowPasswordImg1_MouseLeave);
            this.ShowPasswordImg1.MouseHover += new System.EventHandler(this.ShowPasswordImg1_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(147, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "CONFIRM SECURITY CODE:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(147, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "NEW SECURITY CODE:";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateButton.BorderRadius = 2;
            this.UpdateButton.ButtonText = "UPDATE AND CLOSE";
            this.UpdateButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.UpdateButton.DisabledColor = System.Drawing.Color.Gray;
            this.UpdateButton.Iconcolor = System.Drawing.Color.Transparent;
            this.UpdateButton.Iconimage = null;
            this.UpdateButton.Iconimage_right = null;
            this.UpdateButton.Iconimage_right_Selected = null;
            this.UpdateButton.Iconimage_Selected = null;
            this.UpdateButton.IconMarginLeft = 0;
            this.UpdateButton.IconMarginRight = 0;
            this.UpdateButton.IconRightVisible = false;
            this.UpdateButton.IconRightZoom = 0D;
            this.UpdateButton.IconVisible = false;
            this.UpdateButton.IconZoom = 90D;
            this.UpdateButton.IsTab = false;
            this.UpdateButton.Location = new System.Drawing.Point(396, 257);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UpdateButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.UpdateButton.OnHoverTextColor = System.Drawing.Color.White;
            this.UpdateButton.selected = false;
            this.UpdateButton.Size = new System.Drawing.Size(138, 30);
            this.UpdateButton.TabIndex = 10;
            this.UpdateButton.Text = "UPDATE AND CLOSE";
            this.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UpdateButton.Textcolor = System.Drawing.Color.White;
            this.UpdateButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            this.UpdateButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeSecurityCodeForm_KeyDown);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(13, 241);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(520, 10);
            this.bunifuSeparator2.TabIndex = 9;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            this.bunifuSeparator2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeSecurityCodeForm_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(147, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "CURRENT SECURITY CODE:";
            // 
            // MsgImage
            // 
            this.MsgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgImage.BackColor = System.Drawing.Color.Transparent;
            this.MsgImage.ErrorImage = null;
            this.MsgImage.Image = global::Application.Properties.Resources.fingerprint;
            this.MsgImage.InitialImage = null;
            this.MsgImage.Location = new System.Drawing.Point(13, 51);
            this.MsgImage.Name = "MsgImage";
            this.MsgImage.Size = new System.Drawing.Size(127, 129);
            this.MsgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MsgImage.TabIndex = 33;
            this.MsgImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.label2.Location = new System.Drawing.Point(63, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(468, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Do not share your security code with others to avoid unauthorized system access!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOTICE:";
            // 
            // ChangeSecurityCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(579, 322);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeSecurityCodeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHANGE SECURITY CODE";
            this.Load += new System.EventHandler(this.ChangeSecurityCodeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeSecurityCodeForm_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MsgImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox MsgImage;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuFlatButton UpdateButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox ShowPasswordImg3;
        private System.Windows.Forms.PictureBox ShowPasswordImg2;
        private System.Windows.Forms.PictureBox ShowPasswordImg1;
        private Bunifu.Framework.UI.BunifuMetroTextbox ConfirmSecurityCodeTextbox;
        private Bunifu.Framework.UI.BunifuMetroTextbox NewSecurityCodeTextbox;
        private Bunifu.Framework.UI.BunifuMetroTextbox CurrentSecurityCodeTextbox;
    }
}