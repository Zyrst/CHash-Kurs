using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Uppgift5
{

    class Program
    {
        private static int COUNT = 100000;

        public struct Parameters
        {
            public List<int> aList;
            public int left;
            public int right;
        }

        public static void QuickSort(object o)
        {
            Parameters para = (Parameters)o;
            Console.WriteLine();
            Console.WriteLine(para.aList.Count);
            int i = para.left, j = para.right;

            int pivot = para.aList[(para.left + para.right) / 2];

            while(i <= j)
            {
                while (para.aList[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (para.aList[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if(i <= j)
                {
                    //Swap
                    int tmp = para.aList[i];
                    para.aList[i] = para.aList[j];
                    para.aList[j] = tmp;
                    i++;
                    j--;
                }

                if (para.left < j)
                {
                    Parameters pm = new Parameters();
                    pm.aList = para.aList;
                    pm.right = para.right;
                    pm.left = j;
                    QuickSort(pm);
                }

                if(i < para.right)
                {
                    Parameters pm = new Parameters();
                    pm.aList = para.aList;
                    pm.right = i;
                    pm.left = para.left;
                    QuickSort(pm);
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> intList = new List<int>(COUNT / 2);
            List<int> intList1 = new List<int>(COUNT / 2);
            Random rand = new Random();
            Parameters para = new Parameters();
            Parameters para1 = new Parameters();


            for (int i = 0; i < COUNT / 2; i++)
            {
                intList.Add(rand.Next(100));
                Console.Write(intList[i] + " ");
            }

            para.aList = intList;
            para.left = 0;
            para.right = intList.Count - 1;
            Thread t0 = new Thread(QuickSort);
            t0.Start(para);
            t0.Join();
           // QuickSort(intList, 0, intList.Count - 1);
            Console.WriteLine();
            for(int j = 0; j < 100; j++)
            {
                Console.Write(intList[j] + " ");
            }

            Console.ReadLine();
        }
    }
}
