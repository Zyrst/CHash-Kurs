using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Geometry
    {
        private float _area;
        private float _circumference;
        public float Area
        {
            get
            {
                return _area;
            }
            set
            {
                _area = value;
            }
        }

        public float Circumference
        {
            get
            {
                return _circumference;
            }
            set
            {
                _circumference = value;
            }
        }
        public virtual void CalculateArea()
        {
        }
       
        public virtual void CalculateCircumference()
        {
        }
    }
}
