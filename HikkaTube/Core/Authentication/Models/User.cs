namespace Core.Authentication.Models
{
    public class User
    {
        public System.Guid Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
