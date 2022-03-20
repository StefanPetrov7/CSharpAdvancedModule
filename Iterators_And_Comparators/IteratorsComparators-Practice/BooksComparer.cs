using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsComperators
{
    public class BooksComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Title.CompareTo(y.Title);
        } 
    }
}
