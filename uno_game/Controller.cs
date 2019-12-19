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
        private Server _serv;

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
        public void CreatePlayers(int IA_amount)
        {
            // Creating the player
            this.Players.Add(new Player("Player", this.GetLocalIp()));

            // Creating all the IA's
            //for (int i = 0; i < IA_amount; i++)
            // this.Players.Add(new IA("IA " + i));

            // Make the real player as the first player
            this.ActualPlayer = this.Players.First();

            // Giving all the players the first cards to begin the game
            foreach (Player player in this.Players)
                this.GiveCardsToPlayer(CARDS_TO_GIVE_AT_BEGINNING, player);

            // Displaying the player on the game frame
            this.GF.DisplayPlayer(this.ActualPlayer);
        }

        public void CreatePlayer(string name, string ip)
        {
            Player p = new Player(name, ip);

            // Creating the player
            this.Players.Add(p);

            this.GiveCardsToPlayer(CARDS_TO_GIVE_AT_BEGINNING, p);
        }

        /// <summary>
        /// Switches to the next player. At the same time it looks if the player have to get 4 card because of a +4
        /// </summary>
        public void NextPlayer()
        {
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
                this.Stack.Add(cardToPlay);
                this.ActualPlayer.Cards.Remove(cardToPlay);

                this.GF.UpdateMainStack(this.Stack.Last());
                this.GF.DisplayPlayer(this.ActualPlayer);

                if (this.IsTheCardSpecial(cardToPlay))
                    this.ManageSpecialCard();

                if (cardToPlay.isSauterTour())
                    this.SkipPlayer();
                else
                    this.NextPlayer();

                this.GF.ChangeChoosenColor(Color.Teal);
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
                if (this.ActualPlayer.Name == "Player")
                {
                    this.Stack.Last().Color = this.GF.ShowColorChooser();
                    this.GF.ChangeChoosenColor(this.Stack.Last().Color);
                }

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
                if (this.ActualPlayer.Name == "Player")
                {
                    this.Stack.Last().Color = this.GF.ShowColorChooser();
                    this.GF.ChangeChoosenColor(this.Stack.Last().Color);
                }
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

        public int PlusToGiveToNextlayer()
        {
            return this.plusToGiveToNextPlayer;
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

        #region SERVER / CLIENT

        public void CreateServer()
        {
            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                this.Serv = new Server(this.GetLocalIp(), 13000, this);
            });
            t.Start();

            Console.WriteLine("Server Started...!");
        }

        public string GetLocalIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void SendMessage(String server, String message)
        {
            try
            {
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);

                NetworkStream stream = client.GetStream();


                // Translate the Message into ASCII.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        public void Connect(string ip, string name)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                SendMessage(ip, name);
            }).Start();
        }

        public string GetInfos(string server, string clientIp, string message)
        {
            try
            {
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();

                // Translate the Message into ASCII.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);

                // Bytes Array to receive Server Response.
                data = new Byte[1000];
                String response = String.Empty;
                // Read the Tcp Server Response Bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", response);

                stream.Close();
                client.Close();

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);

            }

            return "ERROR";
        }



        #endregion

        internal List<Card> Deck { get => _deck; set => _deck = value; }
        internal List<Player> Players { get => _players; set => _players = value; }
        public List<Card> Stack { get => _stack; set => _stack = value; }

        [XmlIgnore]
        public GameFrame GF { get => _gF; set => _gF = value; }

        public Player ActualPlayer { get => _actualPlayer; set => _actualPlayer = value; }
        internal Server Serv { get => _serv; set => _serv = value; }
    }
}
