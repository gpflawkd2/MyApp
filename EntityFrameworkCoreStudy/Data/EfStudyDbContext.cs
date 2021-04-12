using EntityFrameworkCoreStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreStudy.Data
{
    public class EfStudyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AspnetNoteDb;User Id=Board;Password=phr8611!;");
        }

        
        // Model-Class Mapping
        // 2) DBContext -> OnModelCreating() -> EF Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO Code
            //modelBuilder.Entity<User>().ToTable("s_users");
            //modelBuilder.Entity<User>().Property(p => p.UserName).HasColumnName("s_userName");
        }
    }
}
