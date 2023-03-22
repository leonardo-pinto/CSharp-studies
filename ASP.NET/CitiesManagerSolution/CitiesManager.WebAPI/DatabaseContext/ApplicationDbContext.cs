using CitiesManager.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.WebAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public ApplicationDbContext() { }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City() { CityId = Guid.Parse("7989A2D3-276C-46DC-BF11-53ED5A9D837D"), CityName = "New York" });
            modelBuilder.Entity<City>().HasData(new City() { CityId = Guid.Parse("2844BFF6-30EC-4B71-B9B6-0DF816460D7C"), CityName = "Toronto" });
        }
    }
}
