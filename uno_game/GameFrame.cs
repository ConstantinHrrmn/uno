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
    public partial class GameFrame : Form
    {
        private Controller _ctrl;
        private List<PictureBox> tmpPB = new List<PictureBox>();

        #region Default Cards Values

        const int CARDS_SPACEMENT = 130;
        const int CARDS_POSITION_Y_FROM_BOTTOM = 100;
        private Size BASE_CARD_SIZE = new Size(124, 171);

        #endregion

        public GameFrame()
        {
            InitializeComponent();
            this.Ctrl = new Controller(this);
        }

        public Controller Ctrl { get => _ctrl; set => _ctrl = value; }

        private void GameFrame_Load(object sender, EventArgs e)
        {
            StartingPage st = new StartingPage(this);

            if (st.ShowDialog() == DialogResult.Cancel)
                this.Close();

            this.Ctrl.DebugPlayers();

            this.pbMainStack.Location = new Point(this.Bounds.Width / 2 - this.pbMainStack.Width / 2, this.pbMainStack.Location.Y);

            this.Ctrl.PutFirstCardOnStack();
            //this.Ctrl.DisplayPlayer();
        }

        public void DisplayPlayer(Player p)
        {
            int maxCardsOnRaw = (this.Bounds.Width / this.BASE_CARD_SIZE.Width);
            int extraRaws = p.Cards.Count / maxCardsOnRaw;

            int countCardsToDisplay = p.Cards.Count;
            int center = (this.Bounds.Width / 2);
            int y = this.Bounds.Height - CARDS_POSITION_Y_FROM_BOTTOM - BASE_CARD_SIZE.Height;

            int x = GetXPosition(maxCardsOnRaw, center, countCardsToDisplay, p);

            foreach (PictureBox item in tmpPB)
            {
                this.Controls.Remove(item);
            }

            this.tmpPB.Clear();

            int cpt = 0;
            foreach (Card card in p.Cards)
            {
                if (cpt % maxCardsOnRaw == 0 && cpt != 0)
                {
                    cpt = 0;
                    y -= 2 * BASE_CARD_SIZE.Height - CARDS_SPACEMENT;
                    x = GetXPosition(maxCardsOnRaw, center, countCardsToDisplay, p);
                }

                Point p_c = new Point(x, y);
                this.DisplayCard(card, p_c, BASE_CARD_SIZE);
                x += CARDS_SPACEMENT;
                cpt++;
            }
        }

        public int GetXPosition(int maxCardsOnRaw, int center, int countCardsToDisplay, Player p)
        {
            int x = 0;
            if (p.Cards.Count > maxCardsOnRaw)
            {
                x = maxCardsOnRaw % 2 == 0 ? center - (maxCardsOnRaw / 2) * CARDS_SPACEMENT : (center - (BASE_CARD_SIZE.Width / 2)) - ((maxCardsOnRaw / 2) * CARDS_SPACEMENT);
            }
            else
            {
                x = countCardsToDisplay % 2 == 0 ? center - (countCardsToDisplay / 2) * CARDS_SPACEMENT : (center - (BASE_CARD_SIZE.Width / 2)) - ((countCardsToDisplay / 2) * CARDS_SPACEMENT);
            }

            return x;
        }

        public void DisplayCard(Card c, Point p, Size s)
        {
            //Console.WriteLine("Displaying card : " + c.Number + " | On position : " + p.X + " ; " + p.Y + " | With a size of : " + s.Width + " ; " + s.Height);

            PictureBox pb = new PictureBox()
            {
                Size = s,
                Location = p,
                BorderStyle = BorderStyle.None,
                BackgroundImage = c.GetPicture(),
                BackgroundImageLayout = ImageLayout.Zoom,
                Tag = c
            };
            this.tmpPB.Add(pb);
            this.Controls.Add(pb);
            pb.BringToFront();
            pb.Click += new EventHandler(card_Click);
        }

        public void UpdateMainStack(Card card_to_display)
        {
            this.pbMainStack.BackgroundImage = card_to_display.GetPicture();
        }

        private void card_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            Card c = pb.Tag as Card;

            this.Ctrl.PlayThisCard(c);
        }

        private void PbPicDeck_Click(object sender, EventArgs e)
        {
            this.Ctrl.PickACard(1);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ChangePlusLabel(int amount)
        {
            this.lblPlus.Text = "+" + amount.ToString();
        }

        public Color ShowColorChooser()
        {
            Color c = Color.White;
            ColorChooser cc = new ColorChooser();
            if (cc.ShowDialog() == DialogResult.OK)
            {
                string s = cc.Tag.ToString();

                switch (s)
                {
                    case "R":
                        c = Color.Red;
                        break;
                    case "G":
                        c = Color.Green;
                        break;
                    case "B":
                        c = Color.Blue;
                        break;
                    case "Y":
                        c = Color.Yellow;
                        break;
                    default:
                        c = Color.White;
                        break;
                }
            }

            return c;
        }

        public void ChangeChoosenColor(Color c)
        {
            if (c == null)
            {
                this.ChoosenColor.BackColor = this.BackColor;
            }
            else
            {
                this.ChoosenColor.BackColor = c;
            }
            
        }
    }
}
