using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uno_game
{
    public class Card
    {
        private Image _photo;
        private int _number;
        private Color _color;

        public Card(Image a_image, int a_number, Color a_color)
        {
            this.Photo = a_image;
            this.Number = a_number;
            this.Color = a_color;
        }

        public override string ToString()
        {
            return this.Number.ToString();
        }

        public Image Photo { get => _photo; set => _photo = value; }
        public int Number { get => _number; set => _number = value; }
        public Color Color { get => _color; set => _color = value; }

        public Image GetPicture()
        {
            return this.Photo;
        }

        public bool isPlus2()
        {
            return this.Number == -1;
        }

        public bool isPlus4()
        {
            return this.Number == -2;
        }

        public bool isChangementSens()
        {
            return this.Number == -3;
        }

        public bool isSauterTour()
        {
            return this.Number == -4;
        }

        public bool isChangementCouleur()
        {
            return this.Number == -5;
        }

        public int getValue()
        {
            return this.Number >= 0 ? this.Number : -10;
        }
    }
}
