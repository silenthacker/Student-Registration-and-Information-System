namespace Application
{
    partial class GradeReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GradeReportForm));
            this.ParentContainer = new Bunifu.Framework.UI.BunifuCards();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ParentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParentContainer
            // 
            this.ParentContainer.BackColor = System.Drawing.Color.White;
            this.ParentContainer.BorderRadius = 2;
            this.ParentContainer.BottomSahddow = true;
            this.ParentContainer.color = System.Drawing.Color.Tomato;
            this.ParentContainer.Controls.Add(this.groupBox1);
            this.ParentContainer.LeftSahddow = false;
            this.ParentContainer.Location = new System.Drawing.Point(12, 12);
            this.ParentContainer.Name = "ParentContainer";
            this.ParentContainer.RightSahddow = false;
            this.ParentContainer.ShadowDepth = 20;
            this.ParentContainer.Size = new System.Drawing.Size(780, 422);
            this.ParentContainer.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 400);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GRADE REPORTS AND STATISTICS";
            // 
            // GradeReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(804, 446);
            this.Controls.Add(this.ParentContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 485);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(820, 485);
            this.Name = "GradeReportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRADE REPORTS & STATISTICS";
            this.ParentContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards ParentContainer;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}