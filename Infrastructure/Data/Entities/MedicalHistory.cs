using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    public class MedicalHistory
    {
        [Key]
        public Guid Expedient { get; set; }
        public DateTime DateTime { get; set; }
        public string MotiveQuote { get; set; }
        public string Diagnosis { get; set; }
        public string Recipe { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}
