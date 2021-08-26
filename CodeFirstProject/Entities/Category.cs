using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstProject.Entities
{
    public class Category
    {
        public  int Id { get; set; }

        [Required]
        [Display(Name= "Name")]
        [StringLength(50, ErrorMessage =
            "should be less than or equal to 50 characters.")]
        public string Name { get; set; }

        public List<Product> Products { get; set; } //bir kategori birden çok ürün barındırabilir.
    }
}
