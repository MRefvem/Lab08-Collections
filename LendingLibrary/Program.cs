using LendingLibrary.Classes;
using System;
using System.Collections.Generic;

namespace LendingLibrary
{
    class Program
    {
        static Library<Book> Library { get; set; }
        static List<Book> BookBag { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Phil's Lending Library!");
            Console.WriteLine("");
            Library = new Library<Book>();
            List<string> myBooks = new List<string>();
            Library.Add(new Book()
            {
                Title = "The Lord of the Flies",
                Author = { FirstName = "William", LastName = "Golding" },
                NumberOfPages = 200,
                Genre = Genres.Adventure
            });
            Library.Add(new Book()
            {
                Title = "Harry Potter",
                Author = { FirstName = "JK", LastName = "Rowling" },
                NumberOfPages = 500,
                Genre = Genres.Adventure
            });
            Library.Add(new Book()
            {
                Title = "Treasure Island",
                Author = { FirstName = "Someone", LastName = "Someone" },
                NumberOfPages = 1000,
                Genre = Genres.Adventure
            });
            Library.Add(new Book()
            {
                Title = "The Great Gatsby",
                Author = { FirstName = "F. Scott", LastName = "Fitzgerald" },
                NumberOfPages = 200,
                Genre = Genres.Adventure
            });
            Library.Add(new Book()
            {
                Title = "The Lost World",
                Author = { FirstName = "Michael", LastName = "Crichton" },
                NumberOfPages = 350,
                Genre = Genres.Adventure
            });
            BookBag = new List<Book>();
            LoadBooks();
            UserInterface();
        }

        public static void UserInterface()
        { 

            bool running = true;

            while (running == true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("1. View all Books");
                Console.WriteLine("2. Add a Book");
                Console.WriteLine("3. Borrow a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("5. View Book Bag");
                Console.WriteLine("6. Exit");
                // Based on their number, return correct method

                string selection = Console.ReadLine();
                int userChoice = Convert.ToInt32(selection);

                if (userChoice == 1)
                {
                    LoadBooks();
                    Console.WriteLine("Type any input to continue");
                    Console.ReadLine();
                }
                else if (userChoice == 2)
                {
                    Console.WriteLine("What is the title of the book you would like to add?");
                    string newBookTitle = Console.ReadLine();
                    Console.WriteLine("What is the first name of the author?");
                    string newBookAuthorFirstName = Console.ReadLine();
                    Console.WriteLine("What is the last name of the author?");
                    string newBookAuthorLastName = Console.ReadLine();
                    Console.WriteLine("How many pages does this book have?");
                    string response = Console.ReadLine();
                    int responseToNumber = Convert.ToInt32(response);
                    Console.WriteLine("What is the genre of this book?");
                    string newBookGenre = Console.ReadLine();
                    Genres genre = (Genres)Enum.Parse(typeof(Genres), newBookGenre);
                    
                    AddABook(newBookTitle, newBookAuthorFirstName, newBookAuthorLastName, responseToNumber, genre);
                }
                else if (userChoice == 3)
                {
                    
                    string bookTitle = Console.ReadLine();
                    Book bookToBorrow = null;
                    foreach (Book book in Library)
                    {
                        if (book.Title == bookTitle)
                        {
                            bookToBorrow = book;
                        }
                    }
                    Borrow(bookToBorrow);

                }
                else if (userChoice == 4)
                {
                    ReturnBook();
                }
                else if (userChoice == 5)
                {
                    Console.WriteLine("Your book bag contains:");
                }
                else if (userChoice == 6)
                {
                    running = false;
                }

            }
            Console.WriteLine("");
            Console.WriteLine("Please come again!");
            return;

        }

        static void LoadBooks()
        {

            Console.WriteLine("Here are the current books:");
            foreach (Book book in Library)
            {
                Console.WriteLine(book.Title);
            }
        }

        public static void Borrow(Book book)
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to borrow");
            int counter = 1;
            foreach (var item in Library)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book borrowedBook);
            Library.Remove(borrowedBook);
            BookBag.Add(borrowedBook);
        }

        static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
            Library.Add(returnedBook);
        }

        static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genres genre)
        {
            Book book = new Book()
            {
                Title = title,
                Author = new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                NumberOfPages = numberOfPages,
                Genre = genre
            };

            Library.Add(book);
        }
    }
}
