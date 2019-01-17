namespace Application
{
    partial class AddSectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSectionForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.CurrentSchoolYearDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.CloseButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.InsertButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxStudentTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.SectionNameTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListofSectionsGridview = new System.Windows.Forms.DataGridView();
            this.ColumnSectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaxStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnrolled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCards1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListofSectionsGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.White;
            this.bunifuCards1.Controls.Add(this.CurrentSchoolYearDropdown);
            this.bunifuCards1.Controls.Add(this.CloseButton);
            this.bunifuCards1.Controls.Add(this.InsertButton);
            this.bunifuCards1.Controls.Add(this.bunifuSeparator1);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.MaxStudentTextbox);
            this.bunifuCards1.Controls.Add(this.SectionNameTextbox);
            this.bunifuCards1.Controls.Add(this.groupBox1);
            this.bunifuCards1.LeftSahddow = true;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(695, 382);
            this.bunifuCards1.TabIndex = 0;
            // 
            // CurrentSchoolYearDropdown
            // 
            this.CurrentSchoolYearDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentSchoolYearDropdown.BackColor = System.Drawing.Color.Transparent;
            this.CurrentSchoolYearDropdown.BorderRadius = 2;
            this.CurrentSchoolYearDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.CurrentSchoolYearDropdown.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentSchoolYearDropdown.ForeColor = System.Drawing.Color.Black;
            this.CurrentSchoolYearDropdown.Items = new string[0];
            this.CurrentSchoolYearDropdown.Location = new System.Drawing.Point(480, 32);
            this.CurrentSchoolYearDropdown.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.CurrentSchoolYearDropdown.Name = "CurrentSchoolYearDropdown";
            this.CurrentSchoolYearDropdown.NomalColor = System.Drawing.Color.WhiteSmoke;
            this.CurrentSchoolYearDropdown.onHoverColor = System.Drawing.Color.Silver;
            this.CurrentSchoolYearDropdown.selectedIndex = -1;
            this.CurrentSchoolYearDropdown.Size = new System.Drawing.Size(201, 33);
            this.CurrentSchoolYearDropdown.TabIndex = 87;
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
            this.CloseButton.Location = new System.Drawing.Point(591, 338);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.CloseButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.CloseButton.OnHoverTextColor = System.Drawing.Color.White;
            this.CloseButton.selected = false;
            this.CloseButton.Size = new System.Drawing.Size(90, 30);
            this.CloseButton.TabIndex = 79;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Textcolor = System.Drawing.Color.White;
            this.CloseButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSectionForm_KeyDown);
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
            this.InsertButton.Location = new System.Drawing.Point(491, 338);
            this.InsertButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.InsertButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.InsertButton.OnHoverTextColor = System.Drawing.Color.White;
            this.InsertButton.selected = false;
            this.InsertButton.Size = new System.Drawing.Size(90, 30);
            this.InsertButton.TabIndex = 78;
            this.InsertButton.Text = "INSERT";
            this.InsertButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InsertButton.Textcolor = System.Drawing.Color.White;
            this.InsertButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            this.InsertButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSectionForm_KeyDown);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(16, 322);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(665, 10);
            this.bunifuSeparator1.TabIndex = 77;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSectionForm_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF UI Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(479, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "CURRENT SCHOOL YEAR:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF UI Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "MAXIMUM STUDENTS:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF UI Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "SECTION NAME:";
            // 
            // MaxStudentTextbox
            // 
            this.MaxStudentTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MaxStudentTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MaxStudentTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxStudentTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MaxStudentTextbox.HintForeColor = System.Drawing.Color.DarkGray;
            this.MaxStudentTextbox.HintText = "e.g. 50";
            this.MaxStudentTextbox.isPassword = false;
            this.MaxStudentTextbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.MaxStudentTextbox.LineIdleColor = System.Drawing.Color.Gray;
            this.MaxStudentTextbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.MaxStudentTextbox.LineThickness = 3;
            this.MaxStudentTextbox.Location = new System.Drawing.Point(319, 32);
            this.MaxStudentTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.MaxStudentTextbox.Name = "MaxStudentTextbox";
            this.MaxStudentTextbox.Size = new System.Drawing.Size(155, 33);
            this.MaxStudentTextbox.TabIndex = 4;
            this.MaxStudentTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MaxStudentTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSectionForm_KeyDown);
            this.MaxStudentTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaxStudentTextbox_KeyPress);
            // 
            // SectionNameTextbox
            // 
            this.SectionNameTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SectionNameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SectionNameTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionNameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SectionNameTextbox.HintForeColor = System.Drawing.Color.DarkGray;
            this.SectionNameTextbox.HintText = "e.g. ACKNOWLEDGEMENT";
            this.SectionNameTextbox.isPassword = false;
            this.SectionNameTextbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.SectionNameTextbox.LineIdleColor = System.Drawing.Color.Gray;
            this.SectionNameTextbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.SectionNameTextbox.LineThickness = 3;
            this.SectionNameTextbox.Location = new System.Drawing.Point(16, 32);
            this.SectionNameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.SectionNameTextbox.Name = "SectionNameTextbox";
            this.SectionNameTextbox.Size = new System.Drawing.Size(295, 33);
            this.SectionNameTextbox.TabIndex = 2;
            this.SectionNameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SectionNameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSectionForm_KeyDown);
            this.SectionNameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SectionNameTextbox_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 233);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LIST OF SECTIONS";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ListofSectionsGridview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 211);
            this.panel1.TabIndex = 8;
            // 
            // ListofSectionsGridview
            // 
            this.ListofSectionsGridview.AllowUserToAddRows = false;
            this.ListofSectionsGridview.AllowUserToDeleteRows = false;
            this.ListofSectionsGridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ListofSectionsGridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListofSectionsGridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListofSectionsGridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListofSectionsGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListofSectionsGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSectionID,
            this.ColumnSectionName,
            this.ColumnMaxStudents,
            this.ColumnEnrolled,
            this.ColumnSchoolYear});
            this.ListofSectionsGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListofSectionsGridview.EnableHeadersVisualStyles = false;
            this.ListofSectionsGridview.GridColor = System.Drawing.Color.Silver;
            this.ListofSectionsGridview.Location = new System.Drawing.Point(0, 0);
            this.ListofSectionsGridview.Name = "ListofSectionsGridview";
            this.ListofSectionsGridview.ReadOnly = true;
            this.ListofSectionsGridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListofSectionsGridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ListofSectionsGridview.Size = new System.Drawing.Size(659, 211);
            this.ListofSectionsGridview.TabIndex = 8;
            this.ListofSectionsGridview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSectionForm_KeyDown);
            // 
            // ColumnSectionID
            // 
            this.ColumnSectionID.DataPropertyName = "SECTION ID";
            this.ColumnSectionID.HeaderText = "SECTION ID";
            this.ColumnSectionID.Name = "ColumnSectionID";
            this.ColumnSectionID.ReadOnly = true;
            // 
            // ColumnSectionName
            // 
            this.ColumnSectionName.DataPropertyName = "SECTION NAME";
            this.ColumnSectionName.HeaderText = "SECTION NAME";
            this.ColumnSectionName.Name = "ColumnSectionName";
            this.ColumnSectionName.ReadOnly = true;
            this.ColumnSectionName.Width = 170;
            // 
            // ColumnMaxStudents
            // 
            this.ColumnMaxStudents.DataPropertyName = "MAXIMUM STUDENTS";
            this.ColumnMaxStudents.HeaderText = "MAX STUDENTS";
            this.ColumnMaxStudents.Name = "ColumnMaxStudents";
            this.ColumnMaxStudents.ReadOnly = true;
            this.ColumnMaxStudents.Width = 130;
            // 
            // ColumnEnrolled
            // 
            this.ColumnEnrolled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEnrolled.DataPropertyName = "ENROLLED";
            this.ColumnEnrolled.HeaderText = "ENROLLED";
            this.ColumnEnrolled.Name = "ColumnEnrolled";
            this.ColumnEnrolled.ReadOnly = true;
            // 
            // ColumnSchoolYear
            // 
            this.ColumnSchoolYear.DataPropertyName = "SCHOOL YEAR";
            this.ColumnSchoolYear.HeaderText = "SCHOOL YEAR";
            this.ColumnSchoolYear.Name = "ColumnSchoolYear";
            this.ColumnSchoolYear.ReadOnly = true;
            this.ColumnSchoolYear.Width = 132;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this.SectionNameTextbox;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 2;
            this.bunifuElipse2.TargetControl = this.MaxStudentTextbox;
            // 
            // AddSectionForm
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
            this.Name = "AddSectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SECTIONS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSectionForm_FormClosing);
            this.Load += new System.EventHandler(this.AddSectionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSectionForm_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListofSectionsGridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox SectionNameTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox MaxStudentTextbox;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuFlatButton InsertButton;
        private Bunifu.Framework.UI.BunifuFlatButton CloseButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ListofSectionsGridview;
        private System.Windows.Forms.Label label3;
        public Bunifu.Framework.UI.BunifuDropdown CurrentSchoolYearDropdown;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSectionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaxStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnrolled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSchoolYear;
    }
}