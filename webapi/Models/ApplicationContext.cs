using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options):base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
