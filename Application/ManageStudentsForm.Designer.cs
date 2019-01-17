namespace Application
{
    partial class ManageStudentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageStudentsForm));
            this.ParentContainer = new Bunifu.Framework.UI.BunifuCards();
            this.SaveSettingsButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.DisAllowRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.G10CheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.G9CheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.G8CheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.G7CheckBox = new MaterialSkin.Controls.MaterialCheckBox();
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
            this.ParentContainer.Size = new System.Drawing.Size(515, 267);
            this.ParentContainer.TabIndex = 0;
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
            this.SaveSettingsButton.Location = new System.Drawing.Point(326, 228);
            this.SaveSettingsButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SaveSettingsButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.SaveSettingsButton.OnHoverTextColor = System.Drawing.Color.White;
            this.SaveSettingsButton.selected = false;
            this.SaveSettingsButton.Size = new System.Drawing.Size(175, 30);
            this.SaveSettingsButton.TabIndex = 24;
            this.SaveSettingsButton.Text = "SAVE SETTINGS AND CLOSE";
            this.SaveSettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveSettingsButton.Textcolor = System.Drawing.Color.White;
            this.SaveSettingsButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.SaveSettingsButton.Click += new System.EventHandler(this.SendButton_Click);
            this.SaveSettingsButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G7CheckBox_KeyDown);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(13, 211);
            this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(488, 11);
            this.bunifuSeparator2.TabIndex = 6;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            this.bunifuSeparator2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G7CheckBox_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bunifuSeparator1);
            this.groupBox1.Controls.Add(this.DisAllowRadioButton);
            this.groupBox1.Controls.Add(this.G10CheckBox);
            this.groupBox1.Controls.Add(this.G9CheckBox);
            this.groupBox1.Controls.Add(this.G8CheckBox);
            this.groupBox1.Controls.Add(this.G7CheckBox);
            this.groupBox1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ALLOW OR DISALLOW CHANGING OF STUDENT SECTION && GRADE LEVEL ?";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(21, 97);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(440, 11);
            this.bunifuSeparator1.TabIndex = 5;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G7CheckBox_KeyDown);
            // 
            // DisAllowRadioButton
            // 
            this.DisAllowRadioButton.AutoSize = true;
            this.DisAllowRadioButton.Depth = 0;
            this.DisAllowRadioButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.DisAllowRadioButton.Location = new System.Drawing.Point(32, 118);
            this.DisAllowRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.DisAllowRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DisAllowRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DisAllowRadioButton.Name = "DisAllowRadioButton";
            this.DisAllowRadioButton.Ripple = true;
            this.DisAllowRadioButton.Size = new System.Drawing.Size(112, 30);
            this.DisAllowRadioButton.TabIndex = 4;
            this.DisAllowRadioButton.TabStop = true;
            this.DisAllowRadioButton.Text = "DISALLOWED";
            this.DisAllowRadioButton.UseVisualStyleBackColor = true;
            this.DisAllowRadioButton.CheckedChanged += new System.EventHandler(this.DisAllowRadioButton_CheckedChanged);
            this.DisAllowRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G7CheckBox_KeyDown);
            // 
            // G10CheckBox
            // 
            this.G10CheckBox.AutoSize = true;
            this.G10CheckBox.Depth = 0;
            this.G10CheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.G10CheckBox.Location = new System.Drawing.Point(224, 64);
            this.G10CheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.G10CheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.G10CheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.G10CheckBox.Name = "G10CheckBox";
            this.G10CheckBox.Ripple = true;
            this.G10CheckBox.Size = new System.Drawing.Size(131, 30);
            this.G10CheckBox.TabIndex = 3;
            this.G10CheckBox.Text = "GRADE 10 (G10)";
            this.G10CheckBox.UseVisualStyleBackColor = true;
            this.G10CheckBox.CheckedChanged += new System.EventHandler(this.G7CheckBox_CheckedChanged);
            this.G10CheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G7CheckBox_KeyDown);
            // 
            // G9CheckBox
            // 
            this.G9CheckBox.AutoSize = true;
            this.G9CheckBox.Depth = 0;
            this.G9CheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.G9CheckBox.Location = new System.Drawing.Point(224, 27);
            this.G9CheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.G9CheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.G9CheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.G9CheckBox.Name = "G9CheckBox";
            this.G9CheckBox.Ripple = true;
            this.G9CheckBox.Size = new System.Drawing.Size(115, 30);
            this.G9CheckBox.TabIndex = 2;
            this.G9CheckBox.Text = "GRADE 9 (G9)";
            this.G9CheckBox.UseVisualStyleBackColor = true;
            this.G9CheckBox.CheckedChanged += new System.EventHandler(this.G7CheckBox_CheckedChanged);
            this.G9CheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G7CheckBox_KeyDown);
            // 
            // G8CheckBox
            // 
            this.G8CheckBox.AutoSize = true;
            this.G8CheckBox.Depth = 0;
            this.G8CheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.G8CheckBox.Location = new System.Drawing.Point(32, 64);
            this.G8CheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.G8CheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.G8CheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.G8CheckBox.Name = "G8CheckBox";
            this.G8CheckBox.Ripple = true;
            this.G8CheckBox.Size = new System.Drawing.Size(115, 30);
            this.G8CheckBox.TabIndex = 1;
            this.G8CheckBox.Text = "GRADE 8 (G8)";
            this.G8CheckBox.UseVisualStyleBackColor = true;
            this.G8CheckBox.CheckedChanged += new System.EventHandler(this.G7CheckBox_CheckedChanged);
            this.G8CheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G7CheckBox_KeyDown);
            // 
            // G7CheckBox
            // 
            this.G7CheckBox.AutoSize = true;
            this.G7CheckBox.Depth = 0;
            this.G7CheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.G7CheckBox.Location = new System.Drawing.Point(32, 27);
            this.G7CheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.G7CheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.G7CheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.G7CheckBox.Name = "G7CheckBox";
            this.G7CheckBox.Ripple = true;
            this.G7CheckBox.Size = new System.Drawing.Size(115, 30);
            this.G7CheckBox.TabIndex = 0;
            this.G7CheckBox.Text = "GRADE 7 (G7)";
            this.G7CheckBox.UseVisualStyleBackColor = true;
            this.G7CheckBox.CheckedChanged += new System.EventHandler(this.G7CheckBox_CheckedChanged);
            this.G7CheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G7CheckBox_KeyDown);
            // 
            // ManageStudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(539, 291);
            this.Controls.Add(this.ParentContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(555, 330);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(555, 330);
            this.Name = "ManageStudentsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE STUDENTS";
            this.Load += new System.EventHandler(this.ManageStudentsForm_Load);
            this.ParentContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards ParentContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialCheckBox G10CheckBox;
        private MaterialSkin.Controls.MaterialCheckBox G9CheckBox;
        private MaterialSkin.Controls.MaterialCheckBox G8CheckBox;
        private MaterialSkin.Controls.MaterialCheckBox G7CheckBox;
        private MaterialSkin.Controls.MaterialRadioButton DisAllowRadioButton;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public Bunifu.Framework.UI.BunifuFlatButton SaveSettingsButton;
    }
}