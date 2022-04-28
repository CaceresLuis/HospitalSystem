using System;
using System.Collections.Generic;

namespace Core.Dtos
{
    public class NurseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Document { get; set; }
        public string Adresss { get; set; }
        public string Phone { get; set; }
        public ICollection<QuoteDto> Quotes { get; set; }
    }
}
