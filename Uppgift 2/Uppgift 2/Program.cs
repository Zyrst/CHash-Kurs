﻿using System;
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
            List<Geometry> _shapes = new List<Geometry>();
            bool quit = false;

            while(!quit)
            {
                Console.Write("What do you want to do? Input by pressing numbers"); Console.WriteLine();
                Console.WriteLine("1. Add Geometry. 2.Modify Shape. 3.Information about Geometry. 4.Quit");
                ConsoleKeyInfo key = Console.ReadKey();
                switch(key.Key)
                {
                    case ConsoleKey.D1 :
                        Console.WriteLine("  What shape do you want to add?");
                        Console.WriteLine("1.Circle, 2.Rectangle, 3.Triangle");
                        key = Console.ReadKey();
                        switch(key.Key)
                        {
                            case ConsoleKey.D1:
                                Console.WriteLine("  Radius on Circle?");
                                string input = Console.ReadLine();
                                try
                                {
                                    float radius = float.Parse(input);
                                    Circle circle = new Circle(radius);
                                    _shapes.Add(circle);
                                    
                                }
                                catch(FormatException)
                                {
                                    Console.WriteLine("Not a number");
                                }
                                
                                
                                break;
                            case ConsoleKey.D2:
                                Console.WriteLine(" Width? ");
                                input = Console.ReadLine();
                                try
                                {
                                    float width = float.Parse(input);
                                    Rectangle rect = new Rectangle();
                                    rect.Width = width;

                                    Console.WriteLine("Height? ");
                                    input = Console.ReadLine();
                                    try
                                    {
                                        float height = float.Parse(input);
                                        rect.Height = height;
                                        _shapes.Add(rect);
                                    }
                                    catch(FormatException)
                                    {
                                        Console.WriteLine("Not a number");
                                    }
                                }
                                catch(FormatException)
                                {
                                    Console.WriteLine("Not a number");
                                }
                                break;
                            case ConsoleKey.D3:
                                Console.WriteLine("Base width? ");
                                input = Console.ReadLine();
                                try
                                {
                                    float baseWidth = float.Parse(input);
                                    Triangle tri = new Triangle();
                                    tri.Base = baseWidth;
                                    Console.WriteLine("Length of sides? ");
                                    input = Console.ReadLine();
                                    try
                                    {
                                        float sides = float.Parse(input);
                                        tri.Sides = sides;

                                        _shapes.Add(tri);
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Not a number");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Not a number");
                                }
                                break;
                            default:
                                Console.WriteLine("Not an option");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                        }
                        break;
                    case ConsoleKey.D2 :
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Not an options , pick something else");
                        break;
                }
               
            }
            

            //Circle circle = new Circle(0.5f);
            //circle.CalculateArea();
            //Console.Write(circle.Area);
            //Console.WriteLine();
           
            //Circle other = new Circle(1.3f);
            //circle += other;
            //circle.CalculateArea();
            //Console.WriteLine(circle.Area);
            //circle -= other;
            //circle.CalculateArea();
            //Console.WriteLine(circle.Area);

            //circle.Radius += 1.0f;
            //circle.CalculateArea();
            //Console.WriteLine(circle.Area);
            //circle.Radius -= 1.0f;
            //circle.CalculateArea();
            //Console.WriteLine(circle.Area);

            //Rectangle rec = new Rectangle(20, 10);
            //rec.CalculateArea();
            //Console.WriteLine(rec.Area);
            //rec.CalculateCircumference();
            //Console.WriteLine("Circumference:" + rec.Circumference);

            //Triangle tri = new Triangle(20, 10);
            //tri.CalculateArea();
            //Console.WriteLine(tri.Area);




            Console.ReadLine();


        }
    }
}
