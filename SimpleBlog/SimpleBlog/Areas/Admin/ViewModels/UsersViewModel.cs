using System.Collections.Generic;

namespace SimpleBlog.Areas.Admin.ViewModels
{
    public class UsersViewModel
    {
        #region Properties

        public List<UserItem> UserItems { get; set; }

        #endregion

        #region Sub Classes

        public class UserItem
        {
            #region Properties

            public string UserName { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public bool IsActive { get; set; }

            #endregion
        }

        #endregion
    }
}
