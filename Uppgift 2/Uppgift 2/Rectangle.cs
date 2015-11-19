using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
   
    class Rectangle : Geometry
    {
        private float _width;
        private float _height;
     

        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public Rectangle()
        {
            _width = _height = 0;
        }

        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public override void CalculateArea()
        {
            Area = Width * Height;
        }

        public override void CalculateCircumference()
        {
            Circumference = (2 * Width) + (2 * Height);
        }
    }
}
