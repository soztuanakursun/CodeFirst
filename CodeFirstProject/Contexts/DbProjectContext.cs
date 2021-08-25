using CodeFirstProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodeFirstProject.Contexts
{
    public class DbProjectContext : DbContext
    {
        public DbProjectContext(DbContextOptions<DbProjectContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        internal object Find(int id)
        {
            throw new NotImplementedException();
        }

        internal object Entry(object customer)
        {
            throw new NotImplementedException();
        }
    }
}
