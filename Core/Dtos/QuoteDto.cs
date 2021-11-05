using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class QuoteDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public NurseDto Nurse { get; set; }
        public DoctorDto Doctor { get; set; }
        public MedicalHistoryDto MedicalHistory { get; set; }
        public bool IsActive { get; set; }
        public string Hour { get; set; }

        [Range(1, 40, ErrorMessage = "Rating must between 1 to 40")]
        public int QuoteTotal { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must between 1 to 5")]
        public int Quotehour { get; set; }
    }
}
