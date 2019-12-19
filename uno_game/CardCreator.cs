using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uno_game
{
    public class CardCreator
    {
        public static List<Card> CreateAllCard()
        {
            List<Card> cards = new List<Card>();
            Color BlueColor = Color.Blue;
            Color RedColor = Color.Red;
            Color GreenColor = Color.Green;
            Color YellowColor = Color.Yellow;

            // 0
            cards.Add(new Card("blue_0_large", 0, BlueColor));
            cards.Add(new Card("red_0_large", 0, RedColor));
            cards.Add(new Card("green_0_large", 0, GreenColor));
            cards.Add(new Card("yellow_0_large", 0, YellowColor));

            // 1
            cards.Add(new Card("blue_1_large", 1, BlueColor));
            cards.Add(new Card("red_1_large", 1, RedColor));
            cards.Add(new Card("green_1_large", 1, GreenColor));
            cards.Add(new Card("yellow_1_large", 1, YellowColor));
            cards.Add(new Card("blue_1_large", 1, BlueColor));
            cards.Add(new Card("red_1_large", 1, RedColor));
            cards.Add(new Card("green_1_large", 1, GreenColor));
            cards.Add(new Card("yellow_1_large", 1, YellowColor));

            // 2
            cards.Add(new Card("blue_2_large", 2, BlueColor));
            cards.Add(new Card("red_2_large", 2, RedColor));
            cards.Add(new Card("green_2_large", 2, GreenColor));
            cards.Add(new Card("yellow_2_large", 2, YellowColor));
            cards.Add(new Card("blue_2_large", 2, BlueColor));
            cards.Add(new Card("red_2_large", 2, RedColor));
            cards.Add(new Card("green_2_large", 2, GreenColor));
            cards.Add(new Card("yellow_2_large", 2, YellowColor));

            // 3
            cards.Add(new Card("blue_3_large", 3, BlueColor));
            cards.Add(new Card("red_3_large", 3, RedColor));
            cards.Add(new Card("green_3_large", 3, GreenColor));
            cards.Add(new Card("yellow_3_large", 3, YellowColor));
            cards.Add(new Card("blue_3_large", 3, BlueColor));
            cards.Add(new Card("red_3_large", 3, RedColor));
            cards.Add(new Card("green_3_large", 3, GreenColor));
            cards.Add(new Card("yellow_3_large", 3, YellowColor));

            // 4
            cards.Add(new Card("blue_4_large", 4, BlueColor));
            cards.Add(new Card("red_4_large", 4, RedColor));
            cards.Add(new Card("green_4_large", 4, GreenColor));
            cards.Add(new Card("yellow_4_large", 4, YellowColor));
            cards.Add(new Card("blue_4_large", 4, BlueColor));
            cards.Add(new Card("red_4_large", 4, RedColor));
            cards.Add(new Card("green_4_large", 4, GreenColor));
            cards.Add(new Card("yellow_4_large", 4, YellowColor));

            // 5
            cards.Add(new Card("blue_5_large", 5, BlueColor));
            cards.Add(new Card("red_5_large", 5, RedColor));
            cards.Add(new Card("green_5_large", 5, GreenColor));
            cards.Add(new Card("yellow_5_large", 5, YellowColor));
            cards.Add(new Card("blue_5_large", 5, BlueColor));
            cards.Add(new Card("red_5_large", 5, RedColor));
            cards.Add(new Card("green_5_large", 5, GreenColor));
            cards.Add(new Card("yellow_5_large", 5, YellowColor));

            // 6
            cards.Add(new Card("blue_6_large", 6, BlueColor));
            cards.Add(new Card("red_6_large", 6, RedColor));
            cards.Add(new Card("green_6_large", 6, GreenColor));
            cards.Add(new Card("yellow_6_large", 6, YellowColor));
            cards.Add(new Card("blue_6_large", 6, BlueColor));
            cards.Add(new Card("red_6_large", 6, RedColor));
            cards.Add(new Card("green_6_large", 6, GreenColor));
            cards.Add(new Card("yellow_6_large", 6, YellowColor));

            // 7
            cards.Add(new Card("blue_7_large", 7, BlueColor));
            cards.Add(new Card("red_7_large", 7, RedColor));
            cards.Add(new Card("green_7_large", 7, GreenColor));
            cards.Add(new Card("yellow_7_large", 7, YellowColor));
            cards.Add(new Card("blue_7_large", 7, BlueColor));
            cards.Add(new Card("red_7_large", 7, RedColor));
            cards.Add(new Card("green_7_large", 7, GreenColor));
            cards.Add(new Card("yellow_7_large", 7, YellowColor));

            // 8
            cards.Add(new Card("blue_8_large", 8, BlueColor));
            cards.Add(new Card("red_8_large", 8, RedColor));
            cards.Add(new Card("green_8_large", 8, GreenColor));
            cards.Add(new Card("yellow_8_large", 8, YellowColor));
            cards.Add(new Card("blue_8_large", 8, BlueColor));
            cards.Add(new Card("red_8_large", 8, RedColor));
            cards.Add(new Card("green_8_large", 8, GreenColor));
            cards.Add(new Card("yellow_8_large", 8, YellowColor));

            // 9
            cards.Add(new Card("blue_9_large", 9, BlueColor));
            cards.Add(new Card("red_9_large", 9, RedColor));
            cards.Add(new Card("green_9_large", 9, GreenColor));
            cards.Add(new Card("yellow_9_large", 9, YellowColor));
            cards.Add(new Card("blue_9_large", 9, BlueColor));
            cards.Add(new Card("red_9_large", 9, RedColor));
            cards.Add(new Card("green_9_large", 9, GreenColor));
            cards.Add(new Card("yellow_9_large", 9, YellowColor));

            // +2
            cards.Add(new Card("yellow_picker_large", -1, YellowColor));
            cards.Add(new Card("yellow_picker_large", -1, YellowColor));
            cards.Add(new Card("green_picker_large", -1, GreenColor));
            cards.Add(new Card("green_picker_large", -1, GreenColor));
            cards.Add(new Card("blue_picker_large", -1, BlueColor));
            cards.Add(new Card("blue_picker_large", -1, BlueColor));
            cards.Add(new Card("red_picker_large", -1, RedColor));
            cards.Add(new Card("red_picker_large", -1, RedColor));

            // +4
            for (int i = 0; i < 4; i++)
            {
                cards.Add(new Card("wild_pick_four_large", -2, Color.White));
            }

            // changement de sens
            cards.Add(new Card("yellow_reverse_large", -3, YellowColor));
            cards.Add(new Card("yellow_reverse_large", -3, YellowColor));
            cards.Add(new Card("green_reverse_large", -3, GreenColor));
            cards.Add(new Card("green_reverse_large", -3, GreenColor));
            cards.Add(new Card("blue_reverse_large", -3, BlueColor));
            cards.Add(new Card("blue_reverse_large", -3, BlueColor));
            cards.Add(new Card("red_reverse_large", -3, RedColor));
            cards.Add(new Card("red_reverse_large", -3, RedColor));

            // sauter un tour
            cards.Add(new Card("yellow_skip_large", -4, YellowColor));
            cards.Add(new Card("yellow_skip_large", -4, YellowColor));
            cards.Add(new Card("green_skip_large", -4, GreenColor));
            cards.Add(new Card("green_skip_large", -4, GreenColor));
            cards.Add(new Card("blue_skip_large", -4, BlueColor));
            cards.Add(new Card("blue_skip_large", -4, BlueColor));
            cards.Add(new Card("red_skip_large", -4, RedColor));
            cards.Add(new Card("red_skip_large", -4, RedColor));

            // Couleur au choix
            for (int i = 0; i < 4; i++)
            {
                cards.Add(new Card("wild_colora_changer_large", -5, Color.White));
            }

            return cards;
        }

        public static List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
    }
}
