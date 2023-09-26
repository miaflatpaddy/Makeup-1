
using Microsoft.AspNetCore.Identity;

namespace MakeupClassLibrary.DomainModels
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
