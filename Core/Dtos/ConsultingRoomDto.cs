using System;

namespace Core.Dtos
{
    public class ConsultingRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
