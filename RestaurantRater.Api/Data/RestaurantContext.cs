using Microsoft.EntityFrameworkCore;
using RestaurantRater.Shared.Models;

namespace RestaurantRater.Api.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants => Set<Restaurant>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .ToTable(t => t.HasCheckConstraint("CK_Restaurant_PriceBracket", "PriceBracket BETWEEN 1 AND 5"));

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Location).IsRequired().HasMaxLength(64);
        }
    }
}
