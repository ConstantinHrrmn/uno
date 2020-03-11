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
        }

        private void tbx_click(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            tbx.SelectAll();
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            gf.Ctrl.CreatePlayers(Convert.ToInt32(nudPlayer.Value));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void StartingPage_Load(object sender, EventArgs e)
        {

        }
    }
}
