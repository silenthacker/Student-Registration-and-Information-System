namespace Application
{
    partial class StudentSettingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentSettingsForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.ListofSections_GroupBox = new System.Windows.Forms.GroupBox();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.ListofSectionsGridview = new System.Windows.Forms.DataGridView();
            this.ColumnSectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaxStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnrolled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UpdateButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NewGradeLevelDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.label4 = new System.Windows.Forms.Label();
            this.NewSectionDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OldGradeLevelDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.label2 = new System.Windows.Forms.Label();
            this.OldSectionDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuCards1.SuspendLayout();
            this.ListofSections_GroupBox.SuspendLayout();
            this.bunifuCards2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListofSectionsGridview)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.ListofSections_GroupBox);
            this.bunifuCards1.Controls.Add(this.groupBox2);
            this.bunifuCards1.Controls.Add(this.groupBox1);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 5;
            this.bunifuCards1.Size = new System.Drawing.Size(825, 447);
            this.bunifuCards1.TabIndex = 0;
            // 
            // ListofSections_GroupBox
            // 
            this.ListofSections_GroupBox.Controls.Add(this.bunifuCards2);
            this.ListofSections_GroupBox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.ListofSections_GroupBox.Location = new System.Drawing.Point(14, 183);
            this.ListofSections_GroupBox.Name = "ListofSections_GroupBox";
            this.ListofSections_GroupBox.Padding = new System.Windows.Forms.Padding(1);
            this.ListofSections_GroupBox.Size = new System.Drawing.Size(798, 254);
            this.ListofSections_GroupBox.TabIndex = 3;
            this.ListofSections_GroupBox.TabStop = false;
            this.ListofSections_GroupBox.Text = "LIST OF SECTIONS FOR THE SCHOOL YEAR:";
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.BackColor = System.Drawing.Color.White;
            this.bunifuCards2.BorderRadius = 0;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.Tomato;
            this.bunifuCards2.Controls.Add(this.ListofSectionsGridview);
            this.bunifuCards2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(1, 17);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = false;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(796, 236);
            this.bunifuCards2.TabIndex = 0;
            // 
            // ListofSectionsGridview
            // 
            this.ListofSectionsGridview.AllowUserToAddRows = false;
            this.ListofSectionsGridview.AllowUserToDeleteRows = false;
            this.ListofSectionsGridview.AllowUserToResizeColumns = false;
            this.ListofSectionsGridview.AllowUserToResizeRows = false;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SF UI Display", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListofSectionsGridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.ListofSectionsGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListofSectionsGridview.EnableHeadersVisualStyles = false;
            this.ListofSectionsGridview.GridColor = System.Drawing.Color.Silver;
            this.ListofSectionsGridview.Location = new System.Drawing.Point(0, 0);
            this.ListofSectionsGridview.Name = "ListofSectionsGridview";
            this.ListofSectionsGridview.ReadOnly = true;
            this.ListofSectionsGridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListofSectionsGridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ListofSectionsGridview.Size = new System.Drawing.Size(796, 236);
            this.ListofSectionsGridview.TabIndex = 11;
            this.ListofSectionsGridview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionDropdown_KeyDown);
            // 
            // ColumnSectionID
            // 
            this.ColumnSectionID.DataPropertyName = "SECTION ID";
            this.ColumnSectionID.HeaderText = "SECTION ID";
            this.ColumnSectionID.Name = "ColumnSectionID";
            this.ColumnSectionID.ReadOnly = true;
            this.ColumnSectionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnSectionName
            // 
            this.ColumnSectionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSectionName.DataPropertyName = "SECTION NAME";
            this.ColumnSectionName.HeaderText = "SECTION NAME";
            this.ColumnSectionName.Name = "ColumnSectionName";
            this.ColumnSectionName.ReadOnly = true;
            this.ColumnSectionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnMaxStudents
            // 
            this.ColumnMaxStudents.DataPropertyName = "MAXIMUM STUDENTS";
            this.ColumnMaxStudents.HeaderText = "MAX STUDENTS";
            this.ColumnMaxStudents.Name = "ColumnMaxStudents";
            this.ColumnMaxStudents.ReadOnly = true;
            this.ColumnMaxStudents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnMaxStudents.Width = 130;
            // 
            // ColumnEnrolled
            // 
            this.ColumnEnrolled.DataPropertyName = "ENROLLED";
            this.ColumnEnrolled.HeaderText = "ENROLLED";
            this.ColumnEnrolled.Name = "ColumnEnrolled";
            this.ColumnEnrolled.ReadOnly = true;
            this.ColumnEnrolled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnEnrolled.Width = 120;
            // 
            // ColumnSchoolYear
            // 
            this.ColumnSchoolYear.DataPropertyName = "SCHOOL YEAR";
            this.ColumnSchoolYear.HeaderText = "SCHOOL YEAR";
            this.ColumnSchoolYear.Name = "ColumnSchoolYear";
            this.ColumnSchoolYear.ReadOnly = true;
            this.ColumnSchoolYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSchoolYear.Width = 150;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UpdateButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.NewGradeLevelDropdown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.NewSectionDropdown);
            this.groupBox2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(382, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 165);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHANGE TO ?";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateButton.BorderRadius = 2;
            this.UpdateButton.ButtonText = "UPDATE";
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
            this.UpdateButton.Location = new System.Drawing.Point(316, 106);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UpdateButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.UpdateButton.OnHoverTextColor = System.Drawing.Color.White;
            this.UpdateButton.selected = false;
            this.UpdateButton.Size = new System.Drawing.Size(90, 30);
            this.UpdateButton.TabIndex = 49;
            this.UpdateButton.Text = "UPDATE";
            this.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UpdateButton.Textcolor = System.Drawing.Color.White;
            this.UpdateButton.TextFont = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            this.UpdateButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionDropdown_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("SF UI Display", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(112, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("SF UI Display", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(84, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(23, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "GRADE LEVEL:";
            // 
            // NewGradeLevelDropdown
            // 
            this.NewGradeLevelDropdown.BackColor = System.Drawing.Color.Transparent;
            this.NewGradeLevelDropdown.BorderRadius = 2;
            this.NewGradeLevelDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.NewGradeLevelDropdown.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.NewGradeLevelDropdown.ForeColor = System.Drawing.Color.Black;
            this.NewGradeLevelDropdown.Items = new string[0];
            this.NewGradeLevelDropdown.Location = new System.Drawing.Point(26, 105);
            this.NewGradeLevelDropdown.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.NewGradeLevelDropdown.Name = "NewGradeLevelDropdown";
            this.NewGradeLevelDropdown.NomalColor = System.Drawing.Color.WhiteSmoke;
            this.NewGradeLevelDropdown.onHoverColor = System.Drawing.Color.Silver;
            this.NewGradeLevelDropdown.selectedIndex = -1;
            this.NewGradeLevelDropdown.Size = new System.Drawing.Size(265, 33);
            this.NewGradeLevelDropdown.TabIndex = 16;
            this.NewGradeLevelDropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionDropdown_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "SECTION:";
            // 
            // NewSectionDropdown
            // 
            this.NewSectionDropdown.BackColor = System.Drawing.Color.Transparent;
            this.NewSectionDropdown.BorderRadius = 2;
            this.NewSectionDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.NewSectionDropdown.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.NewSectionDropdown.ForeColor = System.Drawing.Color.Black;
            this.NewSectionDropdown.Items = new string[0];
            this.NewSectionDropdown.Location = new System.Drawing.Point(26, 46);
            this.NewSectionDropdown.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.NewSectionDropdown.Name = "NewSectionDropdown";
            this.NewSectionDropdown.NomalColor = System.Drawing.Color.WhiteSmoke;
            this.NewSectionDropdown.onHoverColor = System.Drawing.Color.Silver;
            this.NewSectionDropdown.selectedIndex = -1;
            this.NewSectionDropdown.Size = new System.Drawing.Size(265, 33);
            this.NewSectionDropdown.TabIndex = 14;
            this.NewSectionDropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionDropdown_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.OldGradeLevelDropdown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.OldSectionDropdown);
            this.groupBox1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 165);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "YOUR CURRENT ENROLLEMENT DETAILS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(23, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "CURRENT GRADE LEVEL:";
            // 
            // OldGradeLevelDropdown
            // 
            this.OldGradeLevelDropdown.BackColor = System.Drawing.Color.Transparent;
            this.OldGradeLevelDropdown.BorderRadius = 2;
            this.OldGradeLevelDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.OldGradeLevelDropdown.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.OldGradeLevelDropdown.ForeColor = System.Drawing.Color.Black;
            this.OldGradeLevelDropdown.Items = new string[0];
            this.OldGradeLevelDropdown.Location = new System.Drawing.Point(26, 105);
            this.OldGradeLevelDropdown.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.OldGradeLevelDropdown.Name = "OldGradeLevelDropdown";
            this.OldGradeLevelDropdown.NomalColor = System.Drawing.Color.WhiteSmoke;
            this.OldGradeLevelDropdown.onHoverColor = System.Drawing.Color.Silver;
            this.OldGradeLevelDropdown.selectedIndex = -1;
            this.OldGradeLevelDropdown.Size = new System.Drawing.Size(265, 33);
            this.OldGradeLevelDropdown.TabIndex = 16;
            this.OldGradeLevelDropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionDropdown_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "CURRENT SECTION:";
            // 
            // OldSectionDropdown
            // 
            this.OldSectionDropdown.BackColor = System.Drawing.Color.Transparent;
            this.OldSectionDropdown.BorderRadius = 2;
            this.OldSectionDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.OldSectionDropdown.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.OldSectionDropdown.ForeColor = System.Drawing.Color.Black;
            this.OldSectionDropdown.Items = new string[0];
            this.OldSectionDropdown.Location = new System.Drawing.Point(26, 46);
            this.OldSectionDropdown.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.OldSectionDropdown.Name = "OldSectionDropdown";
            this.OldSectionDropdown.NomalColor = System.Drawing.Color.WhiteSmoke;
            this.OldSectionDropdown.onHoverColor = System.Drawing.Color.Silver;
            this.OldSectionDropdown.selectedIndex = -1;
            this.OldSectionDropdown.Size = new System.Drawing.Size(265, 33);
            this.OldSectionDropdown.TabIndex = 14;
            this.OldSectionDropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionDropdown_KeyDown);
            // 
            // StudentSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(849, 471);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(865, 510);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(865, 510);
            this.Name = "StudentSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STUDENT SETTINGS";
            this.Load += new System.EventHandler(this.StudentSettingsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionDropdown_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            this.ListofSections_GroupBox.ResumeLayout(false);
            this.bunifuCards2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListofSectionsGridview)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ListofSections_GroupBox;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.DataGridView ListofSectionsGridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSectionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaxStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnrolled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSchoolYear;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDropdown OldGradeLevelDropdown;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuDropdown OldSectionDropdown;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuDropdown NewGradeLevelDropdown;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuDropdown NewSectionDropdown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public Bunifu.Framework.UI.BunifuFlatButton UpdateButton;
    }
}