using LibraryApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

    namespace LibraryApp.Data
{
    public interface IBookData
    {
        IEnumerable<Book> GetBookByName(string name);


    }

    public class InMemoryBookData : IBookData
    {

        List<Book> book;

        public InMemoryBookData()
        {
            book = new List<Book>()
                {
                    new Book {BoodID = 1, Name = "Book1", Author ="Author1"},
                    new Book {BoodID = 2, Name = "Book2", Author ="Author2"},
                    new Book {BoodID = 3, Name = "Book3", Author ="Author3"}
                };

        }
        public IEnumerable<Book> GetBookByName(string name = null)
        {
            return from b in book
                   where string.IsNullOrEmpty(name) || b.Name.StartsWith(name)
                   orderby b.Name
                   select b;

        }
    }
}
