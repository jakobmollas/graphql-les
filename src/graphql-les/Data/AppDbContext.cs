using graphql_les.Models;
using Microsoft.EntityFrameworkCore;

namespace graphql_les.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(n => n.Commands)
                .WithOne(n => n.Platform!)
                .HasForeignKey(n => n.PlatformId);

            modelBuilder
                .Entity<Command>()
                .HasOne(n => n.Platform!)
                .WithMany(n => n.Commands)
                .HasForeignKey(n => n.PlatformId);
        }
    }
}
