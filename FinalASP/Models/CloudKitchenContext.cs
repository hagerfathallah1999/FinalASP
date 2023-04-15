using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalASP.Models
{
    public class CloudKitchenContext : IdentityDbContext<ApplicationUser>   
    {
        public CloudKitchenContext() : base() { }
        public CloudKitchenContext(DbContextOptions options) : base(options) { }
    }
}
