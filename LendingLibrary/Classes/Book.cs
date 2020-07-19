using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace LendingLibrary.Classes
{
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumberOfPages { get; set; }
        public Genres Genre { get; set; }
    }

    public enum Genres : byte
    {
        Fantasy = 1,
        Adventure,
        Romance,
        Contemporary,
        Dystopian,
        Fiction,
        Mystery,
        Horror,
        Thriller,
        Childrens,
        ScienceFiction,
        YoungAdult,
        Biography
    }
}
