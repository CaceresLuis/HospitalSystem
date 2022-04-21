using System;

namespace Infrastructure.Data.Entities
{
    public class ConsultoringRoom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
