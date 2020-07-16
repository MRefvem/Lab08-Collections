using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace LendingLibrary.Classes
{
    class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumberOfPages { get; set; }
        public Genres Genre { get; set; }
    }

    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public enum Genres : byte
    {
        Adventure = 1,
        Horror,
        Love,
        Drama,
        History
    }
}
