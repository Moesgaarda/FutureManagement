namespace API.Dtos
{
    /// <summary>
    /// This DTO is used when getting an item, since this has a user
    /// attached to it.
    /// </summary>
    public class UserForItemGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set;}
        public string Surname{ get; set; }
    }
}