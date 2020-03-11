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
            this.btnStart = new System.Windows.Forms.Button();
            this.nudPlayer = new System.Windows.Forms.NumericUpDown();
            this.lblPlayers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayer)).BeginInit();
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
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Red;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(138, 279);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(190, 55);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // nudPlayer
            // 
            this.nudPlayer.Location = new System.Drawing.Point(138, 238);
            this.nudPlayer.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPlayer.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPlayer.Name = "nudPlayer";
            this.nudPlayer.Size = new System.Drawing.Size(190, 20);
            this.nudPlayer.TabIndex = 3;
            this.nudPlayer.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(135, 222);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(91, 13);
            this.lblPlayers.TabIndex = 4;
            this.lblPlayers.Text = "Amount of players";
            // 
            // StartingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 350);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.nudPlayer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartingPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.StartingPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nudPlayer;
        private System.Windows.Forms.Label lblPlayers;
    }
}