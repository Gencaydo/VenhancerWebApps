
using Microsoft.AspNetCore.Identity;

namespace Venhancer.Crowd.Core.Models
{
    public class UserApp:IdentityUser
    {
        public string? City { get; set; }
    }
}
