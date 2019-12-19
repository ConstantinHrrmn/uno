using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uno_game
{
    public class Player
    {
        private string _name;
        private List<Card> _cards;
        private string _iP;

        public Player(string a_name, string ip)
        {
            this.Name = a_name;
            this.IP = ip;
            this.Cards = new List<Card>();
        }

        public Player()
        {

        }

        public string Name { get => _name; set => _name = value; }
        public string IP { get => _iP; set => _iP = value; }
        public List<Card> Cards { get => _cards; set => _cards = value; }

        public override string ToString()
        {
            string returnString = "";
            returnString += this.Name + " | CARDS : ";

            foreach (Card card in this.Cards)
            {
                returnString += card.Number + " ";
            }

            return returnString;
        }
    }
}
