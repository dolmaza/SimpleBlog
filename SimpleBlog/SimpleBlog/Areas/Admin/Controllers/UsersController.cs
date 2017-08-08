using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Services;
using System.Linq;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public ViewResult UsersList()
        {
            var model = new UsersViewModel
            {
                UserItems = _userService.GetAll().ToList()
            };

            return View(model);
        }
    }
}
