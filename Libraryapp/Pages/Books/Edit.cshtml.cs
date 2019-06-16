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

        public Book Book { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

        public EditModel(IBookData bookData,
                         IHtmlHelper htmlHelper)
        {
            this.bookData = bookData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int bookId)
        {
            Genres = htmlHelper.GetEnumSelectList<BookGenre>();
            Book = bookData.GetById(bookId);

            if (Book == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}