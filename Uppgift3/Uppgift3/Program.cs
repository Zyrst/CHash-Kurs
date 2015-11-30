using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleList<int> intList = new SimpleList<int>();
            Random rand = new Random();

            for(int i = 0; i < 17; i++)
            {
                intList.Add(i);

            }

            for(int j = 0; j < intList.Count; j++)
            {
                Console.WriteLine(intList[j]);
            }

            intList.Remove(10);
            intList.Remove(intList[2]);
            Console.WriteLine("Removed element 10 and at index 2, new Count: " + intList.Count);
            for (int j = 0; j < intList.Count; j++)
            {
                Console.WriteLine(intList[j]);
            }
            Console.ReadLine();
        }
    }
}
