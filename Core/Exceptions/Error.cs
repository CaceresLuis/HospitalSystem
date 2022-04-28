using Core.Enums;

namespace Core.Exceptions
{
    public class Error
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public State State { get; set; }
    }
}
