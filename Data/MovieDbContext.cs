using MovieShop.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MovieShop.Data
{
    public class MovieDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Customer> Customers { get; set; } 
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<OrderRow> OrderRows { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public MovieDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Add this to support Identity
        }
    }
}
