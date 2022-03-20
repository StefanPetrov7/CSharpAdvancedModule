using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsComperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Book one = new Book("Inferno", 2022, "Dan", "Braun");
            Book two = new Book("Hell", 2034, "Dan", "Braun");
            Book three = new Book("MonteChristo", 1987, "Alexander", "Duma");
            Book four = new Book("Shogun", 1980, "James", "Kavel");

            Library library = new Library() {one, two, three, four };

            foreach (var book in library)
            {
                Console.WriteLine(book);
            }

            //SortedSet<Book> setOfBooks = new SortedSet<Book>(new BooksComparer()) { one, two, three, four };

            //foreach (var book in setOfBooks)
            //{
            //    Console.WriteLine(book);
            //}
        }
    }
}
