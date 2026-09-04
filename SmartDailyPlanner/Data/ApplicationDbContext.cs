using Microsoft.EntityFrameworkCore;
using SmartDailyPlanner.Models;

namespace SmartDailyPlanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {    
        }
        public DbSet<PlannerTask> PlannerTasks { get; set; }
    }
}
