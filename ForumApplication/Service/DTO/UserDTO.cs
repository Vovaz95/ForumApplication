namespace ForumApplication.Service.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
    }
}