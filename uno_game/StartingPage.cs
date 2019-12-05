using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

            this.lblIp.Text = "Your IP: " + this.gf.Ctrl.GetLocalIp();

        }

        private void VerifyButon()
        {

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {        

        }

        private void StartingPage_Load(object sender, EventArgs e)
        {
        }

        private void PbTitle_Click(object sender, EventArgs e)
        {

        }

        private void tbx_click(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            tbx.SelectAll();
        }

        private void btnCreateServer_Click(object sender, EventArgs e)
        {
            this.gf.Ctrl.CreateServer();

            gf.Ctrl.CreatePlayers(0);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            this.gf.Ctrl.Connect(this.tbxip.Text, "newPlayer;Computer 1;"+this.gf.Ctrl.GetLocalIp());
            this.gf.Ctrl.CreateServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = this.gf.Ctrl.GetInfos(this.tbxip.Text, this.gf.Ctrl.GetLocalIp());

        }
    }
}
