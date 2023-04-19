using Lemon_d.local.Database.DbModels.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lemon_d.local.Database.DbModels
{
    public class MasterDbContext : IdentityDbContext<AppUser>
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectList> Lists { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>()
                .HasOne(e => e.CurrentlyPlaying)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AppUser>()
                .HasOne(e => e.MostWanted)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AppUser>()
                .HasOne(e => e.Favourite)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AppUser>()
                .HasOne(e => e.PlatformsOwned)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
