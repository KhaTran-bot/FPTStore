using Microsoft.AspNetCore.Identity;

namespace FPTStore.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }

    }
}
