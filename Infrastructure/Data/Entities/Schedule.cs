using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
