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
            Vector m;
            m = Vector.createVector(10, 10);
            Vector x = Vector.createVector(15, 20);

            Vector y = m + x;
            float z = y * m;

            Console.Write(y.mX);
            Console.WriteLine();

            Console.Write(m.mY);
            Console.WriteLine();

            Console.Write(z);
            Console.WriteLine();

            Console.WriteLine();
            Console.Write(VectorMath.Angle(m, y));

            Console.Write(VectorMath.Length(m));

            m = VectorMath.Normalize(m);
            Console.WriteLine();
            Console.Write(m.mX);

            Vector n = Vector.createVector(20, 20);
            Console.WriteLine();
            Console.Write(VectorMath.Distance(x, n));

            Vector f = n;
            Console.WriteLine();
            Console.Write(n != y);
            Console.WriteLine();
            Console.Write(f == n);

            Console.ReadLine();

            
        }
    }
}
