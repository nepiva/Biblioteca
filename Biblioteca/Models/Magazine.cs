using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Magazine : Element
    {
        public int NumberOfSerie { get; set; }
        public string ColectionName { get; set; }
    }
}
