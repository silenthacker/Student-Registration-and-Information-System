namespace Application
{
    partial class SecurityCodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityCodeForm));
            this.PrimaryContainer = new Bunifu.Framework.UI.BunifuCards();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.AuthenticateButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.SecurityCodeTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.MsgImage = new System.Windows.Forms.PictureBox();
            this.DontCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.Label = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.PrimaryContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MsgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PrimaryContainer
            // 
            this.PrimaryContainer.BackColor = System.Drawing.Color.White;
            this.PrimaryContainer.BorderRadius = 2;
            this.PrimaryContainer.BottomSahddow = true;
            this.PrimaryContainer.color = System.Drawing.Color.White;
            this.PrimaryContainer.Controls.Add(this.ErrorLabel);
            this.PrimaryContainer.Controls.Add(this.AuthenticateButton);
            this.PrimaryContainer.Controls.Add(this.UsernameLabel);
            this.PrimaryContainer.Controls.Add(this.bunifuSeparator1);
            this.PrimaryContainer.Controls.Add(this.SecurityCodeTextbox);
            this.PrimaryContainer.Controls.Add(this.MsgImage);
            this.PrimaryContainer.Controls.Add(this.DontCheckBox);
            this.PrimaryContainer.Controls.Add(this.Label);
            this.PrimaryContainer.LeftSahddow = true;
            this.PrimaryContainer.Location = new System.Drawing.Point(12, 12);
            this.PrimaryContainer.Name = "PrimaryContainer";
            this.PrimaryContainer.RightSahddow = true;
            this.PrimaryContainer.ShadowDepth = 20;
            this.PrimaryContainer.Size = new System.Drawing.Size(410, 189);
            this.PrimaryContainer.TabIndex = 0;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ErrorLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold);
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(371, 57);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(15, 23);
            this.ErrorLabel.TabIndex = 40;
            this.ErrorLabel.Text = "!";
            this.ErrorLabel.Visible = false;
            // 
            // AuthenticateButton
            // 
            this.AuthenticateButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.AuthenticateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthenticateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.AuthenticateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AuthenticateButton.BorderRadius = 2;
            this.AuthenticateButton.ButtonText = "AUTHENTICATE";
            this.AuthenticateButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.AuthenticateButton.DisabledColor = System.Drawing.Color.Gray;
            this.AuthenticateButton.Iconcolor = System.Drawing.Color.Transparent;
            this.AuthenticateButton.Iconimage = null;
            this.AuthenticateButton.Iconimage_right = null;
            this.AuthenticateButton.Iconimage_right_Selected = null;
            this.AuthenticateButton.Iconimage_Selected = null;
            this.AuthenticateButton.IconMarginLeft = 0;
            this.AuthenticateButton.IconMarginRight = 0;
            this.AuthenticateButton.IconRightVisible = false;
            this.AuthenticateButton.IconRightZoom = 0D;
            this.AuthenticateButton.IconVisible = false;
            this.AuthenticateButton.IconZoom = 90D;
            this.AuthenticateButton.IsTab = false;
            this.AuthenticateButton.Location = new System.Drawing.Point(277, 148);
            this.AuthenticateButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.AuthenticateButton.Name = "AuthenticateButton";
            this.AuthenticateButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.AuthenticateButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.AuthenticateButton.OnHoverTextColor = System.Drawing.Color.White;
            this.AuthenticateButton.selected = false;
            this.AuthenticateButton.Size = new System.Drawing.Size(115, 30);
            this.AuthenticateButton.TabIndex = 39;
            this.AuthenticateButton.Text = "AUTHENTICATE";
            this.AuthenticateButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AuthenticateButton.Textcolor = System.Drawing.Color.White;
            this.AuthenticateButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.AuthenticateButton.Click += new System.EventHandler(this.AuthenticateButton_Click);
            this.AuthenticateButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecurityCodeForm_KeyDown);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(21, 155);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(134, 15);
            this.UsernameLabel.TabIndex = 38;
            this.UsernameLabel.Text = "PC USER: JOSE PAMA";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(24, 130);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(368, 10);
            this.bunifuSeparator1.TabIndex = 36;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecurityCodeForm_KeyDown);
            // 
            // SecurityCodeTextbox
            // 
            this.SecurityCodeTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SecurityCodeTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SecurityCodeTextbox.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.SecurityCodeTextbox.ForeColor = System.Drawing.Color.Black;
            this.SecurityCodeTextbox.HintForeColor = System.Drawing.Color.Empty;
            this.SecurityCodeTextbox.HintText = "";
            this.SecurityCodeTextbox.isPassword = false;
            this.SecurityCodeTextbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.SecurityCodeTextbox.LineIdleColor = System.Drawing.Color.Gray;
            this.SecurityCodeTextbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.SecurityCodeTextbox.LineThickness = 3;
            this.SecurityCodeTextbox.Location = new System.Drawing.Point(123, 53);
            this.SecurityCodeTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.SecurityCodeTextbox.Name = "SecurityCodeTextbox";
            this.SecurityCodeTextbox.Size = new System.Drawing.Size(269, 33);
            this.SecurityCodeTextbox.TabIndex = 0;
            this.SecurityCodeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SecurityCodeTextbox.OnValueChanged += new System.EventHandler(this.SecurityCodeTextbox_OnValueChanged);
            this.SecurityCodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecurityCodeForm_KeyDown);
            this.SecurityCodeTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SecurityCodeTextbox_KeyPress);
            // 
            // MsgImage
            // 
            this.MsgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgImage.BackColor = System.Drawing.Color.Transparent;
            this.MsgImage.ErrorImage = null;
            this.MsgImage.Image = global::Application.Properties.Resources.fingerprint;
            this.MsgImage.InitialImage = null;
            this.MsgImage.Location = new System.Drawing.Point(20, 21);
            this.MsgImage.Name = "MsgImage";
            this.MsgImage.Size = new System.Drawing.Size(95, 100);
            this.MsgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MsgImage.TabIndex = 32;
            this.MsgImage.TabStop = false;
            // 
            // DontCheckBox
            // 
            this.DontCheckBox.AutoSize = true;
            this.DontCheckBox.Depth = 0;
            this.DontCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.DontCheckBox.Location = new System.Drawing.Point(211, 102);
            this.DontCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.DontCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DontCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.DontCheckBox.Name = "DontCheckBox";
            this.DontCheckBox.Ripple = true;
            this.DontCheckBox.Size = new System.Drawing.Size(181, 30);
            this.DontCheckBox.TabIndex = 37;
            this.DontCheckBox.Text = "DISABLE ON STARTUP ?";
            this.DontCheckBox.UseVisualStyleBackColor = true;
            this.DontCheckBox.CheckedChanged += new System.EventHandler(this.DontCheckBox_CheckedChanged);
            this.DontCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecurityCodeForm_KeyDown);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label.Location = new System.Drawing.Point(121, 31);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(124, 18);
            this.Label.TabIndex = 33;
            this.Label.Text = "SECURITY CODE:";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this.SecurityCodeTextbox;
            // 
            // SecurityCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(434, 213);
            this.Controls.Add(this.PrimaryContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 252);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 252);
            this.Name = "SecurityCodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SECURITY CODE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SecurityCodeForm_FormClosing);
            this.Load += new System.EventHandler(this.SecurityCodeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecurityCodeForm_KeyDown);
            this.PrimaryContainer.ResumeLayout(false);
            this.PrimaryContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MsgImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards PrimaryContainer;
        private System.Windows.Forms.PictureBox MsgImage;
        private System.Windows.Forms.Label Label;
        private Bunifu.Framework.UI.BunifuMaterialTextbox SecurityCodeTextbox;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private MaterialSkin.Controls.MaterialCheckBox DontCheckBox;
        private System.Windows.Forms.Label UsernameLabel;
        private Bunifu.Framework.UI.BunifuFlatButton AuthenticateButton;
        private System.Windows.Forms.Label ErrorLabel;
    }
}