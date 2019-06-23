using System;
using LibraryApp.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Data;

namespace Libraryapp.Pages.Books
{
    public class DetailModel : PageModel
    {
        public Book Book { get; set; }
        public IBookData BookData { get; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IBookData bookData)
        {
            BookData = bookData;
        }
        public IActionResult OnGet( int bookId)
        {
            Book = BookData.GetById(bookId);
            if(Book == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}