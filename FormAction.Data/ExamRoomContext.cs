using FormActions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace FormAction.Data
{
    public class ExamRoomContext : DbContext
    {
        public ExamRoomContext(DbContextOptions<ExamRoomContext> options) : base(options)
        {
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormActions.Domain.Models.FormAction> FormActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<Form>().ToTable("Form");
            modelBuilder.Entity<FormActions.Domain.Models.FormAction>().ToTable("FormAction");
        }
    }
}
