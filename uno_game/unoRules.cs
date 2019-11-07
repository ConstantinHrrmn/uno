using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uno_game
{
    class unoRules
    {
        public static bool isMovePossible(Card stackCard, Card playersCard)
        {
            return (stackCard.Color == playersCard.Color || stackCard.Number == playersCard.Number) ? true : (playersCard.Color == Color.White) ? true : false;
        }


    }
}
