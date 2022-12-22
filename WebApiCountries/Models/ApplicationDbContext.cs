using Microsoft.EntityFrameworkCore;

namespace WebApiCountries.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
    }
}
