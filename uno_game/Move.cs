using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uno_game
{
    class Move
    {
        private Card _deckCard;
        private Card _playCard;
        private bool _usefull;

        public Move()
        {
            this.DeckCard = null;
            this.PlayCard = null;
        }

        public Card DeckCard { get => _deckCard; set => _deckCard = value; }
        public Card PlayCard { get => _playCard; set => _playCard = value; }
        public bool Usefull { get => _usefull; set => _usefull = value; }

        public void SaveMove()
        {
            if (this.DeckCard != null && this.PlayCard != null)
            {
                IAController.CreateMove(this.DeckCard, this.PlayCard, this.Usefull);
            } 
        }

        public override string ToString()
        {
            return string.Format("DC : {0} | PC : {1} | USEFULL : {2}", this.DeckCard.ToString(), this.PlayCard.ToString(), this.Usefull.ToString());
        }
    }
}
