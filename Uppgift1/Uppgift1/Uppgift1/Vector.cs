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

        //Property for x component
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
        //Y component
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
        //Create a new vector with x and y parameters
        public static Vector createVector(float x, float y)
        {
            Vector v = new Vector();
            v.X = x;
            v.Y = y;
            return v;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return createVector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return createVector(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static float operator *(Vector v1, Vector v2)
        {
            return (v1.X * v2.X) + (v1.Y * v2.Y);
        }

        public static Vector operator *(Vector v, float val)
        {
            v.X *= val;
            v.Y *= val;
            return v;
        }

       public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;           
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return v1.X != v2.X && v1.Y != v2.Y;    
        }

    }
}
