using Microsoft.EntityFrameworkCore;

namespace URLShortner.Models
{
    public class URLContext : DbContext
    {
        public URLContext(DbContextOptions options) : base(options) { }
        public DbSet<URL> URLs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I7PU4G3;Database=URLShortner;Trusted_Connection=True;Encrypt=false");
        }
    }
}
