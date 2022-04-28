using System;
using System.Collections.Generic;

namespace Core.Dtos
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ReservationDto> Reservations { get; set; }
    }
}
