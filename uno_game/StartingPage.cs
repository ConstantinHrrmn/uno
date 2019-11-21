using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uno_game
{
    public partial class StartingPage : Form
    {
        private int playerCount = 0;
        private Size baseSizeTbx = new Size(354, 20);
        private Point basePositionTbx = new Point(58, 220);

        private List<TextBox> ltb = new List<TextBox>();
        private GameFrame gf;

        public StartingPage(GameFrame a_gf)
        {
            InitializeComponent();
            gf = a_gf;
        }

        private void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            if (playerCount < 5)
            {
                playerCount++;
                Point newPosition = new Point(this.basePositionTbx.X, this.basePositionTbx.Y + (this.playerCount * this.baseSizeTbx.Height) + (this.playerCount * 10));
                this.CreateTexbox(this.baseSizeTbx, newPosition, this.playerCount);
            }

            this.VerifyButon();
            
        }

        private void VerifyButon()
        {
            if (playerCount >= 5)
            {
                //this.btnAddPlayer.Enabled = false;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {        
            gf.Ctrl.CreatePlayers(Convert.ToInt32(nudIA.Value));

            this.DialogResult = DialogResult.OK;
            
            this.Close();

        }

        private void CreateTexbox(Size s, Point p, int index)
        {
            TextBox tbx = new TextBox();
            tbx.Text = "Nom du joueur " + index;
            tbx.Name = "NewPlayer" + index;
            tbx.Size = s;
            tbx.Location = p;
            tbx.Click += tbx_click;
            this.Controls.Add(tbx);
            this.ltb.Add(tbx);
        }

        private void StartingPage_Load(object sender, EventArgs e)
        {
            //this.btnAddPlayer.PerformClick();
        }

        private void PbTitle_Click(object sender, EventArgs e)
        {

        }

        private void tbx_click(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            tbx.SelectAll();
        }
    }
}
