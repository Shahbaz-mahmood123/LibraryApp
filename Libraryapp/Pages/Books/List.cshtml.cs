using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data;
using LibraryApp.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;


namespace Libraryapp.Pages.Shared
{
    public class BooksModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IBookData bookData;

        public  String Message{ get; set; }
        public IEnumerable<Book> Books { get; set; }

        [BindProperty(SupportsGet =true)]
        public string BookSearch { get; set; }

        public BooksModel(IConfiguration config, IBookData bookData)
        {
            this.config = config;
            this.bookData = bookData;
        }
        public void OnGet( )
        {
            
            Message = "Hello World";
            Books = bookData.GetBookByName( BookSearch);
        }
    }
}