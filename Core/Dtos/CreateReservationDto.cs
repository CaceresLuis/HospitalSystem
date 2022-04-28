using System;
using System.Collections.Generic;

namespace Core.Dtos
{
    public class CreateReservationDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public Guid Doctor { get; set; }
        public ICollection<DoctorDto> DoctorDtos { get; set; }
    }
}
