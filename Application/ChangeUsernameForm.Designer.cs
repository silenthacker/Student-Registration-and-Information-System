namespace Application
{
    partial class ChangeUsernameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUsernameForm));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.SubmitButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.CloseButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.ConfirmUsernameTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.NewUsernameTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.OldUsernameTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.White;
            this.bunifuCards1.Controls.Add(this.SubmitButton);
            this.bunifuCards1.Controls.Add(this.CloseButton);
            this.bunifuCards1.Controls.Add(this.bunifuSeparator1);
            this.bunifuCards1.Controls.Add(this.ConfirmUsernameTextbox);
            this.bunifuCards1.Controls.Add(this.NewUsernameTextbox);
            this.bunifuCards1.Controls.Add(this.OldUsernameTextbox);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.LeftSahddow = true;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(555, 283);
            this.bunifuCards1.TabIndex = 0;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SubmitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubmitButton.BorderRadius = 2;
            this.SubmitButton.ButtonText = "UPDATE";
            this.SubmitButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SubmitButton.DisabledColor = System.Drawing.Color.Gray;
            this.SubmitButton.Iconcolor = System.Drawing.Color.Transparent;
            this.SubmitButton.Iconimage = null;
            this.SubmitButton.Iconimage_right = null;
            this.SubmitButton.Iconimage_right_Selected = null;
            this.SubmitButton.Iconimage_Selected = null;
            this.SubmitButton.IconMarginLeft = 0;
            this.SubmitButton.IconMarginRight = 0;
            this.SubmitButton.IconRightVisible = false;
            this.SubmitButton.IconRightZoom = 0D;
            this.SubmitButton.IconVisible = false;
            this.SubmitButton.IconZoom = 90D;
            this.SubmitButton.IsTab = false;
            this.SubmitButton.Location = new System.Drawing.Point(348, 239);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SubmitButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.SubmitButton.OnHoverTextColor = System.Drawing.Color.White;
            this.SubmitButton.selected = false;
            this.SubmitButton.Size = new System.Drawing.Size(90, 30);
            this.SubmitButton.TabIndex = 25;
            this.SubmitButton.Text = "UPDATE";
            this.SubmitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SubmitButton.Textcolor = System.Drawing.Color.White;
            this.SubmitButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            this.SubmitButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OldUsernamelTextbox_KeyDown);
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
            this.CloseButton.Location = new System.Drawing.Point(448, 239);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.CloseButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.CloseButton.OnHoverTextColor = System.Drawing.Color.White;
            this.CloseButton.selected = false;
            this.CloseButton.Size = new System.Drawing.Size(90, 30);
            this.CloseButton.TabIndex = 24;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Textcolor = System.Drawing.Color.White;
            this.CloseButton.TextFont = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OldUsernamelTextbox_KeyDown);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(17, 222);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(521, 11);
            this.bunifuSeparator1.TabIndex = 14;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OldUsernamelTextbox_KeyDown);
            // 
            // ConfirmUsernameTextbox
            // 
            this.ConfirmUsernameTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfirmUsernameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ConfirmUsernameTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmUsernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmUsernameTextbox.HintForeColor = System.Drawing.Color.Empty;
            this.ConfirmUsernameTextbox.HintText = "";
            this.ConfirmUsernameTextbox.isPassword = false;
            this.ConfirmUsernameTextbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.ConfirmUsernameTextbox.LineIdleColor = System.Drawing.Color.Gray;
            this.ConfirmUsernameTextbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.ConfirmUsernameTextbox.LineThickness = 3;
            this.ConfirmUsernameTextbox.Location = new System.Drawing.Point(42, 164);
            this.ConfirmUsernameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmUsernameTextbox.Name = "ConfirmUsernameTextbox";
            this.ConfirmUsernameTextbox.Size = new System.Drawing.Size(379, 33);
            this.ConfirmUsernameTextbox.TabIndex = 6;
            this.ConfirmUsernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConfirmUsernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfirmUsernameTextbox_KeyDown);
            // 
            // NewUsernameTextbox
            // 
            this.NewUsernameTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NewUsernameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewUsernameTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewUsernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewUsernameTextbox.HintForeColor = System.Drawing.Color.Empty;
            this.NewUsernameTextbox.HintText = "";
            this.NewUsernameTextbox.isPassword = false;
            this.NewUsernameTextbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.NewUsernameTextbox.LineIdleColor = System.Drawing.Color.Gray;
            this.NewUsernameTextbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.NewUsernameTextbox.LineThickness = 3;
            this.NewUsernameTextbox.Location = new System.Drawing.Point(42, 106);
            this.NewUsernameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.NewUsernameTextbox.Name = "NewUsernameTextbox";
            this.NewUsernameTextbox.Size = new System.Drawing.Size(379, 33);
            this.NewUsernameTextbox.TabIndex = 5;
            this.NewUsernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NewUsernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewUsernameTextbox_KeyDown);
            // 
            // OldUsernameTextbox
            // 
            this.OldUsernameTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.OldUsernameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OldUsernameTextbox.Enabled = false;
            this.OldUsernameTextbox.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OldUsernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OldUsernameTextbox.HintForeColor = System.Drawing.Color.Empty;
            this.OldUsernameTextbox.HintText = "";
            this.OldUsernameTextbox.isPassword = false;
            this.OldUsernameTextbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.OldUsernameTextbox.LineIdleColor = System.Drawing.Color.Gray;
            this.OldUsernameTextbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.OldUsernameTextbox.LineThickness = 3;
            this.OldUsernameTextbox.Location = new System.Drawing.Point(42, 48);
            this.OldUsernameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.OldUsernameTextbox.Name = "OldUsernameTextbox";
            this.OldUsernameTextbox.Size = new System.Drawing.Size(379, 33);
            this.OldUsernameTextbox.TabIndex = 4;
            this.OldUsernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OldUsernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OldUsernamelTextbox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "CONFIRM USERNAME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "NEW USERNAME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "OLD USERNAME:";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this.OldUsernameTextbox;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 2;
            this.bunifuElipse2.TargetControl = this.NewUsernameTextbox;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 2;
            this.bunifuElipse3.TargetControl = this.ConfirmUsernameTextbox;
            // 
            // ChangeUsernameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(579, 307);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(595, 346);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(595, 346);
            this.Name = "ChangeUsernameForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHANGE USERNAME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeUsernameForm_FormClosing);
            this.Load += new System.EventHandler(this.ChangeUsernameForm_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox OldUsernameTextbox;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ConfirmUsernameTextbox;
        private Bunifu.Framework.UI.BunifuMaterialTextbox NewUsernameTextbox;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuFlatButton SubmitButton;
        private Bunifu.Framework.UI.BunifuFlatButton CloseButton;
    }
}