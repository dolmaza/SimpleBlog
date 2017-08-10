using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Areas.Admin.SubmitModels;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Data.Entities;
using SimpleBlog.Services.Admin;
using System.Threading.Tasks;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private SignInManager<User> _signInManager;
        private IUserService _userService;

        public AuthController(SignInManager<User> signInManager, IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
        }

        public ViewResult Login()
        {
            var model = new LoginViewModel
            {
                LoginUrl = Url.RouteUrl("adminLogin")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginSubmitModel submitModel)
        {
            var user = _userService.GetByUserNameAndPassword(submitModel.UserName, submitModel.Password);
            if (user == null)
            {
                var model = new LoginViewModel
                {
                    LoginUrl = Url.RouteUrl("adminLogin"),
                    UserName = submitModel.UserName,
                    HasError = true,
                    ErrorMessage = "Username or password is not correct"
                };
                return View(model);
            }
            else
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToRoute("adminDashboard");
            }


        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToRoute("adminLogin");
        }
    }
}
