using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Areas.Admin.SubmitModels;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Data.Entities;
using SimpleBlog.Data.Repositories;
using SimpleBlog.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlog.Services.Admin
{
    public interface IUserService : IBaseService
    {
        IEnumerable<UsersViewModel.UserItem> GetAll(IUrlHelper url);
        User GetById(int? id);
        User GetByUserNameAndPassword(string userName, string password);

        int? Add(UserCreateSubmitModel userSubmitModel);
        void Update(UserUpdateSubmitModel userSubmitModel);
        void Delete(int? id);
    }

    public class UsersService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public bool IsError { get; set; }

        public UsersService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public int? Add(UserCreateSubmitModel userSubmitModel)
        {
            var user = new User
            {
                Firstname = userSubmitModel.Firstname,
                Lastname = userSubmitModel.Lastname,
                Email = userSubmitModel.Email,
                UserName = userSubmitModel.UserName,
                PasswordHash = userSubmitModel.Password?.ToMD5(),
                IsActive = userSubmitModel.IsActive,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            _userRepository.Add(user);
            _userRepository.Complate();
            IsError = _userRepository.IsError;

            return user.Id;
        }

        public void Delete(int? id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Remove(user);
            _userRepository.Complate();
            IsError = _userRepository.IsError;

        }

        public IEnumerable<UsersViewModel.UserItem> GetAll(IUrlHelper url)
        {
            var users = _userRepository.GetAllAsync().Result.ToList();
            return users.Select(u => new UsersViewModel.UserItem
            {
                UserName = u.UserName,
                Email = u.Email,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                IsActive = u.IsActive,

                UpdateUrl = url.RouteUrl("adminUsersEdit", new { id = u.Id }),
                DeleteUrl = url.RouteUrl("adminUsersDelete", new { id = u.Id })
            }).ToList();
        }

        public User GetById(int? id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(UserUpdateSubmitModel userSubmitModel)
        {
            var user = _userRepository.GetById(userSubmitModel.Id);
            if (user == null)
            {
                IsError = true;
            }
            else
            {
                user.Firstname = userSubmitModel.Firstname;
                user.Lastname = userSubmitModel.Lastname;
                user.Email = userSubmitModel.Email;
                user.UserName = userSubmitModel.UserName;
                user.PasswordHash = string.IsNullOrWhiteSpace(userSubmitModel.Password) ? user.PasswordHash : userSubmitModel.Password.ToMD5();
                user.IsActive = userSubmitModel.IsActive;

                _userRepository.Complate();
                IsError = _userRepository.IsError;
            }
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userRepository.GetOne(u => u.UserName == userName && u.PasswordHash == password.ToMD5() && u.IsActive);
        }
    }
}
