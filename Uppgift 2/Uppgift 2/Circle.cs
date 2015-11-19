using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Circle : Geometry
    {
        public Circle()
        {
            Radius = 0f;
        }

        public Circle(float radius)
        {
            _radius = radius;
        }
        private float _radius;
        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public static Circle operator+(Circle circle1, Circle circle2)
        {
            circle1._radius += circle2._radius;
            return circle1;
        }

        public static Circle operator-(Circle circle1, Circle circle2)
        {
            circle1._radius -= circle2.Radius;
            return circle1;
        }

        public override void CalculateArea()
        {
            Area = (float)Math.PI * (Radius * Radius);
        }

        public override void CalculateCircumference()
        {
            Circumference = (float)(2 * Math.PI) * Radius;
        }
    }
}
