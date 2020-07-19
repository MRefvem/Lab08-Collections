using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LendingLibrary.Classes
{
    public class Library<T> : IEnumerable<T>
    {
        T[] items = new T[5];
        int count;

        /// <summary>
        /// Performs the basic functionality that allows us to add a book to the library
        /// </summary>
        /// <param name="item">The object that is being added</param>
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
        /// Performs the basic functionality that allows the user to remove a book from the library, then returns the object chosen
        /// </summary>
        /// <param name="item">The book the user selected to be removed</param>
        /// <returns>The book the user selected to be removed</returns>
        public Book Remove(Book item)
        {
            int j = 0;
            
            // logic: how do we remove?
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    j++;
                    count--;
                }
                if (j <= count)
                {
                    items[i] = items[i+j];
                }   
            }
            return item;
        }

        /// <summary>
        /// The current count
        /// </summary>
        /// <returns>The current count</returns>
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
