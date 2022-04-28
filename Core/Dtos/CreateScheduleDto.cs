using System;
using System.Collections.Generic;

namespace Core.Dtos
{
    public class CreateScheduleDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Init { get; set; }
        public string End { get; set; }
        public string Hour => $"Init At :{Init}, End At {End}";
        public bool IsActive { get; set; }
        public ICollection<ReservationDto> Reservations { get; set; }
    }
}
