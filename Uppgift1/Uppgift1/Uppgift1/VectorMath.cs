using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1
{
    class VectorMath
    {
        public static double Angle(Vector v1, Vector v2)
        {

            return Math.Atan2(v2.mY - v1.mY, v2.mX - v1.mX);
        }

        public static float Length(Vector x)
        {
            return (float)Math.Sqrt((x.mX * x.mX) + (x.mY * x.mY));
        }

        public static Vector Normalize(Vector x)
        {
            float l = Length(x);
            x.mX = x.mX / l;
            x.mY = x.mY / l;
            return x;
        }

        public static float Distance(Vector v1 , Vector v2)
        {
            return (float)Math.Sqrt(Math.Pow(v2.mX - v1.mX, 2) + Math.Pow(v2.mY - v1.mY, 2));
        }

    }
}
