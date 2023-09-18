using System;
namespace IteratorsAndComparators
{
	public class BookComparator : IComparer<Book>  // Once used in the Book collections, it compares all the books in it. 
	{
        public int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);

            if (result == 0)
            {
                result = x.Year.CompareTo(y.Year);
            }

            return result;
        }
    }
}

