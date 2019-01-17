namespace Application
{
    partial class StudentAverageForm_Teacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentAverageForm_Teacher));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.StudentAverageGridview = new System.Windows.Forms.DataGridView();
            this.StudentIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRNColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeLevelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGAAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolYearColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GradeLevelDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SchoolYearDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.SectionDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MsgImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.bunifuCards2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentAverageGridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MsgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.groupBox2);
            this.bunifuCards1.Controls.Add(this.groupBox1);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(860, 477);
            this.bunifuCards1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.bunifuCards2);
            this.groupBox2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(13, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(834, 366);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "STUDENT GPA AND AVERAGE";
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.BackColor = System.Drawing.Color.White;
            this.bunifuCards2.BorderRadius = 0;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.Tomato;
            this.bunifuCards2.Controls.Add(this.StudentAverageGridview);
            this.bunifuCards2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards2.LeftSahddow = true;
            this.bunifuCards2.Location = new System.Drawing.Point(1, 17);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(832, 348);
            this.bunifuCards2.TabIndex = 0;
            // 
            // StudentAverageGridview
            // 
            this.StudentAverageGridview.AllowUserToAddRows = false;
            this.StudentAverageGridview.AllowUserToDeleteRows = false;
            this.StudentAverageGridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.StudentAverageGridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StudentAverageGridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentAverageGridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.StudentAverageGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentAverageGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentIDColumn,
            this.StudentNameColumn,
            this.LRNColumn,
            this.GradeLevelColumn,
            this.SectionColumn,
            this.FGAColumn,
            this.SGAColumn,
            this.TGAColumn,
            this.FGAAColumn,
            this.GPAColumn,
            this.SchoolYearColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SF UI Display", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentAverageGridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.StudentAverageGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentAverageGridview.EnableHeadersVisualStyles = false;
            this.StudentAverageGridview.GridColor = System.Drawing.Color.Silver;
            this.StudentAverageGridview.Location = new System.Drawing.Point(0, 0);
            this.StudentAverageGridview.Name = "StudentAverageGridview";
            this.StudentAverageGridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentAverageGridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.StudentAverageGridview.Size = new System.Drawing.Size(832, 348);
            this.StudentAverageGridview.TabIndex = 13;
            this.StudentAverageGridview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentAverageForm_Teacher_KeyDown);
            // 
            // StudentIDColumn
            // 
            this.StudentIDColumn.DataPropertyName = "STUDENT ID";
            this.StudentIDColumn.HeaderText = "STUDENT ID";
            this.StudentIDColumn.Name = "StudentIDColumn";
            this.StudentIDColumn.ReadOnly = true;
            this.StudentIDColumn.Width = 130;
            // 
            // StudentNameColumn
            // 
            this.StudentNameColumn.DataPropertyName = "STUDENT NAME";
            this.StudentNameColumn.HeaderText = "STUDENT NAME";
            this.StudentNameColumn.Name = "StudentNameColumn";
            this.StudentNameColumn.Width = 170;
            // 
            // LRNColumn
            // 
            this.LRNColumn.DataPropertyName = "LRN";
            this.LRNColumn.HeaderText = "LRN";
            this.LRNColumn.Name = "LRNColumn";
            this.LRNColumn.ReadOnly = true;
            this.LRNColumn.Width = 140;
            // 
            // GradeLevelColumn
            // 
            this.GradeLevelColumn.DataPropertyName = "GRADE LEVEL";
            this.GradeLevelColumn.HeaderText = "GRADE LEVEL";
            this.GradeLevelColumn.Name = "GradeLevelColumn";
            this.GradeLevelColumn.Width = 150;
            // 
            // SectionColumn
            // 
            this.SectionColumn.DataPropertyName = "SECTION";
            this.SectionColumn.HeaderText = "SECTION";
            this.SectionColumn.Name = "SectionColumn";
            this.SectionColumn.ReadOnly = true;
            this.SectionColumn.Width = 170;
            // 
            // FGAColumn
            // 
            this.FGAColumn.DataPropertyName = "FIRST GRADING";
            this.FGAColumn.HeaderText = "FIRST GRADING";
            this.FGAColumn.Name = "FGAColumn";
            this.FGAColumn.ReadOnly = true;
            this.FGAColumn.Width = 125;
            // 
            // SGAColumn
            // 
            this.SGAColumn.DataPropertyName = "SECOND GRADING";
            this.SGAColumn.HeaderText = "SECOND GRADING";
            this.SGAColumn.Name = "SGAColumn";
            this.SGAColumn.ReadOnly = true;
            this.SGAColumn.Width = 150;
            // 
            // TGAColumn
            // 
            this.TGAColumn.DataPropertyName = "THIRD GRADING";
            this.TGAColumn.HeaderText = "THIRD GRADING";
            this.TGAColumn.Name = "TGAColumn";
            this.TGAColumn.ReadOnly = true;
            this.TGAColumn.Width = 130;
            // 
            // FGAAColumn
            // 
            this.FGAAColumn.DataPropertyName = "FOURTH GRADING";
            this.FGAAColumn.HeaderText = "FOURTH GRADING";
            this.FGAAColumn.Name = "FGAAColumn";
            this.FGAAColumn.ReadOnly = true;
            this.FGAAColumn.Width = 150;
            // 
            // GPAColumn
            // 
            this.GPAColumn.DataPropertyName = "GPA";
            this.GPAColumn.HeaderText = "GPA";
            this.GPAColumn.Name = "GPAColumn";
            this.GPAColumn.ReadOnly = true;
            // 
            // SchoolYearColumn
            // 
            this.SchoolYearColumn.DataPropertyName = "SCHOOL YEAR";
            this.SchoolYearColumn.HeaderText = "SCHOOL YEAR";
            this.SchoolYearColumn.Name = "SchoolYearColumn";
            this.SchoolYearColumn.ReadOnly = true;
            this.SchoolYearColumn.Width = 130;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.GradeLevelDropdown);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.SchoolYearDropdown);
            this.groupBox1.Controls.Add(this.SectionDropdown);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.MsgImage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPTIONS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(57, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 69;
            this.label5.Text = "GRADE LEVEL:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("SF UI Display", 11.25F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(148, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 70;
            this.label6.Text = "*";
            // 
            // GradeLevelDropdown
            // 
            this.GradeLevelDropdown.BackColor = System.Drawing.Color.Transparent;
            this.GradeLevelDropdown.BorderRadius = 2;
            this.GradeLevelDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.GradeLevelDropdown.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.GradeLevelDropdown.ForeColor = System.Drawing.Color.Black;
            this.GradeLevelDropdown.Items = new string[] {
        "Grade 7",
        "Grade 8",
        "Grade 9",
        "Grade 10"};
            this.GradeLevelDropdown.Location = new System.Drawing.Point(60, 34);
            this.GradeLevelDropdown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GradeLevelDropdown.Name = "GradeLevelDropdown";
            this.GradeLevelDropdown.NomalColor = System.Drawing.Color.WhiteSmoke;
            this.GradeLevelDropdown.onHoverColor = System.Drawing.Color.Silver;
            this.GradeLevelDropdown.selectedIndex = 0;
            this.GradeLevelDropdown.Size = new System.Drawing.Size(225, 33);
            this.GradeLevelDropdown.TabIndex = 68;
            this.GradeLevelDropdown.onItemSelected += new System.EventHandler(this.GradeLevelDropdown_onItemSelected);
            this.GradeLevelDropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentAverageForm_Teacher_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::Application.Properties.Resources.studreport;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(17, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 67;
            this.pictureBox2.TabStop = false;
            // 
            // SchoolYearDropdown
            // 
            this.SchoolYearDropdown.BackColor = System.Drawing.Color.Transparent;
            this.SchoolYearDropdown.BorderRadius = 2;
            this.SchoolYearDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.SchoolYearDropdown.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.SchoolYearDropdown.ForeColor = System.Drawing.Color.Black;
            this.SchoolYearDropdown.Items = new string[0];
            this.SchoolYearDropdown.Location = new System.Drawing.Point(621, 34);
            this.SchoolYearDropdown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SchoolYearDropdown.Name = "SchoolYearDropdown";
            this.SchoolYearDropdown.NomalColor = System.Drawing.Color.WhiteSmoke;
            this.SchoolYearDropdown.onHoverColor = System.Drawing.Color.Silver;
            this.SchoolYearDropdown.selectedIndex = -1;
            this.SchoolYearDropdown.Size = new System.Drawing.Size(200, 33);
            this.SchoolYearDropdown.TabIndex = 7;
            this.SchoolYearDropdown.onItemSelected += new System.EventHandler(this.SchoolYearDropdown_onItemSelected);
            this.SchoolYearDropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentAverageForm_Teacher_KeyDown);
            // 
            // SectionDropdown
            // 
            this.SectionDropdown.BackColor = System.Drawing.Color.Transparent;
            this.SectionDropdown.BorderRadius = 2;
            this.SectionDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.SectionDropdown.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.SectionDropdown.ForeColor = System.Drawing.Color.Black;
            this.SectionDropdown.Items = new string[0];
            this.SectionDropdown.Location = new System.Drawing.Point(341, 34);
            this.SectionDropdown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SectionDropdown.Name = "SectionDropdown";
            this.SectionDropdown.NomalColor = System.Drawing.Color.WhiteSmoke;
            this.SectionDropdown.onHoverColor = System.Drawing.Color.Silver;
            this.SectionDropdown.selectedIndex = -1;
            this.SectionDropdown.Size = new System.Drawing.Size(225, 33);
            this.SectionDropdown.TabIndex = 4;
            this.SectionDropdown.onItemSelected += new System.EventHandler(this.SectionDropdown_onItemSelected);
            this.SectionDropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentAverageForm_Teacher_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Application.Properties.Resources.schoolyear;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(579, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // MsgImage
            // 
            this.MsgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgImage.BackColor = System.Drawing.Color.Transparent;
            this.MsgImage.ErrorImage = null;
            this.MsgImage.Image = global::Application.Properties.Resources.sections;
            this.MsgImage.InitialImage = null;
            this.MsgImage.Location = new System.Drawing.Point(299, 32);
            this.MsgImage.Name = "MsgImage";
            this.MsgImage.Size = new System.Drawing.Size(35, 35);
            this.MsgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MsgImage.TabIndex = 65;
            this.MsgImage.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(618, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "SCHOOL YEAR:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("SF UI Display", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(715, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(338, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "SECTION:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SF UI Display", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(401, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "*";
            // 
            // StudentAverageForm_Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(884, 501);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 540);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 540);
            this.Name = "StudentAverageForm_Teacher";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STUDENT AVERAGE";
            this.Load += new System.EventHandler(this.StudentAverageForm_Teacher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentAverageForm_Teacher_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.bunifuCards2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentAverageGridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MsgImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.DataGridView StudentAverageGridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRNColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeLevelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGAAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolYearColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuDropdown GradeLevelDropdown;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuDropdown SchoolYearDropdown;
        private Bunifu.Framework.UI.BunifuDropdown SectionDropdown;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox MsgImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}