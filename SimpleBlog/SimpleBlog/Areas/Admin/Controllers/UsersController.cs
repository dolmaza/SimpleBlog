using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Areas.Admin.SubmitModels;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Services.Admin;
using System.Linq;

namespace SimpleBlog.Areas.Admin.Controllers
{
    public class UsersController : BaseAdminController
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
                UserCreateUrl = Url.RouteUrl("adminUsersCreate"),
                UserItems = _userService.GetAll(Url).ToList()
            };

            return View(model);
        }

        public ViewResult Create()
        {
            var model = new UsersCreateViewModel
            {
                SaveUrl = Url.RouteUrl("adminUsersCreate"),
                UsersListUrl = Url.RouteUrl("adminUsers")
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(UserCreateSubmitModel submitModel)
        {
            var userId = _userService.Add(submitModel);

            if (_userService.IsError)
            {
                var model = new UsersCreateViewModel
                {
                    UserName = submitModel.UserName,
                    Email = submitModel.Email,
                    Firstname = submitModel.Firstname,
                    Lastname = submitModel.Lastname,
                    IsActive = submitModel.IsActive,

                    SaveUrl = Url.RouteUrl("adminUsersCreate"),
                    UsersListUrl = Url.RouteUrl("adminUsers")
                };
                return View(model);
            }
            else
            {
                return RedirectToRoute("adminUsersEdit", new { id = userId });
            }
        }

        public IActionResult Edit(int? id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return RedirectToRoute("adminUsers");
            }
            else
            {
                var model = new UsersEditViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    UserName = user.UserName,
                    IsActive = user.IsActive,

                    SaveUrl = Url.RouteUrl("adminUsersEdit"),
                    UsersListUrl = Url.RouteUrl("adminUsers")
                };
                return View(model);
            }

        }

        [HttpPost]
        public IActionResult Edit(UserUpdateSubmitModel submitModel)
        {
            _userService.Update(submitModel);

            if (_userService.IsError)
            {
                var model = new UsersEditViewModel
                {
                    Id = submitModel.Id,
                    UserName = submitModel.UserName,
                    Email = submitModel.Email,
                    Firstname = submitModel.Firstname,
                    Lastname = submitModel.Lastname,
                    IsActive = submitModel.IsActive,

                    SaveUrl = Url.RouteUrl("adminUsersEdit", new { id = submitModel.Id }),
                    UsersListUrl = Url.RouteUrl("adminUsers")
                };
                return View(model);
            }
            else
            {
                return RedirectToRoute("adminUsersEdit", new { id = submitModel.Id });
            }
        }

        public IActionResult Delete(int? id)
        {
            _userService.Delete(id);
            return RedirectToRoute("adminUsers");
        }
    }
}
