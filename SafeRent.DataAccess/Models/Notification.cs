using System;

namespace SafeRent.DataAccess.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string DateSend { get; set; }
    }
}