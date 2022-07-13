using Microsoft.EntityFrameworkCore;
namespace OneDay.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<FloriaEntity> Florias { get; set; }

    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<JalenEntity> Jalens { get; set; }
}
