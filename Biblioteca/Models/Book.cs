using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Book : Element
    {
        public string Author { get; set; }
        public string Pages { get; set; }
    }
}
