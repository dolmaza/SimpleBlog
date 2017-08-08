using SimpleBlog.Areas.Admin.SubmitModels;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Data.Entities;
using SimpleBlog.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlog.Services
{
    public interface IUserService
    {
        bool IsError { get; set; }
        IEnumerable<UsersViewModel.UserItem> GetAll();
        User GetById(int? id);

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
                PasswordHash = userSubmitModel.Password,
                IsActive = userSubmitModel.IsActive
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

        public IEnumerable<UsersViewModel.UserItem> GetAll()
        {
            return _userRepository.GetAll().Select(u => new UsersViewModel.UserItem
            {
                UserName = u.UserName,
                Email = u.Email,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                IsActive = u.IsActive
            });
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
                user.IsActive = userSubmitModel.IsActive;

                _userRepository.Complate();
                IsError = _userRepository.IsError;
            }
        }

    }
}
