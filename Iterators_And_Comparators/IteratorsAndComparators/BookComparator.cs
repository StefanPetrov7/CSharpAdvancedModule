using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {

        public int Compare(Book x, Book y)  // The only pourpose is to compare <Book>;
        {
            int result = x.Title.CompareTo(y.Title); // alphabetical order;

            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year); // from the newest to the oldest.;
            }

            return result;
        }
    }
}
