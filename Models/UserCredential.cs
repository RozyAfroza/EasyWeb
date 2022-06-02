using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProject.Models
{
    [Table("UserCredential")]
    public class UserCredential : BaseEntity
    {
        [Key]
        public long EntityId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int UserTypeID { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public int LoginFailedAttemptCount { get; set; }
        public DateTime? LastLoginFailedAttemptDate { get; set; }

        public bool IsActive { get; set; }  
    }
}
