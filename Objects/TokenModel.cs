using System;

namespace LearningProject.Objects
{
    public class TokenModel
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public int UserTypeID { get; set; }
        public Guid ID { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpireAfterUtc { get; set; }
    }
}
