namespace API.Dtos
{
    public class UserForLoginDto
    {
        public UserForLoginDto(string Username, string Password){
            this.Username = Username;
            this.Password = Password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}