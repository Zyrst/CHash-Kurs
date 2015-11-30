using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{  
    class SimpleList<Element> : ICollection<Element>
    {
        private int mSize;
        private int mCount = 0;
        private Element[] mElements;

        public SimpleList()
        {
            mSize = 8;
            mElements = new Element[mSize];
        }

        public SimpleList(int size) 
        {
            mSize = size;
            mElements = new Element[mSize];
        }

        public int Count
        {
            get
            {
                return mCount;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        private void Resize()
        {
            Element[] newArray = new Element[mSize * 2];
            mSize *= 2;
            for(int i = 0; i < mElements.Length; i++)
            {
                newArray[i] = mElements[i];
            }

            mElements = newArray;
        }
        
        public void Add(Element e)
        {
            if(mCount < mSize)
            {
                mElements[mCount] = e;
                mCount++;
            }
            else
            {
                Resize();
                mElements[mCount] = e;
                mCount++;
            }
        }

        public bool Remove(Element e)
        {
           for(int i = 0; i < mCount; i++)
           {
               if(mElements[i].Equals(e))
               {
                   for(int j = i; j < mCount - 1; j++)
                   {
                       mElements[j] = mElements[j + 1];
                   }
                   mCount--;
                   return true;
               }
           }

           return false;
        }

        public void Clear()
        {
            mElements = new Element[mSize];
        }

        public void CopyTo(Element[] e, int index)
        {
            foreach(Element element in mElements)
            {
                e[index] = element;
                index++;
            }
        }
    }
}
