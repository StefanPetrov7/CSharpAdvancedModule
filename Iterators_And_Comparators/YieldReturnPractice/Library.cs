using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CompletePractice
{
    public class Library : IEnumerable<Book> 
    {
        private SortedSet<Book> books { get; set; }

        public Library(params Book[] book)
        {
            this.books = new SortedSet<Book>(book, new BookComparer()); // ->if we remove IComarer from the set, 
        }                                                               // it will use the default IComaprer from the <Book> class

        public IEnumerator<Book> GetEnumerator()
        {
            // int index = 0;
            // 
            // while (index < books.Count)
            // {
            //     yield return books[index];
            //     index++;
            // }
                                                            //-> < books.Sort() > if we use List<Book> we can apply the sorting directly here 
            return new BookEnumerator(books);  
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class BookEnumerator : IEnumerator<Book>
        {
            private int index = -1;

            public BookEnumerator(SortedSet<Book> list)
            {
                List = list.ToList();
            }

            public List<Book> List { get; set; }

            public Book Current => List[index];

            object IEnumerator.Current => List[index];

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                index++;

                if (List.Count <= index)  // return ++index < list.Count; 
                {
                    return false;
                }

                return true;

            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
