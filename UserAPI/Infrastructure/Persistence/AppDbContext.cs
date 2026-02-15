using Microsoft.EntityFrameworkCore;
using System.Data;
using UserAPI.Domain.Models;

namespace UserAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<User> UserTable { get; set; }
        public DbSet<DailyEntry> DailyEntryTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<User>()
               .HasMany(u => u.DailyEntry)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
