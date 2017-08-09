using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Areas.Admin.ViewModels;
using System.Collections.Generic;

namespace SimpleBlog.Areas.Admin.ViewComponents
{
    public class TopMenu : ViewComponent
    {
        public TopMenu()
        {

        }

        public IViewComponentResult Invoke()
        {
            var model = new TopMenuViewModel
            {
                MenuItems = new List<TopMenuViewModel.MenuItem>
                {
                    new TopMenuViewModel.MenuItem
                    {
                        Icon = "fa fa-cogs",
                        MenuItems = new List<TopMenuViewModel.MenuItem>
                        {
                            new TopMenuViewModel.MenuItem
                            {
                                Caption = "Back to website",
                                Icon = "fa fa-globe",
                                Url = "#"
                            },
                            new TopMenuViewModel.MenuItem
                            {
                                Caption = "Logout",
                                Icon = "fa fa-sign-out",
                                Url = Url.RouteUrl("adminLogout")
                            }
                        }
                    }
                }
            };
            return View(model);
        }
    }
}
