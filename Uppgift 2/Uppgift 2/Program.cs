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
                                    Console.WriteLine("Added to index: " + (_shapes.Count - 1));
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
                                        Console.WriteLine("Added to index: " + (_shapes.Count - 1));
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
                                        Console.WriteLine("Added to index: " + (_shapes.Count - 1));
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
                        Console.WriteLine();
                        Console.WriteLine("Which shape do you want to modify? Select index");
                        string indexString = Console.ReadLine();
                        try
                        {
                            int indexModify = int.Parse(indexString);
                            Geometry g =_shapes[indexModify];
                            switch(g.getType())
                            {
                                case Geometry.Type.Circle:
                                    Circle c = (Circle)g;
                                    Console.WriteLine("What do you want to modify? 1.Radius");
                                    key = Console.ReadKey();
                                    if(key.Key == ConsoleKey.D1)
                                    {
                                        Console.WriteLine("By how much?");
                                        key = Console.ReadKey();
                                        try
                                        {
                                            if(key.Key == ConsoleKey.OemMinus)
                                            {
                                                string amount = Console.ReadLine();
                                                float amountF = float.Parse(amount);
                                                c.Radius -= amountF;
                                                Console.WriteLine("New radius: {0}", c.Radius);
                                            }
                                            else if(key.Key == ConsoleKey.OemPlus)
                                            {
                                                string amount = Console.ReadLine();
                                                float amountF = float.Parse(amount);
                                                c.Radius += amountF;
                                                Console.WriteLine("New radius: {0}", c.Radius);
                                            }
                                        }
                                        catch(System.FormatException)
                                        {
                                            Console.WriteLine("Not a number");
                                        }
                                    }
                                    break;
                                case Geometry.Type.Rectangle:
                                    Rectangle r = (Rectangle)g;
                                    Console.WriteLine("What to you want to modify? 1.Width, 2.Height");
                                    key = Console.ReadKey();
                                    switch(key.Key)
                                    {
                                        case ConsoleKey.D1:
                                            Console.WriteLine();
                                            Console.WriteLine("By how much?");
                                            key = Console.ReadKey();
                                            try
                                            {
                                                if(key.Key == ConsoleKey.OemMinus)
                                                {
                                                    string amount = Console.ReadLine();
                                                    float amountF = float.Parse(amount);
                                                    r.Width -= amountF;
                                                    Console.WriteLine("New Width: {0}", r.Width);
                                                }
                                                else if(key.Key == ConsoleKey.OemPlus)
                                                {
                                                    string amount = Console.ReadLine();
                                                    float amountF = float.Parse(amount);
                                                    r.Width += amountF;
                                                    Console.WriteLine("New Width: {0}", r.Width);
                                                }
                                            }
                                            catch(System.FormatException)
                                            {
                                                Console.WriteLine("Not a number");
                                            }
                                            break;
                                        case ConsoleKey.D2:
                                            Console.WriteLine();
                                            Console.WriteLine("By how much?");
                                            key = Console.ReadKey();
                                            try
                                            {
                                                if(key.Key == ConsoleKey.OemMinus)
                                                {
                                                    string amount = Console.ReadLine();
                                                    float amountF = float.Parse(amount);
                                                    r.Height -= amountF;
                                                    Console.WriteLine("New Width: {0}", r.Height);
                                                }
                                                else if(key.Key == ConsoleKey.OemPlus)
                                                {
                                                    string amount = Console.ReadLine();
                                                    float amountF = float.Parse(amount);
                                                    r.Height += amountF;
                                                    Console.WriteLine("New Width: {0}", r.Height);
                                                }
                                            }
                                            catch(System.FormatException)
                                            {
                                                Console.WriteLine("Not a number");
                                            }
                                            break;
                                        default:
                                           Console.WriteLine("Not an option");
                                            break;
                                    }
                                    break;
                                case Geometry.Type.Triangle:
                                    Triangle t = (Triangle)g;
                                    Console.WriteLine("What do you want to modify? 1.Base Width, 2.Side widths");
                                    key = Console.ReadKey();
                                    switch(key.Key)
                                    {
                                        case ConsoleKey.D1:
                                            Console.WriteLine("By how much?");
                                            key = Console.ReadKey();
                                            if(key.Key == ConsoleKey.OemMinus)
                                            {
                                                string amount = Console.ReadLine();
                                                float amountF = float.Parse(amount);
                                                t.Base -= amountF;
                                                Console.WriteLine("New Base Width: {0}", t.Base);
                                            }
                                            else if(key.Key == ConsoleKey.OemPlus)
                                            {
                                                string amount = Console.ReadLine();
                                                float amountF = float.Parse(amount);
                                                t.Base += amountF;
                                                Console.WriteLine("New Base Width: {0}", t.Base);
                                            }
                                            break;
                                        case ConsoleKey.D2:
                                            Console.WriteLine("By how much?");
                                            key = Console.ReadKey();
                                            if(key.Key == ConsoleKey.OemMinus)
                                            {
                                                string amount = Console.ReadLine();
                                                float amountF = float.Parse(amount);
                                                t.Sides -= amountF;
                                                Console.WriteLine("New Side Length: {0}", t.Sides);
                                            }
                                            else if(key.Key == ConsoleKey.OemPlus)
                                            {
                                                string amount = Console.ReadLine();
                                                float amountF = float.Parse(amount);
                                                t.Sides += amountF;
                                                Console.WriteLine("New Side Length: {0}", t.Sides);
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Not an option");
                                            break;
                                    }
                                    break;
                            }
                        }
                        catch(System.FormatException)
                        {
                            Console.WriteLine("Not a number");
                        }
                        catch(System.ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Out of bounds");
                        }


                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Which shape do you want information about? Enter index number start from 0");
                        string input1 = Console.ReadLine();
                        int index = int.Parse(input1);
                        try
                        {
                            Geometry g = _shapes[index];
                            switch (g.getType())
                            {
                                case Geometry.Type.Circle:
                                    bool repeat = true;
                                    while (repeat)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Information about Circle: 1.Radius, 2.Area, 3.Circumference, 4.Return");
                                        key = Console.ReadKey();
                                        Circle c = (Circle)g;
                                        switch (key.Key)
                                        {
                                            case ConsoleKey.D1:
                                                Console.WriteLine("Radius: " + c.Radius);
                                                break;
                                            case ConsoleKey.D2:
                                                Console.WriteLine("Area: " + c.Area);
                                                break;
                                            case ConsoleKey.D3:
                                                Console.WriteLine("Circumference" + c.Circumference);
                                                break;
                                            case ConsoleKey.D4:
                                                repeat = false;
                                                break;
                                            default:
                                                Console.WriteLine("Not an option");
                                                break;
                                        }
                                    }
                                    break;
                                case Geometry.Type.Rectangle:
                                    repeat = true;
                                    while (repeat)
                                    {
                                        Console.WriteLine("Information about Rectangle: 1.Width and Height, 2.Area, 3.Circumference, 4.Return");
                                        key = Console.ReadKey();
                                        Rectangle r = (Rectangle)g;
                                        switch (key.Key)
                                        {
                                            case ConsoleKey.D1:
                                                Console.WriteLine("Width:{0} Height:{1}", r.Width, r.Height);
                                                break;
                                            case ConsoleKey.D2:
                                                Console.WriteLine("Area: " + r.Area);
                                                break;
                                            case ConsoleKey.D3:
                                                Console.WriteLine("Circumference" + r.Circumference);
                                                break;
                                            case ConsoleKey.D4:
                                                repeat = false;
                                                break;
                                            default:
                                                Console.WriteLine("Not an option");
                                                break;
                                        }
                                    }
                                    break;
                                case Geometry.Type.Triangle:
                                     repeat = true;
                                     while (repeat)
                                     {
                                         Console.WriteLine("Information about Triangle: 1.Width and Height, 2.Area, 3.Circumference, 4.Return");
                                         key = Console.ReadKey();
                                         Triangle t = (Triangle)g;
                                         switch (key.Key)
                                         {
                                             case ConsoleKey.D1:
                                                 Console.WriteLine("Base width:{0} Side length:{1}", t.Base, t.Sides);
                                                 break;
                                             case ConsoleKey.D2:
                                                 Console.WriteLine("Area: " + t.Area);
                                                 break;
                                             case ConsoleKey.D3:
                                                 Console.WriteLine("Circumference" + t.Circumference);
                                                 break;
                                             case ConsoleKey.D4:
                                                 repeat = false;
                                                 break;
                                             default:
                                                 Console.WriteLine("Not an option");
                                                 break;
                                         }
                                     }
                                    break;

                            }    
                            
                        }
                        catch(System.NullReferenceException e)
                        {
                            Console.WriteLine(e.Data);
                        }
                        catch(System.ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Out of index");
                        }
                        break;
                    case ConsoleKey.D4:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Not an options , pick something else");
                        break;
                }
               
            }
            
            Console.ReadLine();


        }
    }
}
