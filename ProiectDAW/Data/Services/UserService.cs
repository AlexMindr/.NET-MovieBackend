using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Utilities;
using ProiectDAW.Utilities.JWTUtilis;
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
        private IJWTUtils _iJWtUtils;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository users, IJWTUtils iJWtUtils, IOptions<AppSettings> appSettings)
        {
            _users = users;
            _iJWtUtils = iJWtUtils;
            _appSettings = appSettings.Value;
        }


        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user  = _users.GetForAuth(model.Username);
            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; //or throw exception
            }

            // jwt generation
            var jwtToken = _iJWtUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, jwtToken);
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

        public async Task Create(UserRegisterDTO user)
        {
            var usr = new User
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = BCryptNet.HashPassword(user.Password),
                RoleId = 2

            };
            await _users.CreateAsync(usr);
            await _users.SaveAsync();
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
