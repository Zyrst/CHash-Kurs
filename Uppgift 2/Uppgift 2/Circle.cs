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
            myType = Type.Circle;
        }

        public Circle(float radius)
        {
            _radius = radius;
            myType = Type.Circle;
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
