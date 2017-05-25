using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrophyFish.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Fish> Fishes { get; set; }

        public DbSet<UserStatusDict> UserStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Fishes).WithOne(f => f.User);
            modelBuilder.Entity<ApplicationUser>().HasOne(u => u.Status);

            modelBuilder.Entity<Fish>().ToTable("Fish");
            modelBuilder.Entity<Fish>().Property(f => f.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Fish>().HasOne(f => f.User).WithMany(u => u.Fishes);
            modelBuilder.Entity<Fish>().HasOne(f => f.Specie);

            modelBuilder.Entity<UserStatusDict>().ToTable("UserStatusDict");
        }
    }
}
