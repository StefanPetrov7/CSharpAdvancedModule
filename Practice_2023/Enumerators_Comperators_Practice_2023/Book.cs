using System;
namespace IteratorsAndComparators
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

        public int CompareTo(Book secondBook)  // Custom Book comparer 
        {
            if (this.Year.CompareTo(secondBook.Year) > 0)
            {
                return 1;

            }
            else if(this.Year.CompareTo(secondBook.Year) < 0)
            {
                return -1;
            }
            else
            {
                return this.Title.CompareTo(secondBook.Title);
            }
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}

