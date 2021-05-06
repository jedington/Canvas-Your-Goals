using Microsoft.EntityFrameworkCore;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class AppDbContext : DbContext
    {
        // fields
        public DbSet<User> Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<VisionBoard> VisionBoards { get; set; }
        

        // constructors
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        } // AppDbContext const ends


        // methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            modelBuilder.Entity<User>().HasData(new User { 
                UserId = 1, 
                Email = "johnnybravo@example.com", 
                Password = "wakkawakkawakka", 
                SecurityHint = "hint",
                SecurityAnswer = "answer", 
                IsAdmin = false
            });
        } // OnModelCreating method ends
    } // class ends
} // namespace ends
