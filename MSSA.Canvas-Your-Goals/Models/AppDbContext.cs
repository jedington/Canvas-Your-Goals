using Microsoft.EntityFrameworkCore;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class AppDbContext : DbContext
    {
        // fields
        public DbSet<User> Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<VisionBoard> VisionBoards { get; set; }
        

        // constructors
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        } // AppDbContext const ends


        // methods


    } // class ends
} // namespace ends
