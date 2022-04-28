using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public bool IsActive { get; set; }
        public DoctorDto Doctor { get; set; }
        public ICollection<QuoteDto> Quotes { get; set; }

        [Range(1, 40, ErrorMessage = "Rating must between 1 to 40")]
        public int QuoteTotal { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must between 1 to 5")]
        public int QuoteByhour { get; set; }
    }
}
