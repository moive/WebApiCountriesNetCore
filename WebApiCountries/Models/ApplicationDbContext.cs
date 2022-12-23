using Microsoft.EntityFrameworkCore;

namespace WebApiCountries.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}
