﻿using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.Manager;
using ASI.Basecode.Services.ServiceModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ASI.Basecode.Resources.Constants.Enums;

namespace ASI.Basecode.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public List<User> GetAllUsers()
        {
            return _repository.GetUsers().ToList();
        }

        public User GetUserById(string userId)
        {
            return _repository.GetUsers().FirstOrDefault(u => u.UserId == userId);
        }

        public void UpdateUser(User user)
        {
            _repository.UpdateUser(user);
        }

        public void ResetPassword(string userId, string newPassword)
        {
            var user = _repository.GetUsers().FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.Password = PasswordManager.EncryptPassword(newPassword);
                _repository.UpdateUser(user);
            }
        }

        public void DeleteUser(string userId)
        {
            var user = _repository.GetUsers().FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                _repository.DeleteUser(user);
            }
        }

        public LoginResult AuthenticateUser(string userId, string password, ref User user)
        {
            user = new User();
            var passwordKey = PasswordManager.EncryptPassword(password);
            user = _repository.GetUsers().Where(x => x.UserId == userId &&
                                                     x.Password == passwordKey).FirstOrDefault();

            return user != null ? LoginResult.Success : LoginResult.Failed;
        }

        public void AddUser(UserViewModel model)
        {
            var user = new User();
            if (!_repository.UserExists(model.UserId))
            {
                _mapper.Map(model, user);
                user.Password = PasswordManager.EncryptPassword(model.Password);
                user.CreatedTime = DateTime.Now;
                user.UpdatedTime = DateTime.Now;
                user.CreatedBy = System.Environment.UserName;
                user.UpdatedBy = System.Environment.UserName;
                user.Email = model.Email;
                user.Role = model.Role;

                _repository.AddUser(user);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }
    }
}
