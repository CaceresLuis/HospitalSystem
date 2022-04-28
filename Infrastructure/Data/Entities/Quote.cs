using System;

namespace Infrastructure.Data.Entities
{
    public class Quote
    {
        public Guid Id { get; set; }
        public Nurse Nurse { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public Reservation Reservation { get; set; }
    }
}
