using Microsoft.EntityFrameworkCore;
namespace OneDay.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<PostEntity> Posts { get; set; }
}
