namespace Application
{
    partial class AddSchoolYearForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSchoolYearForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.SchoolYearTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.AddStudentImage = new System.Windows.Forms.PictureBox();
            this.CloseButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.InsertButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SchoolYearGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddStudentImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchoolYearGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.White;
            this.bunifuCards1.Controls.Add(this.SchoolYearTextbox);
            this.bunifuCards1.Controls.Add(this.AddStudentImage);
            this.bunifuCards1.Controls.Add(this.CloseButton);
            this.bunifuCards1.Controls.Add(this.InsertButton);
            this.bunifuCards1.Controls.Add(this.bunifuSeparator1);
            this.bunifuCards1.Controls.Add(this.groupBox1);
            this.bunifuCards1.LeftSahddow = true;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(695, 382);
            this.bunifuCards1.TabIndex = 0;
            // 
            // SchoolYearTextbox
            // 
            this.SchoolYearTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SchoolYearTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SchoolYearTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolYearTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SchoolYearTextbox.HintForeColor = System.Drawing.Color.DarkGray;
            this.SchoolYearTextbox.HintText = "e.g. S.Y. 2018-2019";
            this.SchoolYearTextbox.isPassword = false;
            this.SchoolYearTextbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.SchoolYearTextbox.LineIdleColor = System.Drawing.Color.Gray;
            this.SchoolYearTextbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.SchoolYearTextbox.LineThickness = 3;
            this.SchoolYearTextbox.Location = new System.Drawing.Point(59, 15);
            this.SchoolYearTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.SchoolYearTextbox.Name = "SchoolYearTextbox";
            this.SchoolYearTextbox.Size = new System.Drawing.Size(284, 33);
            this.SchoolYearTextbox.TabIndex = 90;
            this.SchoolYearTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SchoolYearTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SchoolYearTextbox_KeyDown);
            // 
            // AddStudentImage
            // 
            this.AddStudentImage.BackColor = System.Drawing.Color.Transparent;
            this.AddStudentImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddStudentImage.ErrorImage = null;
            this.AddStudentImage.Image = global::Application.Properties.Resources.add2;
            this.AddStudentImage.InitialImage = null;
            this.AddStudentImage.Location = new System.Drawing.Point(17, 14);
            this.AddStudentImage.Name = "AddStudentImage";
            this.AddStudentImage.Size = new System.Drawing.Size(35, 35);
            this.AddStudentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AddStudentImage.TabIndex = 89;
            this.AddStudentImage.TabStop = false;
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
            this.CloseButton.Location = new System.Drawing.Point(591, 342);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.CloseButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.CloseButton.OnHoverTextColor = System.Drawing.Color.White;
            this.CloseButton.selected = false;
            this.CloseButton.Size = new System.Drawing.Size(90, 30);
            this.CloseButton.TabIndex = 82;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Textcolor = System.Drawing.Color.White;
            this.CloseButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SchoolYearTextbox_KeyDown);
            // 
            // InsertButton
            // 
            this.InsertButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.InsertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InsertButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.InsertButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InsertButton.BorderRadius = 2;
            this.InsertButton.ButtonText = "INSERT";
            this.InsertButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.InsertButton.DisabledColor = System.Drawing.Color.Gray;
            this.InsertButton.Iconcolor = System.Drawing.Color.Transparent;
            this.InsertButton.Iconimage = null;
            this.InsertButton.Iconimage_right = null;
            this.InsertButton.Iconimage_right_Selected = null;
            this.InsertButton.Iconimage_Selected = null;
            this.InsertButton.IconMarginLeft = 0;
            this.InsertButton.IconMarginRight = 0;
            this.InsertButton.IconRightVisible = false;
            this.InsertButton.IconRightZoom = 0D;
            this.InsertButton.IconVisible = false;
            this.InsertButton.IconZoom = 90D;
            this.InsertButton.IsTab = false;
            this.InsertButton.Location = new System.Drawing.Point(491, 342);
            this.InsertButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.InsertButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.InsertButton.OnHoverTextColor = System.Drawing.Color.White;
            this.InsertButton.selected = false;
            this.InsertButton.Size = new System.Drawing.Size(90, 30);
            this.InsertButton.TabIndex = 81;
            this.InsertButton.Text = "INSERT";
            this.InsertButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InsertButton.Textcolor = System.Drawing.Color.White;
            this.InsertButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            this.InsertButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SchoolYearTextbox_KeyDown);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(17, 326);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(664, 10);
            this.bunifuSeparator1.TabIndex = 80;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SchoolYearTextbox_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 263);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LIST OF SCHOOL YEAR";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.SchoolYearGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 241);
            this.panel1.TabIndex = 0;
            // 
            // SchoolYearGridView
            // 
            this.SchoolYearGridView.AllowUserToAddRows = false;
            this.SchoolYearGridView.AllowUserToDeleteRows = false;
            this.SchoolYearGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.SchoolYearGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SchoolYearGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SchoolYearGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SchoolYearGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SchoolYearGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ColumnSchoolYear});
            this.SchoolYearGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchoolYearGridView.EnableHeadersVisualStyles = false;
            this.SchoolYearGridView.GridColor = System.Drawing.Color.Silver;
            this.SchoolYearGridView.Location = new System.Drawing.Point(0, 0);
            this.SchoolYearGridView.Name = "SchoolYearGridView";
            this.SchoolYearGridView.ReadOnly = true;
            this.SchoolYearGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SchoolYearGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SchoolYearGridView.RowHeadersWidth = 50;
            this.SchoolYearGridView.Size = new System.Drawing.Size(661, 241);
            this.SchoolYearGridView.TabIndex = 0;
            this.SchoolYearGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SchoolYearTextbox_KeyDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ENTRY ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // ColumnSchoolYear
            // 
            this.ColumnSchoolYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSchoolYear.DataPropertyName = "SCHOOL YEAR";
            this.ColumnSchoolYear.HeaderText = "SCHOOL YEAR";
            this.ColumnSchoolYear.Name = "ColumnSchoolYear";
            this.ColumnSchoolYear.ReadOnly = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this.SchoolYearTextbox;
            // 
            // AddSchoolYearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(719, 406);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(735, 445);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(735, 445);
            this.Name = "AddSchoolYearForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCHOOL YEAR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSchoolYearForm_FormClosing);
            this.Load += new System.EventHandler(this.AddSchoolYearForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SchoolYearTextbox_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddStudentImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SchoolYearGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView SchoolYearGridView;
        private Bunifu.Framework.UI.BunifuFlatButton CloseButton;
        private Bunifu.Framework.UI.BunifuFlatButton InsertButton;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.PictureBox AddStudentImage;
        private Bunifu.Framework.UI.BunifuMaterialTextbox SchoolYearTextbox;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSchoolYear;
    }
}