using System;

namespace Core.Dtos
{
    public class PatientsDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Document { get; set; }
        public string Adresss { get; set; }
        public string Phone { get; set; }
    }
}
