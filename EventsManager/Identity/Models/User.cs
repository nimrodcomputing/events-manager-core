using Microsoft.AspNetCore.Identity;

namespace EventsManager.Identity.Models
{
    public class User : IdentityUser
    {
        public string Surname { get; set; }

        public string Forename { get; set; }

    }

}