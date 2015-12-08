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
            if (mList.Count > 1)
            {


                int i = 0, j = mList.Count - 1;
                int pivot = mList[(i + j) / 2];

                List<int> lower = new List<int>();
                List<int> greater = new List<int>();
                greater.Add(pivot);

                while (i <= j)
                {
                    //Lower than our pivot element
                    while (mList[i].CompareTo(pivot) < 0)
                    {
                        i++;
                        lower.Add(mList[i]);
                    }
                    //Greater than our pivot element
                    while (mList[j].CompareTo(pivot) > 0)
                    {
                        j--;
                        greater.Add(mList[j]);
                    }
                    QuickSort qs = new QuickSort(lower);
                    Parameters pm0 = new Parameters();
                    pm0.aList = greater;
                    pm0.left = 0;
                    pm0.right = greater.Count;

                    Thread thread = new Thread(qs.Sort);
                    thread.Start();
                    mList = sort(pm0);
                    thread.Join();
                    mList = qs.GetList();
                    mList.AddRange(greater);

                    //if (i <= j)
                    //{
                    //    //Swap
                    //    int tmp = mList[i];
                    //    mList[i] = mList[j];
                    //    mList[j] = tmp;
                    //    i++;
                    //    j--;
                    //}
                    //Parameters pm0 = new Parameters();
                    //Parameters pm1 = new Parameters();
                    //if (mList.Count - 1 < j)
                    //{
                    //    pm0.aList = mList;
                    //    pm0.right = mList.Count - 1;
                    //    pm0.left = j;
                    //   // mList = sort(pm);
                    //    //sort(pm);
                    //}

                    //if (i < mList.Count - 1)
                    //{
                    //    pm1.aList = mList;
                    //    pm1.right = i;
                    //    pm1.left = 0;
                    //    //mList = sort(pm);
                    //    //sort(pm);
                    //}
                }
            }
        }

        private List<int> sort(Parameters para)
        {
            int i = para.left, j = para.right;

            int pivot = para.aList[(i + j) / 2];

            while (i <= j)
            {
                while (para.aList[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (para.aList[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
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
                    para.aList = sort(pm);
                }

                if (i < para.right)
                {
                    Parameters pm = new Parameters();
                    pm.aList = para.aList;
                    pm.right = i;
                    pm.left = para.left;
                    para.aList = sort(pm);
                }
            }

            return para.aList;
        }
    }
}
