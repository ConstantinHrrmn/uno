namespace uno_game
{
    partial class GameFrame
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
            this.pbMainStack = new System.Windows.Forms.PictureBox();
            this.pbPicDeck = new System.Windows.Forms.PictureBox();
            this.lblPlus = new System.Windows.Forms.Label();
            this.ChoosenColor = new System.Windows.Forms.Panel();
            this.lblWinner = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainStack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMainStack
            // 
            this.pbMainStack.BackgroundImage = global::uno_game.Properties.Resources.blue_0_large;
            this.pbMainStack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbMainStack.Location = new System.Drawing.Point(627, 189);
            this.pbMainStack.Name = "pbMainStack";
            this.pbMainStack.Size = new System.Drawing.Size(182, 268);
            this.pbMainStack.TabIndex = 0;
            this.pbMainStack.TabStop = false;
            // 
            // pbPicDeck
            // 
            this.pbPicDeck.BackgroundImage = global::uno_game.Properties.Resources.card_back_large;
            this.pbPicDeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPicDeck.Location = new System.Drawing.Point(1199, 189);
            this.pbPicDeck.Name = "pbPicDeck";
            this.pbPicDeck.Size = new System.Drawing.Size(182, 268);
            this.pbPicDeck.TabIndex = 1;
            this.pbPicDeck.TabStop = false;
            this.pbPicDeck.Click += new System.EventHandler(this.PbPicDeck_Click);
            // 
            // lblPlus
            // 
            this.lblPlus.AutoSize = true;
            this.lblPlus.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus.ForeColor = System.Drawing.Color.White;
            this.lblPlus.Location = new System.Drawing.Point(1264, 460);
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.Size = new System.Drawing.Size(54, 60);
            this.lblPlus.TabIndex = 2;
            this.lblPlus.Text = "0";
            // 
            // ChoosenColor
            // 
            this.ChoosenColor.Location = new System.Drawing.Point(1157, 189);
            this.ChoosenColor.Name = "ChoosenColor";
            this.ChoosenColor.Size = new System.Drawing.Size(36, 268);
            this.ChoosenColor.TabIndex = 3;
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.White;
            this.lblWinner.Location = new System.Drawing.Point(378, 450);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(679, 55);
            this.lblWinner.TabIndex = 4;
            this.lblWinner.Text = "THE WINNER IS : PLAYER 1";
            this.lblWinner.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 26);
            this.lblStatus.TabIndex = 5;
            // 
            // GameFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1450, 912);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.ChoosenColor);
            this.Controls.Add(this.lblPlus);
            this.Controls.Add(this.pbPicDeck);
            this.Controls.Add(this.pbMainStack);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameFrame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UNO";
            this.Load += new System.EventHandler(this.GameFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainStack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicDeck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMainStack;
        private System.Windows.Forms.PictureBox pbPicDeck;
        private System.Windows.Forms.Label lblPlus;
        private System.Windows.Forms.Panel ChoosenColor;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Label lblStatus;
    }
}

