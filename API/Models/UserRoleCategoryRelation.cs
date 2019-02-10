namespace API.Models
{
    public class UserRoleCategoryRelation
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleCategoryId { get; set; }
        public RoleCategory RoleCategory { get; set; }
    }
}