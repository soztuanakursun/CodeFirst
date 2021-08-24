using System.Collections.Generic;

namespace CodeFirstProject.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float SalePrice { get; set; }

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
