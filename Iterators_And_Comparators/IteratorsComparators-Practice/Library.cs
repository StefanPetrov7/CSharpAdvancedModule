using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsComperators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library()
        {
            this.books = new List<Book>();
        }

        public Library(List<Book> books) : this()
        {
            this.books = books;
        }

        public void Add(Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()         // 3 ways of returning the enumerator 
        {
            //for (int i = 0; i < books.Count; i++)      // 1 => with yield method 
            //{
            //    yield return books[i];
            //}

            //return this.books.GetEnumerator();         // 2 => use the GetEnumearator() method from the internal collection 

           this.books.Sort();     // => use the default CompareTo to sort the books 

            return new LibraryIterator(this.books);      // 3 => implement Class Iterator 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LibraryIterator : IEnumerator<Book>
    {
        private int index;

        private List<Book> list;

        public LibraryIterator(List<Book> list)
        {
            this.list = list;
            this.Reset();
        }

        public Book Current => this.list[index];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            return ++index < this.list.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
