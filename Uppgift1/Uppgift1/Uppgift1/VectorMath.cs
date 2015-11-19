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

            float dot = v1 * v2;
            float cross = (v1.X * v2.Y) - (v1.Y * v2.X);
            return Math.Atan2(cross, dot) * 180 / Math.PI;
            //return Math.Atan2(v2.Y, v2.X) - Math.Atan2(v1.Y, v1.X) * 180 / Math.PI;
        }

        public static float Length(Vector v)
        {
            return (float)Math.Sqrt((v.X * v.X) + (v.Y * v.Y));
        }

        public static Vector Normalize(Vector v)
        {
            float l = Length(v);
            v.X = v.X / l;
            v.Y = v.Y / l;
            return v;
        }

        public static float Distance(Vector v1 , Vector v2)
        {
            return (float)Math.Sqrt(Math.Pow(v2.X - v1.X, 2) + Math.Pow(v2.Y - v1.Y, 2));
        }

    }
}
