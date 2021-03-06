using Microsoft.EntityFrameworkCore;
namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }
        
        public DbSet<EasyData> Easy { get; set; }
    }
}