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
    public partial class Logging : Form
    {
        public Logging()
        {
            InitializeComponent();
        }

        private void Logging_Load(object sender, EventArgs e)
        {

        }

        public void Log(string msg)
        {
            lbLog.Items.Add(msg);
        }
    }
}
