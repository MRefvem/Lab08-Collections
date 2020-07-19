using LendingLibrary.Classes;
using System;
using System.Collections.Generic;

namespace LendingLibrary
{
    public class Program
    {
        static Library<Book> Library { get; set; }
        static List<Book> BookBag { get; set; }

        /// <summary>
        /// Main Method - The entry point into the program
        /// </summary>
        /// <param name="args">The key the user enters</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Phil's Lending Library!");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER key to continue");
            Console.ReadLine();
            Library = new Library<Book>();
            List<string> myBooks = new List<string>();
            Library.Add(new Book()
            {
                Title = "The Lord of the Flies",
                Author = new Author()
                {
                    FirstName = "William",
                    LastName = "Golding"
                },
                NumberOfPages = 224,
                Genre = Genres.Adventure
            });
            Library.Add(new Book()
            {
                Title = "To Kill a Mockingbird",
                Author = new Author()
                {
                    FirstName = "Harper",
                    LastName = "Lee"
                },
                NumberOfPages = 296,
                Genre = Genres.Fiction
            });
            Library.Add(new Book()
            {
                Title = "Goodnight Moon",
                Author = new Author()
                {
                    FirstName = "Margaret Wise",
                    LastName = "Brown"
                },
                NumberOfPages = 32,
                Genre = Genres.Childrens
            });
            Library.Add(new Book()
            {
                Title = "The Fault in Our Stars",
                Author = new Author()
                {
                    FirstName = "John",
                    LastName = "Green"
                },
                NumberOfPages = 313,
                Genre = Genres.YoungAdult
            });
            Library.Add(new Book()
            {
                Title = "Jurassic Park",
                Author = new Author()
                {
                    FirstName = "Michael",
                    LastName = "Crichton"
                },
                NumberOfPages = 448,
                Genre = Genres.ScienceFiction
            });
            Library.Add(new Book()
            {
                Title = "Animal Farm",
                Author = new Author()
                {
                    FirstName = "George",
                    LastName = "Orwell"
                },
                NumberOfPages = 112,
                Genre = Genres.Dystopian
            });
            BookBag = new List<Book>();
            LoadBooks();
            UserInterface();
        }

        /// <summary>
        /// User Interface - The way the user interacts with the program. Can take in a selection of inputs ranging from numbers 1-6, and calls upon various methods based on the input to run the program.
        /// </summary>
        public static void UserInterface()
        { 

            bool running = true;

            while (running == true)
            {
                Console.Clear();
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("");
                Console.WriteLine("1. View all Books");
                Console.WriteLine("2. Add a Book");
                Console.WriteLine("3. Borrow a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("5. View Book Bag");
                Console.WriteLine("6. Exit");

                // Based on their number, use the correct method

                string selection = Console.ReadLine();
                int userChoice = Convert.ToInt32(selection);

                if (userChoice == 1)
                {
                    LoadBooks();
                    Console.WriteLine("");
                    Console.WriteLine("Press ENTER key to continue");
                    Console.ReadLine();
                }
                else if (userChoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("What is the title of the book you would like to add?");
                    string newBookTitle = Console.ReadLine();
                    Console.WriteLine("What is the first name of the author?");
                    string newBookAuthorFirstName = Console.ReadLine();
                    Console.WriteLine("What is the last name of the author?");
                    string newBookAuthorLastName = Console.ReadLine();
                    Console.WriteLine("How many pages does this book have?");
                    string response = Console.ReadLine();
                    int responseToNumber = Convert.ToInt32(response);
                    Console.WriteLine("What is the genre of this book? (Fantasy, Adventure, Romance, Contemporary, Dystopian, Fiction, Mystery, Horror, Thriller, Childrens, ScienceFiction, YoungAdult, Biography");
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
                    PrintBookBag();
                    Console.WriteLine("Press ENTER key to continue");
                    Console.ReadLine();
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

        /// <summary>
        /// Load Books - Displays a list of the books currently in the library
        /// </summary>
        public static void LoadBooks()
        {
            Console.Clear();
            Console.WriteLine("Here are the current books:");
            Console.WriteLine("");

            int counter = 1;
            foreach (Book book in Library)
            {
                Console.WriteLine($"{counter++}. {book.Title} - {book.Author.FirstName} {book.Author.LastName}");
            }
        }

        /// <summary>
        /// Borrow Method - The way the program adds a book to the user's book bag
        /// </summary>
        /// <param name="book">Takes in the name of the book that the user wants to add to their bag</param>
        public static void Borrow(Book book)
        {
            Console.Clear();
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to borrow (pick number correlating to selection)");
            Console.WriteLine("");
            int counter = 1;
            foreach (Book oneBook in Library)
            {
                books.Add(counter, oneBook);
                Console.WriteLine($"{counter++}. {oneBook.Title} - {oneBook.Author.FirstName} {oneBook.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book borrowedBook);
            Library.Remove(borrowedBook);
            BookBag.Add(borrowedBook);
        }

        /// <summary>
        /// Return book - Takes a book from the user's book bag and puts it back into the library
        /// </summary>
        public static void ReturnBook()
        {
            Console.Clear();
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (Book book in BookBag)
            {
                books.Add(counter, book);
                Console.WriteLine($"{counter++}. {book.Title} - {book.Author.FirstName} {book.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
            Library.Add(returnedBook);
        }

        /// <summary>
        /// Add a book - Allows the user to enter a new book into the library collection
        /// </summary>
        /// <param name="title">Title of the book the user wishes to enter</param>
        /// <param name="firstName">First name of author</param>
        /// <param name="lastName">Last name of author</param>
        /// <param name="numberOfPages">Number of pages</param>
        /// <param name="genre">Genre of the book</param>
        public static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genres genre)
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

        /// <summary>
        /// Print Book Bag - Prints a list of the books currently in the user's book bag
        /// </summary>
        public static void PrintBookBag()
        {
            Console.Clear();
            int counter = 1;
            Console.WriteLine("This is your Book Bag");
            Console.WriteLine();
            foreach (Book oneBook in BookBag)
            {
                Console.WriteLine($"{counter++}. {oneBook.Title} - {oneBook.Author.FirstName} {oneBook.Author.LastName}");

            }
            Console.WriteLine("");
        }
}
}
