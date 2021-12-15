using System;

namespace FormActions.Domain.Models
{
    public class FormAction
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int FormId { get; set; }
        public string Action { get; set; }
        public DateTime ActionOn { get; set; }
        public Candidate Candidate { get; set; }
        public Form Form { get; set; }
    }
}
