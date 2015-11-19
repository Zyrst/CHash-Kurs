using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1
{
    
    public struct Vector
    {
        private float mX;
        private float mY;

        public float X 
        {
            get
            {
                return mX;
            }
            set
            {
                mX = value;
            }
        }

        public float Y
        {
            get
            {
                return mY;
            }
            set
            {
                mY = value;
            }
        }

        public static Vector createVector(float x, float y)
        {
            Vector v = new Vector();
            v.mX = x;
            v.mY = y;
            return v;
        }
        
       public static Vector operator +(Vector v1, Vector v2)
       {
            Vector v = new Vector();
            v.mX = v1.mX + v2.mX;
            v.mY = v1.mY + v2.mY;
            return v;
       }
       
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector v = new Vector();
            v.mX = v1.mX - v2.mX;
            v.mY = v1.mY - v2.mY;
            return v;
        }

        public static float operator *(Vector v1, Vector v2)
        {
            
            return (v1.mX * v2.mX) + (v1.mY * v2.mY);
        }

        public static Vector operator *(Vector v, float val)
        {
            v.mX *= val;
            v.mY *= val;
            return v;
        }

       public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.mX == v2.mX && v1.mY == v2.mY;           
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return v1.mX != v2.mX && v1.mY != v2.mY;    
        }

    }
}
