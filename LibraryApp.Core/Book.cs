using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Core
{
    public class Book
    {
        public int BookID { get; set; }

        [Required, StringLength(80)]        
        public string Name { get; set; }

        [Required, StringLength(150)]
        public string Author { get; set; }
        //public BookGenre Genre { get; set; }
        public BookGenre Genre { get; set; }
    }
}
