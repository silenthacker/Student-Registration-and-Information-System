namespace Application
{
    partial class AccountPermissionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountPermissionsForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.ListofPermissionsGridview = new System.Windows.Forms.DataGridView();
            this.ColumnPermissionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTeacherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPMS01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPMS02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPMS03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListofPermissionsGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.ListofPermissionsGridview);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(914, 487);
            this.bunifuCards1.TabIndex = 0;
            // 
            // ListofPermissionsGridview
            // 
            this.ListofPermissionsGridview.AllowUserToAddRows = false;
            this.ListofPermissionsGridview.AllowUserToDeleteRows = false;
            this.ListofPermissionsGridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ListofPermissionsGridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListofPermissionsGridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListofPermissionsGridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListofPermissionsGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListofPermissionsGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPermissionID,
            this.ColumnUserID,
            this.ColumnTeacherID,
            this.ColumnPMS01,
            this.ColumnPMS02,
            this.ColumnPMS03});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SF UI Display", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListofPermissionsGridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.ListofPermissionsGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListofPermissionsGridview.EnableHeadersVisualStyles = false;
            this.ListofPermissionsGridview.GridColor = System.Drawing.Color.Silver;
            this.ListofPermissionsGridview.Location = new System.Drawing.Point(0, 0);
            this.ListofPermissionsGridview.Name = "ListofPermissionsGridview";
            this.ListofPermissionsGridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListofPermissionsGridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ListofPermissionsGridview.Size = new System.Drawing.Size(914, 487);
            this.ListofPermissionsGridview.TabIndex = 9;
            this.ListofPermissionsGridview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListofPermissionsGridview_CellValueChanged);
            this.ListofPermissionsGridview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountPermissionsForm_KeyDown);
            // 
            // ColumnPermissionID
            // 
            this.ColumnPermissionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPermissionID.DataPropertyName = "PERMISSION ID";
            this.ColumnPermissionID.HeaderText = "PERMISSION ID";
            this.ColumnPermissionID.Name = "ColumnPermissionID";
            this.ColumnPermissionID.ReadOnly = true;
            this.ColumnPermissionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnUserID
            // 
            this.ColumnUserID.DataPropertyName = "USER ID";
            this.ColumnUserID.HeaderText = "USER ID";
            this.ColumnUserID.Name = "ColumnUserID";
            this.ColumnUserID.ReadOnly = true;
            this.ColumnUserID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnUserID.Width = 120;
            // 
            // ColumnTeacherID
            // 
            this.ColumnTeacherID.DataPropertyName = "TEACHER ID";
            this.ColumnTeacherID.HeaderText = "TEACHER ID";
            this.ColumnTeacherID.Name = "ColumnTeacherID";
            this.ColumnTeacherID.ReadOnly = true;
            this.ColumnTeacherID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnTeacherID.Width = 125;
            // 
            // ColumnPMS01
            // 
            this.ColumnPMS01.DataPropertyName = "PMS-01";
            this.ColumnPMS01.HeaderText = "IMPORT STUDENT";
            this.ColumnPMS01.Name = "ColumnPMS01";
            this.ColumnPMS01.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPMS01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPMS01.Width = 150;
            // 
            // ColumnPMS02
            // 
            this.ColumnPMS02.DataPropertyName = "PMS-02";
            this.ColumnPMS02.HeaderText = "STUDENT REGISTRATION";
            this.ColumnPMS02.Name = "ColumnPMS02";
            this.ColumnPMS02.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPMS02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPMS02.Width = 190;
            // 
            // ColumnPMS03
            // 
            this.ColumnPMS03.DataPropertyName = "PMS-03";
            this.ColumnPMS03.HeaderText = "DISABLE STUDENT";
            this.ColumnPMS03.Name = "ColumnPMS03";
            this.ColumnPMS03.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPMS03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPMS03.Width = 150;
            // 
            // AccountPermissionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(938, 511);
            this.Controls.Add(this.bunifuCards1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(954, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(954, 550);
            this.Name = "AccountPermissionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCOUNT PERMISSIONS";
            this.Load += new System.EventHandler(this.AccountPermissionsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountPermissionsForm_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListofPermissionsGridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.DataGridView ListofPermissionsGridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPermissionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeacherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPMS01;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPMS02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPMS03;
    }
}