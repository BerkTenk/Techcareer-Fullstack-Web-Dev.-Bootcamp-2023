using Microsoft.AspNetCore.Identity;

namespace UserIdentity.Models
{
    public class AppRole : IdentityRole{
        public string FullName {get; set;} = string.Empty;
    }
}