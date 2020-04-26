using System;

namespace SafeRent.DataAccess.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Message { get; set; }
        public string DateSend { get; set; }
    }
}