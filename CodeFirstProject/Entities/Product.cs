using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstProject.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "SalePrice")]
        [Required]
        [Range(1.00, 1000000000,
            ErrorMessage = "Price must be between 1.00 and 1000000000")]
        public decimal SalePrice { get; set; }

        private int category;

        public int GetCategory()
        {
            return category;
        }

        public void SetCategory(int value)
        {
            category = value;
        }

        public Category Category { get; set; } //bir ürünün 1 kategorisi olabilir
        public List<Order> Orders { get; set; }
    }
}
