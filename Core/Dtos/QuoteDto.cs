using System;

namespace Core.Dtos
{
    public class QuoteDto
    {
        public Guid Id { get; set; }
        public NurseDto Nurse { get; set; }
        public ReservationDto Reservation { get; set; }
        public MedicalHistoryDto MedicalHistory { get; set; }
    }
}
