using Microsoft.EntityFrameworkCore;
namespace OneDay.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        public DbSet<Floria Entity> Florias {get; set; }
    }
}
