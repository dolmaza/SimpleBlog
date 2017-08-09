using System.Collections.Generic;

namespace SimpleBlog.Areas.Admin.ViewModels
{
    public class TopMenuViewModel
    {
        #region Properties

        public List<MenuItem> MenuItems { get; set; }

        #endregion

        #region Sub Classes

        public class MenuItem
        {
            #region Properties

            public string Caption { get; set; }
            public string Url { get; set; }
            public string Icon { get; set; }
            public bool IsActive { get; set; }
            public bool HasNextLevelMenuItems => MenuItems?.Count > 0;

            public List<MenuItem> MenuItems { get; set; }

            #endregion
        }

        #endregion
    }
}
