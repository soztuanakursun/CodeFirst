using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstProject.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]

        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Display(Name = "Price")]
        [Required]
        [Range(1.00, 1000000000,
            ErrorMessage = "Price must be between 1.00 and 1000000000")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        [Range(1,100,
            ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        public Customer Customer { get; set; }  //bir siparişi sadece 1 müşteri gibi gibi
        public List<Product> Products { get; set; } 
    }
}
