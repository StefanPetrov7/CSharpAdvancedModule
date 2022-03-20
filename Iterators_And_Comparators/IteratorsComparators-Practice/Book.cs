using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace IteratorsComperators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }

        public int CompareTo(Book y)
        {
            return this.Year.CompareTo(y.Year);
        }

        public override string ToString()
        {
            return $"{this.Title} -> {this.Year}";
        }
    }
}
