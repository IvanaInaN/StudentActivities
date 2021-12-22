using System;

namespace FormActions.Structures.Dtos
{
    public class FormActionDto
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int FormId { get; set; }
        public string Action { get; set; }
        public DateTime ActionOn { get; set; }
        public int WaitingTimeMin { get; set; }
        public CandidateDto Candidate { get; set; }
        public FormDto Form { get; set; }
    }
}
