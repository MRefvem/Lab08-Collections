using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LendingLibrary.Classes
{
    class Library<T> : IEnumerable<T>
    {
        T[] items = new T[5];
        int count;

        

        public void Add(T item)
        {
            // evaluate the length of items vs the count
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        public T Remove(T item)
        {
            int j = 0;
            // logic: how do we remove?
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                {
                    j++;
                    count--;
                }
                if (i != j)
                {
                    items[i] = items[j];
                }
                j++;
            }
            return item;
        }

        public int Count()
        {
            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                // yield break
                yield return items[i];
            }
        }

        // Magic, don't touch.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
