﻿using System;
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
        private const int COUNT = 10000;


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
            List<int> intList = new List<int>(COUNT);
            Random rand = new Random();
           

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
            DateTime time = DateTime.Now;
            Console.WriteLine("Start time: " + time);
            t0.Start();
            qs1.Sort();
            t0.Join();
            
            List<int> sorted = qs1.GetList();


            List<int> qsList = qs0.GetList();
            for (int j = 0; j < qsList.Count; j++)
            {
                sorted.Add(qsList[j]);
            }
            Console.WriteLine();
            Console.WriteLine("Elapsed time: " + (DateTime.Now - time));
            

            for (int i = 0; i < sorted.Count; i++ )
            {
                //Console.Write(sorted[i] + " ");
            }
            
            

            Console.ReadLine();
        }
    }
}
