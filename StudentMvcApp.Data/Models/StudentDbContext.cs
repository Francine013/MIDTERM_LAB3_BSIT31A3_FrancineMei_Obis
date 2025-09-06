using Microsoft.EntityFrameworkCore;
using StudentMvcApp.Entities.Models;


namespace StudentMvcApp.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        // Optional: kung may special config ka
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
