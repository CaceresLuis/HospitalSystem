using System;

namespace Infrastructure.Data.Entities
{
    public class Quote
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public Nurse Nurse { get; set; }
        public Doctor Doctor { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
    }
}
