using System;

namespace Infrastructure.Data.Entities
{
    public class DoctorConsultoringRoom
    {
        public Guid Id { get; set; }
        public int QuoteTotal { get; set; }
        public string Schedule { get; set; }
        public DateTime Date { get; set; }
        public bool IsAvailable { get; set; }
        public Doctor Doctor { get; set; }
        public ConsultoringRoom ConsultoringRoom { get; set; }
    }
}
