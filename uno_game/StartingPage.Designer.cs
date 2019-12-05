namespace uno_game
{
    partial class StartingPage
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
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.tbxip = new System.Windows.Forms.TextBox();
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.btnCreateServer = new System.Windows.Forms.Button();
            this.lblIp = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTitle
            // 
            this.pbTitle.BackgroundImage = global::uno_game.Properties.Resources.uno;
            this.pbTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTitle.Location = new System.Drawing.Point(-7, -36);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(475, 240);
            this.pbTitle.TabIndex = 1;
            this.pbTitle.TabStop = false;
            this.pbTitle.Click += new System.EventHandler(this.PbTitle_Click);
            // 
            // tbxip
            // 
            this.tbxip.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxip.Location = new System.Drawing.Point(51, 258);
            this.tbxip.Name = "tbxip";
            this.tbxip.Size = new System.Drawing.Size(226, 41);
            this.tbxip.TabIndex = 5;
            this.tbxip.Text = "10.5.51.50";
            this.tbxip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.BackColor = System.Drawing.Color.OliveDrab;
            this.btnConnectServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectServer.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectServer.Location = new System.Drawing.Point(283, 258);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(122, 40);
            this.btnConnectServer.TabIndex = 6;
            this.btnConnectServer.Text = "Connect";
            this.btnConnectServer.UseVisualStyleBackColor = false;
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // btnCreateServer
            // 
            this.btnCreateServer.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCreateServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateServer.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateServer.Location = new System.Drawing.Point(51, 326);
            this.btnCreateServer.Name = "btnCreateServer";
            this.btnCreateServer.Size = new System.Drawing.Size(354, 51);
            this.btnCreateServer.TabIndex = 7;
            this.btnCreateServer.Text = "Be the Host";
            this.btnCreateServer.UseVisualStyleBackColor = false;
            this.btnCreateServer.Click += new System.EventHandler(this.btnCreateServer_Click);
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(48, 380);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(118, 13);
            this.lblIp.TabIndex = 8;
            this.lblIp.Text = "Your ip : xxx.xxx.xxx.xxx";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // StartingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 504);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.btnCreateServer);
            this.Controls.Add(this.btnConnectServer);
            this.Controls.Add(this.tbxip);
            this.Controls.Add(this.pbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartingPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.StartingPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.TextBox tbxip;
        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.Button btnCreateServer;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}