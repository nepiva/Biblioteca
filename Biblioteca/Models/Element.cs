using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public abstract class Element
    {
        [Required]
        [Key]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string PublicationYear { get; set; }
        public string ElementType { get; set; }
    }
}