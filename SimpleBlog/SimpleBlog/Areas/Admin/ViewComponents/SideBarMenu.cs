using Microsoft.ApplicationInsights.AspNetCore.Extensions;
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
                    new SideBarMenuViewModel.MenuItem
                    {
                        Caption = "Dashboard",
                        Icon = "fa fa-dashboard",
                        Url = Url.RouteUrl("adminDashboard"),
                        IsActive = Request.GetUri().AbsolutePath ==Url.RouteUrl("adminDashboard")
                    },
                    new SideBarMenuViewModel.MenuItem
                    {
                        Caption = "Users",
                        Icon = "fa fa-users",
                        Url = Url.RouteUrl("adminUsers"),
                        IsActive = Request.GetUri().AbsolutePath ==Url.RouteUrl("adminUsers")
                    },

                    new SideBarMenuViewModel.MenuItem
                    {
                        Caption = "Categories",
                        Icon = "fa fa-list",
                        Url = Url.RouteUrl("adminCategories"),
                        IsActive = Request.GetUri().AbsolutePath == Url.RouteUrl("adminCategories")
                    }
                }
            };

            return View(model);
        }
    }
}
