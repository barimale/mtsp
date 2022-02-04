using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTSP.Database.SQLite.Entries;
using System.Reflection;

namespace MTSP.Database.SQLite
{
    public sealed class GifterDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public GifterDbContext(DbContextOptions<GifterDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<EventEntry> Events { get; set; }
        public DbSet<ParticipantEntry> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
