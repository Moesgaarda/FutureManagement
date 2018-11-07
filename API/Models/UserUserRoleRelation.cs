namespace API.Models
{
    public class UserUserRoleRelation
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}