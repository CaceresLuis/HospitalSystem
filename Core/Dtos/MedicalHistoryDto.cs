using System;
using System.Collections.Generic;

namespace Core.Dtos
{
    public class MedicalHistoryDto
    {
        public Guid Expedient { get; set; }
        public DateTime DateTime { get; set; }
        public string MotiveQuote { get; set; }
        public string Diagnosis { get; set; }
        public string Recipe { get; set; }
        public PatientsDto Patient { get; set; }
        public DoctorDto Doctor { get; set; }
        public ICollection<QuoteDto> Quotes { get; set; }
    }
}
