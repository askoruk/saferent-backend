using System;

namespace SafeRent.DataAccess.Models
{
    public class AccessKey
    {
        public string Key { get; set; }
        public string IssueDate { get; set; }
        public Guid Issuer { get; set; }
        public Guid Bearer { get; set; }
        public string Expiration { get; set; }
        public bool IsActive { get; set; }
    }
}