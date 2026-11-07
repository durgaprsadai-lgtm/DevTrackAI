using DevTrackAI.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTrackAI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Learning> Learnings { get; set; }
    }
}