
using Microsoft.AspNetCore.Identity;

namespace Venhancer.Crowd.Identity.Core.Models
{
    public class UserApp:IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
