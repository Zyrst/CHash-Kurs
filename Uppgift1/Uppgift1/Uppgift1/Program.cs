using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector m = Vector.createVector(10, 10);
            Vector x = Vector.createVector(15, 20);

            Vector y = m + x;
            float z = m * y;
            Vector scaled = x * 10f;
            Vector minus = scaled - y;

            Console.Write("BASIC ARITHMETIC"); Console.WriteLine();
            
            Console.Write("Addition: ");
            Console.Write("({0}, {1}) + ({2}, {3}) = ({4}, {5})", m.X, m.Y, x.X, x.Y, y.X, y.Y); Console.WriteLine();
          
            Console.Write("Subtraction: ");
            Console.Write("({0}, {1}) - ({2}, {3}) = ({4}, {5})", scaled.X, scaled.Y, y.X, y.Y, minus.X, minus.Y); Console.WriteLine();
            
            Console.Write("Scalarproduct: ");
            Console.Write("({0}, {1}) * ({2}, {3}) = {4}", m.X, m.Y, y.X, y.Y, z); Console.WriteLine();
            
            Console.Write("Scaling vector: ");
            Console.Write("({0}, {1}) * {2} = ({3}, {4})", x.X, x.Y, 10f, scaled.X, scaled.Y);
            Console.WriteLine(); Console.WriteLine();

            Console.Write("VECTOR OPERATIONS"); Console.WriteLine();

            Console.Write("Length of vector: ");
            Console.Write("Vector m: ({0}, {1}) : Length : {2}", m.X, m.Y, VectorMath.Length(m)); Console.WriteLine();
            
            Console.Write("Angle between two vectors: "); Console.WriteLine();
            Console.Write("Vec1:({0}, {1}), Vec2: ({2},{3}). Angle: {4}", m.X, m.Y, y.X, y.Y, VectorMath.Angle(m, y)); Console.WriteLine();
            
            y = VectorMath.Normalize(y);
            Console.Write("Normalize a vector: {0}, {1}", y.X, y.Y); Console.WriteLine();
           

            Vector n = Vector.createVector(20, 20f);
            Console.Write("Distance between two vectors: "); Console.WriteLine();
            Console.Write("Vec1: ({0}, {1}) Vec2: ({2}, {3}). Distance : {4} ", n.X, n.Y, x.X, x.Y, VectorMath.Distance(n , x));

            Console.WriteLine(); Console.WriteLine();
            Console.Write("BOOLEANS"); Console.WriteLine();
            
            Vector f = n;
            Console.Write("({0}, {1}) != ({2}, {3}) is {4}", n.X, n.Y, f.X, f.X, n != f); Console.WriteLine();
            Console.Write("({0}, {1}) == ({2}, {3}) is {4}", n.X, n.Y, f.X, f.X, n == f); Console.WriteLine();
            Console.Write("({0}, {1}) == ({2}, {3}) is {4}", n.X, n.Y, m.X, m.X, n == m); Console.WriteLine();
            
            Console.ReadLine();

            
        }
    }
}
