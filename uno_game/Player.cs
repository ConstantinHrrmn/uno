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

        public Player(string a_name)
        {
            this.Name = a_name;
            this.Cards = new List<Card>();
        }

        public string Name { get => _name; set => _name = value; }
        internal List<Card> Cards { get => _cards; set => _cards = value; }

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
