using Microsoft.AspNetCore.Identity;

namespace WebFrontToBack.Models.Auth
{
    public class AppRole:IdentityRole
    {
        public bool IsAvtivated { get; set; }
    }
}
