namespace Application
{
    partial class ManageTeachersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTeachersForm));
            this.ParentContainer = new Bunifu.Framework.UI.BunifuCards();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveSettingsButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.AllowRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.DisAllowRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.NotSureRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.ParentContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParentContainer
            // 
            this.ParentContainer.BackColor = System.Drawing.Color.White;
            this.ParentContainer.BorderRadius = 2;
            this.ParentContainer.BottomSahddow = true;
            this.ParentContainer.color = System.Drawing.Color.Tomato;
            this.ParentContainer.Controls.Add(this.SaveSettingsButton);
            this.ParentContainer.Controls.Add(this.bunifuSeparator2);
            this.ParentContainer.Controls.Add(this.groupBox1);
            this.ParentContainer.LeftSahddow = false;
            this.ParentContainer.Location = new System.Drawing.Point(12, 12);
            this.ParentContainer.Name = "ParentContainer";
            this.ParentContainer.RightSahddow = false;
            this.ParentContainer.ShadowDepth = 20;
            this.ParentContainer.Size = new System.Drawing.Size(460, 237);
            this.ParentContainer.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bunifuSeparator1);
            this.groupBox1.Controls.Add(this.NotSureRadioButton);
            this.groupBox1.Controls.Add(this.DisAllowRadioButton);
            this.groupBox1.Controls.Add(this.AllowRadioButton);
            this.groupBox1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ALLOW TEACHERS TO CHANGE THIER ASSIGNATORIES ?";
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SaveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SaveSettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveSettingsButton.BorderRadius = 2;
            this.SaveSettingsButton.ButtonText = "SAVE SETTINGS AND CLOSE";
            this.SaveSettingsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SaveSettingsButton.DisabledColor = System.Drawing.Color.Gray;
            this.SaveSettingsButton.Iconcolor = System.Drawing.Color.Transparent;
            this.SaveSettingsButton.Iconimage = null;
            this.SaveSettingsButton.Iconimage_right = null;
            this.SaveSettingsButton.Iconimage_right_Selected = null;
            this.SaveSettingsButton.Iconimage_Selected = null;
            this.SaveSettingsButton.IconMarginLeft = 0;
            this.SaveSettingsButton.IconMarginRight = 0;
            this.SaveSettingsButton.IconRightVisible = false;
            this.SaveSettingsButton.IconRightZoom = 0D;
            this.SaveSettingsButton.IconVisible = false;
            this.SaveSettingsButton.IconZoom = 90D;
            this.SaveSettingsButton.IsTab = false;
            this.SaveSettingsButton.Location = new System.Drawing.Point(271, 195);
            this.SaveSettingsButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SaveSettingsButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.SaveSettingsButton.OnHoverTextColor = System.Drawing.Color.White;
            this.SaveSettingsButton.selected = false;
            this.SaveSettingsButton.Size = new System.Drawing.Size(175, 30);
            this.SaveSettingsButton.TabIndex = 26;
            this.SaveSettingsButton.Text = "SAVE SETTINGS AND CLOSE";
            this.SaveSettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveSettingsButton.Textcolor = System.Drawing.Color.White;
            this.SaveSettingsButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            this.SaveSettingsButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTeachersForm_KeyDown);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(14, 178);
            this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(432, 11);
            this.bunifuSeparator2.TabIndex = 25;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            this.bunifuSeparator2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTeachersForm_KeyDown);
            // 
            // AllowRadioButton
            // 
            this.AllowRadioButton.AutoSize = true;
            this.AllowRadioButton.Depth = 0;
            this.AllowRadioButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.AllowRadioButton.Location = new System.Drawing.Point(37, 44);
            this.AllowRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.AllowRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AllowRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.AllowRadioButton.Name = "AllowRadioButton";
            this.AllowRadioButton.Ripple = true;
            this.AllowRadioButton.Size = new System.Drawing.Size(91, 30);
            this.AllowRadioButton.TabIndex = 0;
            this.AllowRadioButton.TabStop = true;
            this.AllowRadioButton.Text = "ALLOWED";
            this.AllowRadioButton.UseVisualStyleBackColor = true;
            this.AllowRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTeachersForm_KeyDown);
            // 
            // DisAllowRadioButton
            // 
            this.DisAllowRadioButton.AutoSize = true;
            this.DisAllowRadioButton.Depth = 0;
            this.DisAllowRadioButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.DisAllowRadioButton.Location = new System.Drawing.Point(155, 44);
            this.DisAllowRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.DisAllowRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DisAllowRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DisAllowRadioButton.Name = "DisAllowRadioButton";
            this.DisAllowRadioButton.Ripple = true;
            this.DisAllowRadioButton.Size = new System.Drawing.Size(112, 30);
            this.DisAllowRadioButton.TabIndex = 1;
            this.DisAllowRadioButton.TabStop = true;
            this.DisAllowRadioButton.Text = "DISALLOWED";
            this.DisAllowRadioButton.UseVisualStyleBackColor = true;
            this.DisAllowRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTeachersForm_KeyDown);
            // 
            // NotSureRadioButton
            // 
            this.NotSureRadioButton.AutoSize = true;
            this.NotSureRadioButton.Depth = 0;
            this.NotSureRadioButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.NotSureRadioButton.Location = new System.Drawing.Point(294, 44);
            this.NotSureRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.NotSureRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.NotSureRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.NotSureRadioButton.Name = "NotSureRadioButton";
            this.NotSureRadioButton.Ripple = true;
            this.NotSureRadioButton.Size = new System.Drawing.Size(94, 30);
            this.NotSureRadioButton.TabIndex = 2;
            this.NotSureRadioButton.TabStop = true;
            this.NotSureRadioButton.Text = "NOT SURE";
            this.NotSureRadioButton.UseVisualStyleBackColor = true;
            this.NotSureRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTeachersForm_KeyDown);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(35, 77);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(368, 13);
            this.bunifuSeparator1.TabIndex = 6;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTeachersForm_KeyDown);
            // 
            // ManageTeachersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.ParentContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "ManageTeachersForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE TEACHERS";
            this.Load += new System.EventHandler(this.ManageTeachersForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTeachersForm_KeyDown);
            this.ParentContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards ParentContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        public Bunifu.Framework.UI.BunifuFlatButton SaveSettingsButton;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private MaterialSkin.Controls.MaterialRadioButton NotSureRadioButton;
        private MaterialSkin.Controls.MaterialRadioButton DisAllowRadioButton;
        private MaterialSkin.Controls.MaterialRadioButton AllowRadioButton;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}