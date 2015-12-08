using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Uppgift5
{
    public struct Parameters
    {
        public List<int> aList;
        public int left;
        public int right;
    }

    class Program
    {
        private const int COUNT = 100;


        public static List<int> Split(int startVal, List<int> unSplit)
        {
            List<int> splitList = new List<int>();
            for(int i = startVal; i < unSplit.Count; i += 2)
            {
                splitList.Add(unSplit[i]);
            }

            return splitList;
        }

        static void Main(string[] args)
        {
            List<int> intList = new List<int>(COUNT);
            Random rand = new Random();
           

            for (int i = 0; i < COUNT; i++)
            {
                intList.Add(rand.Next(100));
                //Console.Write(intList[i] + " ");
            }

            QuickSort qs0 = new QuickSort(Split(0, intList));
            QuickSort qs1 = new QuickSort(Split(1, intList));
            Thread t0 = new Thread(qs0.Sort);
            t0.Start();
            qs1.Sort();
            t0.Join();

          
         
           // QuickSort(intList, 0, intList.Count - 1);
            Console.WriteLine();
            List<int> qsList = qs0.GetList();
            for (int j = 0; j < qsList.Count; j++)
            {
                Console.Write(qsList[j] + " ");
            }

            Console.ReadLine();
        }
    }
}
