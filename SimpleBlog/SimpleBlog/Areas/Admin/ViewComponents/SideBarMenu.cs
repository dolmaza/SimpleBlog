using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Areas.Admin.ViewModels;
using System.Collections.Generic;

namespace SimpleBlog.Areas.Admin.ViewComponents
{
    public class SideBarMenu : ViewComponent
    {
        public SideBarMenu()
        {

        }

        public IViewComponentResult Invoke()
        {
            var model = new SideBarMenuViewModel
            {
                MenuItems = new List<SideBarMenuViewModel.MenuItem>
                {

                }
            };

            return View(model);
        }
    }
}
