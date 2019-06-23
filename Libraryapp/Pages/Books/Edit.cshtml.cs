using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Core;
using LibraryApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libraryapp.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookData bookData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

        public EditModel(IBookData bookData,
                         IHtmlHelper htmlHelper)
        {
            this.bookData = bookData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? bookId)
        {
            Genres = htmlHelper.GetEnumSelectList<BookGenre>();
            if (bookId.HasValue)
            {
                Book = bookData.GetById(bookId.Value);
            }
           else
            {
                Book = new Book();
            }

            if (Book == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
           if (!ModelState.IsValid)
            {
                Genres = htmlHelper.GetEnumSelectList<BookGenre>();
                return Page();
                
            }
           if (Book.BookID > 0)
            {

                bookData.UpdateBook(Book);

            }
           else
            {
                bookData.AddBook(Book);
            }

            TempData["Message"] = "Book Saved";
            bookData.Commit();

            return RedirectToPage("./Detail", new { bookId = Book.BookID });
        }
    }
}