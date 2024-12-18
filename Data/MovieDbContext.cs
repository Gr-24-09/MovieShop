using MovieShop.Models.DataBase;
using Microsoft.EntityFrameworkCore;

namespace MovieShop.Data
{
    public class MovieDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; } 
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<OrderRow> OrderRows { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public MovieDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
