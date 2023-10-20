
using Microsoft.AspNetCore.Identity;

namespace MakeupClassLibrary.DomainModels
{
    public class User : IdentityUser
    {
        public int YearOfBirth { get; set; }
    }
}
