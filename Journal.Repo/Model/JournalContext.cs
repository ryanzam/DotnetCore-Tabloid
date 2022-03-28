using Microsoft.EntityFrameworkCore;

namespace Journal.Repository.Model
{
    public class JournalContext : DbContext
    {
        public JournalContext(DbContextOptions<JournalContext> opt) : base(opt)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
               .Property(p => p.CreatedOn)
               .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .HasMaxLength(40)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.CreatedOn)
                .HasDefaultValueSql("getdate()");
        }
    }
}
