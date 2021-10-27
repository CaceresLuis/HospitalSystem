using System;

namespace Core.Dtos
{
    public class QuoteDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public NurseDto Nurse { get; set; }
        public DoctorDto Doctor { get; set; }
        public MedicalHistoryDto MedicalHistory { get; set; }
    }
}
