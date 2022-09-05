using System;

namespace StudentActivities.Domain.Models
{
    public class StudentActivity
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int FormId { get; set; }
        public string Action { get; set; }
        public DateTime ActionOn { get; set; }
        public Student Student { get; set; }
        public Form Form { get; set; }
    }
}
