namespace Venhancer.Crowd.Identity.Core.Models
{
    public class UserRefreshToken
    {
        public string? UserId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }

    }
}
