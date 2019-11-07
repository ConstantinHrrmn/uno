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
    public partial class ColorChooser : Form
    {
        public ColorChooser()
        {
            InitializeComponent();
        }

        private void PRed_Click(object sender, EventArgs e)
        {
            this.Tag = "R";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PGreen_Click(object sender, EventArgs e)
        {
            this.Tag = "G";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PBlue_Click(object sender, EventArgs e)
        {
            this.Tag = "B";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PYellow_Click(object sender, EventArgs e)
        {
            this.Tag = "Y";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ColorChooser_Load(object sender, EventArgs e)
        {

        }
    }
}
