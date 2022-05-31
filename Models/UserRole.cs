namespace LearningProject.Models
{
    public class UserRole : BaseEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

    }
}
