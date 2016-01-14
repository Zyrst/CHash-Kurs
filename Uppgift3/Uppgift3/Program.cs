using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Program
    {

        public struct Vector
        {
            public int x;
            public int y;

            public void Set(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        static void Main(string[] args)
        {
            SimpleList<Object> objects = new SimpleList<object>();

            objects.Add("Hello");
            objects.Add(2);
            objects.Add(10.3f);
            Console.WriteLine("List containing objects");
            Console.WriteLine("String: {0} int: {1} float: {2}", objects[0], objects[1], objects[2]);

            SimpleList<ValueType> values = new SimpleList<ValueType>();
            values.Add(10.4f);
            values.Add(true);
            values.Add(1337);
            Vector v = new Vector();
            v.Set(10, 20);
            values.Add(v);

            Vector y = (Vector)values[3];
            Console.WriteLine("List containing Valuetypes");
            Console.WriteLine("Float: {0} Bool: {1} Int: {2} Struct: ({3}, {4})", values[0], values[1], values[2], y.x, y.y);
            
            DateTime time = DateTime.Now;
            SimpleList<int> intVal = new SimpleList<int>();
            for (int i = 0; i < 10000; i++ )
            {
                intVal.Add(i);
            }
            Console.WriteLine("Count before remove:{0} ", intVal.Count);

            for (int j = 0; j < 1000; j++)
            {
                intVal.Remove(1000);
            }
            Console.WriteLine("Time taken: " + (DateTime.Now - time));
            Console.WriteLine("Count after: {0} ", intVal.Count);

            for (int j = 0; j < 1000; j++)
            {
                intVal.Remove(7000);
            }
            Console.WriteLine("Time taken: " + (DateTime.Now - time));
            Console.WriteLine("Count after: {0} ", intVal.Count);
            Console.ReadLine();
        }
    }
}
