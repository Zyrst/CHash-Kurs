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
            Vector m = Vector.createVector(10, 10) + Vector.createVector(15, 20);

            Console.Write(m.mX);
            Console.WriteLine();
            Console.Write(m.mY);

            Console.ReadLine();
        }
    }
}
