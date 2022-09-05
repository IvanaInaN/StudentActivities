using Microsoft.EntityFrameworkCore;
using StudentActivities.Domain.Models;

namespace StudentsActivities.Data
{
    public class StudentActivityContext : DbContext
    {
        public StudentActivityContext(DbContextOptions<StudentActivityContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<StudentActivity> StudentActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Form>().ToTable("Form");
            modelBuilder.Entity<StudentActivity>().ToTable("StudentActivity");
        }
    }
}
