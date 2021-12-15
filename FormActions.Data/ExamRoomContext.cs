using FormActions.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FormActions.Data
{
    public class ExamRoomContext : DbContext
    {
        public ExamRoomContext(DbContextOptions<ExamRoomContext> options) : base(options)
        {
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormAction> FormActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<Form>().ToTable("Form");
            modelBuilder.Entity<FormAction>().ToTable("FormAction");
        }
    }
}
