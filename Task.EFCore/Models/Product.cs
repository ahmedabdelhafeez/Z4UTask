
using System.ComponentModel.DataAnnotations;

namespace Task.EFCore.Models
{
    public class Product:Entity
    {
        [Required(ErrorMessage ="Please Add name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Please Add Price")]
        public double Price { set; get; }

        public string? Description { set; get; }
        [Required(ErrorMessage = "Please Add Category")]
        public string Category { set; get; }

    }
}
