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

        Book GetById(int id);
        Book UpdateBook(Book udpdatedBook);
        int Commit();

    }

    public class InMemoryBookData : IBookData
    {

        List<Book> book;

        public InMemoryBookData()
        {
            book = new List<Book>()
                {
                    new Book {BookID = 1, Name = "Book1", Author ="Author1", Genre = BookGenre.Action},
                    new Book {BookID = 2, Name = "Book2", Author ="Author2", Genre = BookGenre.SciFi},
                    new Book {BookID = 3, Name = "Book3", Author ="Author3", Genre= BookGenre.Fantasy}
                };

        }

        public Book GetById(int id)
        {
            return book.SingleOrDefault(b => b.BookID == id);

        }
        public Book UpdateBook(Book updatedBook)
        {
            var books = book.SingleOrDefault(b => b.BookID == updatedBook.BookID);
            if (books != null)
            {
                books.Name= updatedBook.Name;
                books.Author = updatedBook.Author;
                books.BookID = updatedBook.BookID;
                books.Genre = updatedBook.Genre;
            }

            return books;
        }

        public int Commit()
        {
            return 0;
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
