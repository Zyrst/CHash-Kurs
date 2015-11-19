using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Triangle : Geometry
    {
        private float _base;
        private float _sides;

        public float Base
        {
            get
            {
                return _base;
            }
            set
            {
                _base = value;
            }
        }
        public float Sides
        {
            get
            {
                return _sides;
            }
            set
            {
                _sides = value;
            }
        }
        public Triangle()
        {
            _base = 0.0f;
            _sides = 0.0f;
        }

        public Triangle(float bse, float sides)
        {
            Base = bse;
            Sides = sides;
        }

        public override void CalculateArea()
        {
            Area = (Base * Sides) / 2;
        }

        public override void CalculateCircumference()
        {
            Circumference = Base + (2 * Sides);
        }
    }
}
