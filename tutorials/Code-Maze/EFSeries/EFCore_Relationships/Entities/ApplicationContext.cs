using Microsoft.EntityFrameworkCore;
using Entities.Configuration;

namespace Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {

        }

        // This Method use to configure Entity via the Fluen API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());
        }

        public DbSet<Student> Students { get; set; }
    }
}
