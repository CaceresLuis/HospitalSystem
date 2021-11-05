using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    public class Quote
    {
        public Guid Id { get; set; }
        public Nurse Nurse { get; set; }
        public string Hour { get; set; }
        public Doctor Doctor { get; set; }
        [Range(1, 40, ErrorMessage = "Rating must between 1 to 40")]
        public int QuoteTotal { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must between 1 to 5")]
        public int Quotehour { get; set; }
        public DateTime DateTime { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public bool IsActive { get; set; }
    }
}
