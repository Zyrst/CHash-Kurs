using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Geometry
    {
        public enum Type {Triangle, Circle, Rectangle };
        protected Type myType;

        private float _area;
        private float _circumference;
        public float Area
        {
            get
            {
                if(_area == 0)
                {
                    CalculateArea();
                    return _area;
                }
                else 
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
                if(_circumference == 0)
                {
                    CalculateCircumference();
                    return _circumference;
                }
                else 
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

        public Type getType()
        {
            return myType;
        }
    }
}
