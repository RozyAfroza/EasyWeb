using System;

namespace LearningProject.Models
{
    public class RefreshToken
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string ProtectedTicket { get; set; }
    }
}
