using System.Collections.Generic;

namespace CodeFirstProject.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Customer Customer { get; set; }  //bir siparişi sadece 1 müşteri gibi gibi
        public List<Product> Products { get; set; } 
    }
}
