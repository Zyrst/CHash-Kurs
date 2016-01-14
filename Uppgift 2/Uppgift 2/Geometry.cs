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
        private float _circumference;   //Omkrets
        public float Area
        {
            get
            {
                //Doesn't have an _area yet so calculate one
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
                //No circumference so need to calculate one
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
        //Implemented in children
        public virtual void CalculateArea()
        {
        }
       
        public virtual void CalculateCircumference()
        {
        }
        //Return the type
        public Type getType()
        {
            return myType;
        }
    }
}
