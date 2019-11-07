namespace uno_game
{
    partial class ColorChooser
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
            this.pRed = new System.Windows.Forms.Panel();
            this.pGreen = new System.Windows.Forms.Panel();
            this.pBlue = new System.Windows.Forms.Panel();
            this.pYellow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pRed
            // 
            this.pRed.BackColor = System.Drawing.Color.Red;
            this.pRed.Location = new System.Drawing.Point(12, 14);
            this.pRed.Name = "pRed";
            this.pRed.Size = new System.Drawing.Size(80, 80);
            this.pRed.TabIndex = 0;
            this.pRed.Click += new System.EventHandler(this.PRed_Click);
            // 
            // pGreen
            // 
            this.pGreen.BackColor = System.Drawing.Color.Lime;
            this.pGreen.Location = new System.Drawing.Point(98, 14);
            this.pGreen.Name = "pGreen";
            this.pGreen.Size = new System.Drawing.Size(80, 80);
            this.pGreen.TabIndex = 1;
            this.pGreen.Click += new System.EventHandler(this.PGreen_Click);
            // 
            // pBlue
            // 
            this.pBlue.BackColor = System.Drawing.Color.Aqua;
            this.pBlue.Location = new System.Drawing.Point(184, 14);
            this.pBlue.Name = "pBlue";
            this.pBlue.Size = new System.Drawing.Size(80, 80);
            this.pBlue.TabIndex = 1;
            this.pBlue.Click += new System.EventHandler(this.PBlue_Click);
            // 
            // pYellow
            // 
            this.pYellow.BackColor = System.Drawing.Color.Yellow;
            this.pYellow.Location = new System.Drawing.Point(270, 14);
            this.pYellow.Name = "pYellow";
            this.pYellow.Size = new System.Drawing.Size(80, 80);
            this.pYellow.TabIndex = 1;
            this.pYellow.Click += new System.EventHandler(this.PYellow_Click);
            // 
            // ColorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(365, 106);
            this.Controls.Add(this.pYellow);
            this.Controls.Add(this.pBlue);
            this.Controls.Add(this.pGreen);
            this.Controls.Add(this.pRed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ColorChooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ColorChooser";
            this.Load += new System.EventHandler(this.ColorChooser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pRed;
        private System.Windows.Forms.Panel pGreen;
        private System.Windows.Forms.Panel pBlue;
        private System.Windows.Forms.Panel pYellow;
    }
}