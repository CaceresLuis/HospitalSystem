using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }

        [MaxLength(60)]
        public string FullName { get; set; }
        [MaxLength(15)]
        public string Document { get; set; }
        [MaxLength(200)]
        public string Adresss { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
    }
}
