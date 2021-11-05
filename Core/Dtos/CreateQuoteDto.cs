using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class CreateQuoteDto
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }
        public Guid NurseId { get; set; }
        public Guid DoctorId { get; set; }
        public string Hour { get; set; }
        public List<DoctorDto> Doctors { get; set; }
        public Guid MedicalHistory { get; set; }
    }
}
