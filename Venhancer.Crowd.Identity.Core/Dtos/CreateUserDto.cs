namespace Venhancer.Crowd.Identity.Core.Dtos
{
    public class CreateUserDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
