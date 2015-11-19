using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(0.5f);
            circle.CalculateArea();
            Console.Write(circle.Area);
            Console.WriteLine();
           
            Circle other = new Circle(1.3f);
            circle += other;
            circle.CalculateArea();
            Console.WriteLine(circle.Area);
            circle -= other;
            circle.CalculateArea();
            Console.WriteLine(circle.Area);

            circle.Radius += 1.0f;
            circle.CalculateArea();
            Console.WriteLine(circle.Area);
            circle.Radius -= 1.0f;
            circle.CalculateArea();
            Console.WriteLine(circle.Area);

            Rectangle rec = new Rectangle(20, 10);
            rec.CalculateArea();
            Console.WriteLine(rec.Area);
            rec.CalculateCircumference();
            Console.WriteLine("Circumference:" + rec.Circumference);

            Triangle tri = new Triangle(20, 10);
            tri.CalculateArea();
            Console.WriteLine(tri.Area);




            Console.ReadLine();


        }
    }
}
