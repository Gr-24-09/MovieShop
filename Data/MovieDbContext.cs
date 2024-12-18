using MovieShop.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using MovieShop.Models.DataBase;

namespace CodeFirstAproach.Data
{
    public class MovieDBContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; } // NALINI
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<OrderRow> OrderRows { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public MovieDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
