using Microsoft.AspNetCore.Identity;

namespace FPTStore.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string? Descriptions;
    }
}
