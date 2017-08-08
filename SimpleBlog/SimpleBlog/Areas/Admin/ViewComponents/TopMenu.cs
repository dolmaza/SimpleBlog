using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Areas.Admin.ViewComponents
{
    public class TopMenu : ViewComponent
    {
        public TopMenu()
        {

        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
