using Microsoft.AspNetCore.Identity;

namespace UserIdentity.Models
{
    public class AppUser : IdentityUser{
        public string FullName {get; set;} = string.Empty;
    }
}