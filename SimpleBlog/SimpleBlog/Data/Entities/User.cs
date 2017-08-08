using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SimpleBlog.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public User()
        {

        }
    }
}
