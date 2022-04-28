using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Doctor Doctor { get; set; }
        public Schedule Schedule { get; set; }
        public string ConsultingRoom { get; set; }
        public ICollection<Quote> Quotes { get; set; }

        [MaxLength(40, ErrorMessage = "The maximum amount of patients is 40")]
        public int QuoteTotal { get; set; }
    }
}
