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
        private const int COUNT = 50000;

        public static List<int>[] Split1(List<int> unSplit)
        {
            List<int>[] lists = new List<int>[2];
            lists[0] = new List<int>();
            lists[1] = new List<int>();
            for(int i = 0; i < unSplit.Count; i+= 2)
            {
                lists[0].Add(unSplit[i]);
            }

            for (int i = 1; i < unSplit.Count; i += 2)
            {
                lists[1].Add(unSplit[i]);
            }

            return lists;
        }

        public static List<int>[] Split(List<int> unSplit)
        {
            int pivot = unSplit[(unSplit.Count - 1) / 2];
            List<int>[] lists = new List<int>[2];
            lists[0] = new List<int>();
            lists[1] = new List<int>();
            for (int i = 0; i < unSplit.Count; i++)
            {
                if(unSplit[i].CompareTo(pivot) > 0 || unSplit[i].CompareTo(pivot) == 0)
                {
                    lists[0].Add(unSplit[i]);
                }
                else if(unSplit[i].CompareTo(pivot) < 0)
                {
                    lists[1].Add(unSplit[i]);
                }
            }

                return lists;
        }

        static void Main(string[] args)
        {

            DateTime time = DateTime.Now;
            Console.WriteLine("Number of elements: " + COUNT);
            Console.WriteLine("Start time: " + time);
            List<int> intList = new List<int>(COUNT);
            Random rand = new Random(DateTime.Now.Millisecond);
           
            for (int i = 0; i < COUNT; i++)
            {
                intList.Add(rand.Next());
                //Console.Write(i+ " ");
            }
            Console.Write("Starting thread");
            List<int>[] lists = Split(intList);
            QuickSort qs0 = new QuickSort(lists[0]);
            QuickSort qs1 = new QuickSort(lists[1]);
            Thread t0 = new Thread(qs0.Sort);
            t0.Start();
            qs1.Sort();
            t0.Join();
            
            List<int> sorted = qs1.GetList();


            List<int> qsList = qs0.GetList();
            for (int j = 0; j < qs0.GetList().Count; j++)
            {
                sorted.Add(qs0.GetList()[j]);
            }
            Console.WriteLine();

            //QuickSort qs2 = new QuickSort(sorted);
            //qs2.Sort();
            Console.WriteLine("Elapsed time: " + (DateTime.Now - time));


            //for (int i = 0; i < sorted.Count; i++)
            //{
            //    Console.Write(sorted[i] + " ");
            //}
            
            

            Console.ReadLine();
        }
    }
}
