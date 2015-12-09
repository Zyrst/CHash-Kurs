using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Uppgift5
{
    class QuickSort
    {
        private List<int> mList;

        public QuickSort(List<int> ints)
        {
            mList = ints;
        }

        public List<int> GetList()
        {
            return mList;
        }

        public void Sort()
        {
            Random rand = new Random();

            int pivot = mList[(mList.Count - 1 )/ 2];
            List<int> lower = new List<int>();
            List<int> greater = new List<int>();
            greater.Add(pivot);
            for(int i = 0; i < mList.Count; i++)
            {
                if(mList[i] >= pivot)
                {
                    greater.Add(mList[i]);
                }
                else if (mList[i] < pivot)
                {
                    lower.Add(mList[i]);
                }
            }

            Thread thread = new Thread(() =>
            {
                sort(lower, 0, lower.Count - 1);
            });
            thread.Start();
            sort(greater, 0, greater.Count - 1);
            thread.Join();

            for (int i = 0; i < greater.Count; i++)
            {
                lower.Add(greater[i]);
            }

            mList = lower;
            
        }

        private static void sort(List<int> aList, int left  , int right)
        {
            int i = left, j = right;
            int pivot = aList[(i + j) / 2];

            while(i <= j)
            {
                while(aList[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while(aList[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if(i <= j)
                {
                    int tmp = aList[i];
                    aList[i] = aList[j];
                    aList[j] = tmp;
                    i++;
                    j--;
                }

                if(left < j)
                {
                    sort(aList, left, j);
                }

                if(i < right)
                {
                    sort(aList, i, right);
                }

            }
        }

        
    }
}
