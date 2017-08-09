using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BaseAdminController : Controller
    {
    }
}
