using System;
using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>  // Implementing Enumerable collection with private Iterator 
    {
        public Library(params Book[] books)
        {
            this.Books = new SortedSet<Book>(books, new BookComparator());
        }

        public SortedSet<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()  // return Enumerator implemented with LibraryIterator 
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private class LibraryIterator : IEnumerator<Book>  // Implementing enumerator
        {
            private int index = -1; // starting index

            public LibraryIterator(IEnumerable<Book> books)  // reqieres collection 
            {
                this.Reset();
                this.Books = new List<Book>(books);
            }

            public List<Book> Books { get; set; }

            public Book Current => this.Books[index];  // return current index 

            object IEnumerator.Current => this.Current;  // old implementation 

            public void Dispose() { }

            public bool MoveNext() => ++index < this.Books.Count;  // this is called in the cycles and unil is true index is ++

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}