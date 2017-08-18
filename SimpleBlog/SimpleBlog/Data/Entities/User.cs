using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }

        public User()
        {

        }
    }
}
