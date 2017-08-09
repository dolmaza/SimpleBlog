using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public ViewResult Dashboard()
        {
            return View();
        }
    }
}
