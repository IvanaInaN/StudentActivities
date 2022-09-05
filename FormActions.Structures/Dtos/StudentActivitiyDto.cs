using System;

namespace StudentActivities.Structures.Dtos
{
    public class StudentActivitiyDto
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int FormId { get; set; }
        public string Action { get; set; }
        public DateTime ActionOn { get; set; }
        public StudentDto Student { get; set; }
        public FormDto Form { get; set; }
    }
}
