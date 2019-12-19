using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace uno_game
{
    public class Card
    {
        private string _imageName;
        private int _number;
        private Color _color;



        public Card(string a_image, int a_number, Color a_color)
        {
            this.ImageName = a_image;
            this.Number = a_number;
            this.Color = a_color;
        }

        public Card()
        {

        }

        public override string ToString()
        {
            return this.Number.ToString();
        }

        public int Number { get => _number; set => _number = value; }

        [XmlIgnore]
        public Color Color { get => _color; set => _color = value; }

        public string ImageName { get => _imageName; set => _imageName = value; }

        [XmlElement("Color")]
        public string htmlColor
        {
            get => ColorTranslator.ToHtml(this.Color);
            set => this.Color = ColorTranslator.FromHtml(value);
        }

        public Image GetPicture()
        {
            return (Image)Properties.Resources.ResourceManager.GetObject(this.ImageName);
            //return this.Photo;
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
