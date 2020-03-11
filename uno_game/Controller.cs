using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        /// <summary>
        /// Controller's constructor
        /// </summary>
        /// <param name="a_gf">the frame for the game</param>
        public Controller(GameFrame a_gf)
        {
            this.Deck = CardCreator.CreateAllCard();
            this.Deck = CardCreator.ShuffleList(this.Deck);

            this.Stack = new List<Card>();
            this.Players = new List<Player>();

            this.GF = a_gf;
        }

        public Controller()
        {

        }

        #region PLAYER MANAGEMENT

        /// <summary>
        /// Creating the players and the IA's
        /// </summary>
        /// <param name="IA_amount">The amount of IA to create</param>
        public void CreatePlayers(int players)
        {
            for (int i = 0; i < players; i++)
                this.Players.Add(new Player("Player " + i, "-"));

            // Make the real player as the first player
            this.ActualPlayer = this.Players.First();

            // Giving all the players the first cards to begin the game
            foreach (Player player in this.Players)
                this.GiveCardsToPlayer(CARDS_TO_GIVE_AT_BEGINNING, player);

            this.UpdateStatus();

            // Displaying the player on the game frame
            this.GF.ShowMessage("PLAYER (" + this.ActualPlayer.Name + ") STARTS");
            this.GF.DisplayPlayer(this.ActualPlayer);
        }

        /// <summary>
        /// Switches to the next player. At the same time it looks if the player have to get 4 card because of a +4
        /// </summary>
        public void NextPlayer()
        {
            this.UpdateStatus();
            int indexOfPlayer = this.Players.IndexOf(this.ActualPlayer);
            indexOfPlayer++;

            if (indexOfPlayer >= this.Players.Count)
                indexOfPlayer = 0;

            this.ActualPlayer = this.Players[indexOfPlayer];

            if (this.Stack.Last().isPlus4())
            {
                this.GiveCardsToPlayer(4, this.ActualPlayer);
                if (!CanIPlay())
                    this.NextPlayer();
            }
            else if (this.Stack.Last().isPlus2())
            {
                if (!this.CanIRepostPlus2())
                {
                    this.GiveCardsToPlayer(this.plusToGiveToNextPlayer, this.ActualPlayer);
                    this.plusToGiveToNextPlayer = 0;
                    this.GF.ChangePlusLabel(this.plusToGiveToNextPlayer);
                }
            }

            this.GF.DisplayClear();
            this.GF.ShowMessage("NEXT PLAYER ("+this.ActualPlayer.Name+")" );
            this.GF.DisplayPlayer(this.ActualPlayer);

            Console.WriteLine("NEXT PLAYER !");
        }

        /// <summary>
        /// Skips the next player
        /// </summary>
        private void SkipPlayer()
        {
            int indexOfPlayer = this.Players.IndexOf(this.ActualPlayer);
            indexOfPlayer++;

            if (indexOfPlayer >= this.Players.Count)
                indexOfPlayer = 0;

            this.ActualPlayer = this.Players[indexOfPlayer];
            this.NextPlayer();
        }

        private void UpdateStatus()
        {
            string status = "";
            foreach (Player player in this.Players)
            {
                string txt = "";
                if (player.Cards.Count == 1)
                {
                    txt = "UNO";
                }
                else
                {
                    txt = player.Cards.Count.ToString();
                }
                status += player.Name + " : " + txt + "\n";
            }
            this.GF.UpdateStatus(status);
        }

        #endregion

        #region CARDS MANAGEMENT

        /// <summary>
        /// Give an amount of card to a certain player
        /// </summary>
        /// <param name="amountOfCardToGive">The amount of cards to give to a player</param>
        /// <param name="player">The player who we give the cards</param>
        public void GiveCardsToPlayer(int amountOfCardToGive, Player player)
        {
            for (int i = 0; i < amountOfCardToGive; i++)
            {
                // we give to the player the last card
                player.Cards.Add(this.Deck.Last());

                // And we remove the last crad from the Deck
                this.Deck.Remove(this.Deck.Last());
            }
        }

        /// <summary>
        /// Put the first card of the game on the playing stack.
        /// It verify if the card is special. If it is, it will pick another one and put the special card back in the deck.
        /// </summary>
        public void PutFirstCardOnStack()
        {
            Card selectedCard = this.Deck.Last();
            int index = 1;

            while (this.IsTheCardSpecial(selectedCard))
                selectedCard = this.Deck[index];

            this.Stack.Add(selectedCard);
            this.Deck.Remove(selectedCard);

            this.GF.UpdateMainStack(this.Stack.Last());
        }

        /// <summary>
        /// Check if the card is Special (+2, +4, etc.)
        /// </summary>
        /// <param name="cardToVerify">The card to verify</param>
        /// <returns></returns>
        private bool IsTheCardSpecial(Card cardToVerify)
        {
            return cardToVerify.isChangementCouleur() || cardToVerify.isChangementSens() || cardToVerify.isPlus2() || cardToVerify.isPlus4() || cardToVerify.isSauterTour();
        }

        /// <summary>
        /// Play the card that the player is selecting
        /// </summary>
        /// <param name="cardToPlay">The card to play</param>
        public void PlayThisCard(Card cardToPlay)
        {
            if (unoRules.isMovePossible(this.Stack.Last(), cardToPlay))
            {
                this.GF.ChangeChoosenColor(Color.Teal);

                this.Stack.Add(cardToPlay);
                this.ActualPlayer.Cards.Remove(cardToPlay);

                this.UpdateStatus();

                if (this.CheckIfWin(this.ActualPlayer)){
                    this.GF.ShowWinner(this.ActualPlayer);
                    return;
                }

                this.GF.UpdateMainStack(this.Stack.Last());
                this.GF.DisplayPlayer(this.ActualPlayer);

                if (this.IsTheCardSpecial(cardToPlay))
                    this.ManageSpecialCard();

                

                if (cardToPlay.isSauterTour())
                    this.SkipPlayer();
                else
                    this.NextPlayer();
            }
            else
                this.GF.ShowMessage("Vous ne pouvez pas jouer cette carte");
        }

        /// <summary>
        /// The player gets one or few additional card(s)
        /// </summary>
        /// <param name="amount"></param>
        public void PickACard(int amount)
        {
            if (this.ActualPlayer.Cards.Count < 22)
            {
                if (this.plusToGiveToNextPlayer > 0)
                {
                    this.GiveCardsToPlayer(this.plusToGiveToNextPlayer, this.ActualPlayer);
                    this.plusToGiveToNextPlayer = 0;
                    this.GF.ChangePlusLabel(this.plusToGiveToNextPlayer);
                }
                else
                {
                    this.GiveCardsToPlayer(amount, this.ActualPlayer);
                }

                this.GF.DisplayPlayer(this.ActualPlayer);
                if (!CanIPlay())
                {
                    this.NextPlayer();
                }
            }
            else
            {
                if (this.ActualPlayer.Name == "Player")
                {
                    this.GF.ShowMessage("Vous ne pouvez pas tirer plus de cartes...");
                }
            }
        }

        /// <summary>
        /// Gère les cartes spéciales
        /// </summary>
        public void ManageSpecialCard()
        {
            if (this.Stack.Last().isChangementCouleur())
            {
                this.Stack.Last().Color = this.GF.ShowColorChooser();
                this.GF.ChangeChoosenColor(this.Stack.Last().Color);

                Console.WriteLine("Color chossen : " + this.Stack.Last().Color.ToString());
            }
            else if (this.Stack.Last().isChangementSens())
            {
                this.Players.Reverse();
                Console.WriteLine("Changement de sens");
            }
            else if (this.Stack.Last().isPlus2())
            {
                this.plusToGiveToNextPlayer += 2;
                this.GF.ChangePlusLabel(this.plusToGiveToNextPlayer);
            }
            else if (this.Stack.Last().isPlus4())
            {
                    this.Stack.Last().Color = this.GF.ShowColorChooser();
                    this.GF.ChangeChoosenColor(this.Stack.Last().Color);
            }
        }

        /// <summary>
        /// Verify if the player can repost to the +2, if not he needs to pick 2 cards
        /// </summary>
        /// <returns></returns>
        private bool CanIRepostPlus2()
        {
            bool returnvalue = false;
            foreach (Card card in this.ActualPlayer.Cards)
            {
                if (card.isPlus2())
                {
                    returnvalue = true;
                }
            }
            return returnvalue;
        }

        /// <summary>
        /// Verify if the player can play or of he need to pick a card
        /// </summary>
        /// <returns>true if he can play</returns>
        private bool CanIPlay()
        {
            bool canpPlay = false;

            foreach (Card card in this.ActualPlayer.Cards)
            {
                if (card.Number == this.Stack.Last().Number || card.Color == this.Stack.Last().Color)
                {
                    canpPlay = true;
                }
            }

            return canpPlay;
        }

        /// <summary>
        /// Checks if the player still has cards or not
        /// </summary>
        /// <param name="player">the player we want to check</param>
        /// <returns>true if win, false if not</returns>
        private bool CheckIfWin(Player player)
        {
            return player.Cards.Count == 0;
        }


        #endregion

        #region DEBUGGING

        /// <summary>
        /// Show in console the debuggin of all the players
        /// </summary>
        public void DebugPlayers()
        {
            foreach (Player item in this.Players)
                Console.WriteLine(item.ToString());
        }

        #endregion

        internal List<Card> Deck { get => _deck; set => _deck = value; }
        internal List<Player> Players { get => _players; set => _players = value; }
        public List<Card> Stack { get => _stack; set => _stack = value; }

        [XmlIgnore]
        public GameFrame GF { get => _gF; set => _gF = value; }

        public Player ActualPlayer { get => _actualPlayer; set => _actualPlayer = value; }
    }
}
