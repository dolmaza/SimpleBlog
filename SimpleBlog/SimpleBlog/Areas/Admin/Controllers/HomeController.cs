using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public ViewResult Dashboard()
        {
            return View();
        }
    }
}
