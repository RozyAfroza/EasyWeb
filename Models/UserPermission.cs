using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProject.Models
{
    [Table("usr_UserPermission")]
    public class UserPermission
    {
        [Key]
        public long EntityId { get; set; }
        public int PermissionNo { get; set; }
        public long UserId { get; set; }


    }
}
