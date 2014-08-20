using System.Data.Entity;

namespace ShortUrlWebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<ShortUrl> ShortUrls;
    }

    public class ShortUrl
    {
        public int Id { get; set; }
        public string Original { get; set; }
        public string User { get; set; }
        public string Hash { get; set; }
    }
}