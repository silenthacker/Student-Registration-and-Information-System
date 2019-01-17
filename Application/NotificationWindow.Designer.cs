namespace Application
{
    partial class NotificationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationWindow));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.MessageString = new System.Windows.Forms.Label();
            this.MsgImage = new System.Windows.Forms.PictureBox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.CloseButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MsgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 2;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.White;
            this.bunifuCards1.Controls.Add(this.MessageString);
            this.bunifuCards1.Controls.Add(this.MsgImage);
            this.bunifuCards1.Controls.Add(this.bunifuSeparator1);
            this.bunifuCards1.Controls.Add(this.CloseButton);
            this.bunifuCards1.LeftSahddow = true;
            this.bunifuCards1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(410, 187);
            this.bunifuCards1.TabIndex = 0;
            // 
            // MessageString
            // 
            this.MessageString.AutoSize = true;
            this.MessageString.Font = new System.Drawing.Font("SF UI Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageString.Location = new System.Drawing.Point(120, 38);
            this.MessageString.Name = "MessageString";
            this.MessageString.Size = new System.Drawing.Size(114, 15);
            this.MessageString.TabIndex = 32;
            this.MessageString.Text = "MESSAGE STRING";
            // 
            // MsgImage
            // 
            this.MsgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgImage.BackColor = System.Drawing.Color.Transparent;
            this.MsgImage.ErrorImage = null;
            this.MsgImage.Image = global::Application.Properties.Resources.error;
            this.MsgImage.InitialImage = null;
            this.MsgImage.Location = new System.Drawing.Point(24, 23);
            this.MsgImage.Name = "MsgImage";
            this.MsgImage.Size = new System.Drawing.Size(90, 90);
            this.MsgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MsgImage.TabIndex = 31;
            this.MsgImage.TabStop = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(24, 132);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(372, 10);
            this.bunifuSeparator1.TabIndex = 30;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bunifuSeparator1_KeyDown);
            // 
            // CloseButton
            // 
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.CloseButton.Depth = 0;
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.CloseButton.Location = new System.Drawing.Point(303, 148);
            this.CloseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Primary = true;
            this.CloseButton.Size = new System.Drawing.Size(93, 29);
            this.CloseButton.TabIndex = 29;
            this.CloseButton.Text = "GOT IT";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CloseButton_KeyDown);
            // 
            // NotificationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(434, 213);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 252);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 252);
            this.Name = "NotificationWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MESSAGE CONTENT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotificationWindow_FormClosing);
            this.Load += new System.EventHandler(this.NotificationWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationWindow_KeyDown);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MsgImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.Label MessageString;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private MaterialSkin.Controls.MaterialRaisedButton CloseButton;
        public System.Windows.Forms.PictureBox MsgImage;
    }
}