using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.Models.Entities;
using ProiectDAW.Data.Repos.UserRepo;

namespace ProiectDAW.Data.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _users;
        

        public UserService(IUserRepository users)
        {
            _users = users;
        
        }


        public User Authenticate(UserAuthDTO model)
        {
            var user  = _users.GetForAuth(model.Username);
            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; //or throw exception
            }

            
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _users.GetAll();
        }

        public User GetById(Guid id)
        {
            return _users.FindById(id);
        }

        public string GetRole(Guid id)
        {
            return _users.GetUserRole(id);
        }

        public bool Create(UserRegisterDTO user)
        {
            var searchus = _users.GetForAuth(user.Username);
            if (searchus == null) {
                var usr = new User
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PasswordHash = BCryptNet.HashPassword(user.Password),
                    Role = "User"

                };
                 _users.CreateAsync(usr);
                 _users.SaveAsync();
                return true;
            }
            return false;
            
            
        }

        public void Update(UserUpdateDTO user)
        {
            var update=_users.GetForAuth(user.Username);
            update.FirstName = user.FirstName;
            update.LastName = user.LastName;
            _users.Update(update);
            _users.Save();
            
        }

        public void Delete(Guid id)
        {
            var del=_users.FindById(id);
            _users.Delete(del);
            _users.Save();
        }
    }
}
