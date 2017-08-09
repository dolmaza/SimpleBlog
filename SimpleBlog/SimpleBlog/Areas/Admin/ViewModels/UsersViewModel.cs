using System.Collections.Generic;

namespace SimpleBlog.Areas.Admin.ViewModels
{
    public class UsersViewModel
    {
        #region Properties

        public string UserCreateUrl { get; set; }
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

            public string UpdateUrl { get; set; }
            public string DeleteUrl { get; set; }
            #endregion
        }

        #endregion
    }

    public class UsersCreateViewModel
    {
        #region Properties

        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public string SaveUrl { get; set; }
        public string UsersListUrl { get; set; }

        #endregion
    }

    public class UsersEditViewModel
    {
        #region Properties

        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public string SaveUrl { get; set; }
        public string UsersListUrl { get; set; }

        #endregion
    }
}
