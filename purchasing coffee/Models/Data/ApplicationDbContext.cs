using Microsoft.EntityFrameworkCore;
using purchasing_coffee.Models.Entities;

namespace purchasing_coffee.Models.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Coffee> coffees { get; set; }
        public DbSet<Order> orders { get; set; }
    }
}
 