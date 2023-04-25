using Microsoft.AspNetCore.Identity;

namespace FinalASP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Role{ get; set; }
    }
}
