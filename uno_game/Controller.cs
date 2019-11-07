using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uno_game
{
    public class Controller
    {
        private List<Card> _deck;
        private List<Player> _players;
        private List<Card> _stack;
        private GameFrame _gF;

        private int plusToGiveToNextPlayer = 0;

        const int CARDS_TO_GIVE_AT_BEGINNING = 7;

        private Player _actualPlayer;

        public Controller(GameFrame a_gf)
        {
            this.Deck = CardCreator.CreateAllCard();
            this.Deck = CardCreator.ShuffleList(this.Deck);

            this.Stack = new List<Card>();
            this.Players = new List<Player>();

            this.GF = a_gf;
        }

        /// <summary>
        /// Creates the Players with the list of the names
        /// </summary>
        /// <param name="players">the names list</param>
        public void CreatePlayers(List<string> players)
        {
            this.CreatePlayer(players[0]);

            for (int i = 1; i < players.Count; i++)
            {
                this.CreateIA(players[i]);
            }

            if (this.Players.Count > 0)
                this.ActualPlayer = this.Players[0];
        }

        /// <summary>
        /// Creates the player
        /// </summary>
        /// <param name="name">the name of the player</param>
        public void CreatePlayer(string name)
        {
            Player p = new Player(name);
            this.GiveCardsToPlayer(CARDS_TO_GIVE_AT_BEGINNING, p);
            this.Players.Add(p);
        }

        /// <summary>
        /// Creates an IA
        /// </summary>
        /// <param name="name">The name of the IA</param>
        public void CreateIA(string name)
        {
            IA Ia = new IA(name);
            this.GiveCardsToPlayer(CARDS_TO_GIVE_AT_BEGINNING, Ia);
            this.Players.Add(Ia);
        }

        /// <summary>
        /// Gives cards to the player
        /// </summary>
        /// <param name="amount">The amount of cards we need to give him</param>
        /// <param name="p">The player who we need to give the cards</param>
        public void GiveCardsToPlayer(int amount, Player p)
        {
            for (int i = 0; i < amount; i++)
            {
                p.Cards.Add(this.Deck.Last());

                //We remove te card from the remaining deck
                this.Deck.Remove(this.Deck.Last());
            }
        }

        /// <summary>
        /// Debugging function to display all players
        /// </summary>
        /// <returns>A string width all the players</returns>
        public string ShowPlayers()
        {
            string str = "";
            foreach (Player item in this.Players)
            {
                str += item.ToString() + Environment.NewLine;
            }
            return str;
        }

        /// <summary>
        /// Put the first card of the game into the main deck
        /// </summary>
        public void PutFirstCard()
        {
            Card c = this.Deck.Last();
            bool rechercher = true;
            int index = 0;

            // We check if the card is a special card
            while (rechercher)
            {
                c = this.Deck[index];
                rechercher = (c.isChangementCouleur() || c.isChangementSens() || c.isPlus2() || c.isPlus4() || c.isSauterTour());
                index++;
            }
           

            this.Stack.Add(c);
            this.Deck.Remove(c);

            // Updating the view
            this.GF.UpdateMainStack(this.Stack.Last());
        }

        // Displaying the actual player
        public void DisplayPlayer()
        {
            this.GF.DisplayPlayer(this.ActualPlayer);
        }

        public void PickACard()
        {
            if (this.plusToGiveToNextPlayer == 0)
            {
                this.GiveCardsToPlayer(1, this.ActualPlayer);
            }
            else
            {
                this.GiveCardsToPlayer(plusToGiveToNextPlayer, this.ActualPlayer);
                this.plusToGiveToNextPlayer = 0;
                this.GF.ChangePlusLabel(plusToGiveToNextPlayer.ToString());
            }
            
            if (this.ActualPlayer.Cards.Count > 22)
            {
                if (this.ActualPlayer is IA)
                {
                    NextPlayer();
                }
                else
                {
                    this.GF.ShowMessage("Vous avez trop de cartes. Vous ne pouvez plus en piocher");
                }
                
            }
            else
            {
                if (this.ActualPlayer is IA)
                {

                }
                else
                {
                    this.GF.DisplayPlayer(this.ActualPlayer);
                }
                
            }
            
        }

        public void PlayACard(Card c)
        {
            if (unoRules.isMovePossible(this.Stack.Last(), c))
            {
                this.Stack.Add(c);
                this.GF.UpdateMainStack(this.Stack.Last());

                this.SpecialCardAction(c);

                this.ActualPlayer.Cards.Remove(c);
                this.GF.DisplayPlayer(this.ActualPlayer);
            }
            else
            {
                this.GF.ShowMessage("You can't play this card");
            }
        }

        public void SpecialCardAction(Card c)
        {
            if (c.isChangementCouleur())
            {
                c.Color = this.GF.ShowColorChooser();
            }
            else if(c.isChangementSens())
            {
                this.Players.Reverse();
            }
            else if (c.isPlus2())
            {
                plusToGiveToNextPlayer += 2;
                this.GF.ChangePlusLabel("+" + plusToGiveToNextPlayer); 
            }
            else if (c.isPlus4())
            {
                plusToGiveToNextPlayer += 4;
                this.GF.ChangePlusLabel("+" + plusToGiveToNextPlayer);
                c.Color = this.GF.ShowColorChooser();
            }
            else if (c.isSauterTour())
            {

            }
        }

        public void NextPlayer()
        {
            int index = this.Players.IndexOf(this.ActualPlayer);
            index++;

            if (index >= this.Players.Count)
                index = 0;

            this.ActualPlayer = this.Players[index];
        }

        internal List<Card> Deck { get => _deck; set => _deck = value; }
        internal List<Player> Players { get => _players; set => _players = value; }
        public List<Card> Stack { get => _stack; set => _stack = value; }
        public GameFrame GF { get => _gF; set => _gF = value; }
        public Player ActualPlayer { get => _actualPlayer; set => _actualPlayer = value; }
    }
}
 