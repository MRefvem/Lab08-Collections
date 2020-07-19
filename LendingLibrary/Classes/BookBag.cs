using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LendingLibrary.Classes
{
    public class BookBag<T> : IEnumerable<T>
    {
        T[] items = new T[5];
        int count;

        /// <summary>
        /// Performs the basic functionality that allows us to add an item to the book bag later on
        /// </summary>
        /// <param name="item">The item to be entered</param>
        public void Add(T item)
        {
            // evaluate the length of items vs the count
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        /// <summary>
        /// Returns the current count
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// GetEnumerator is a helper method that alows us to perform iterations easier
        /// </summary>
        /// <returns>The IEnumerator</returns>
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
