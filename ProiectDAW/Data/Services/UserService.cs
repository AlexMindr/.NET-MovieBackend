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

namespace ProiectDAW.Services
{
    public class UserService : IUserService
    {

        public ProjectContext _ProjectContext;
        private IJWTUtils _iJWtUtils;
        private readonly AppSettings _appSettings;

        public UserService(ProjectContext ProjectContext, IJWTUtils iJWtUtils, IOptions<AppSettings> appSettings)
        {
            _ProjectContext = ProjectContext;
            _iJWtUtils = iJWtUtils;
            _appSettings = appSettings.Value;
        }


        public UserResponseDTO Authentificate(UserRequestDTO model)
        {
            var user = _ProjectContext.Users.FirstOrDefault(x => x.Username == model.Username);

            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; //or throw exception
            }

            // jwt generation
            var jwtToken = _iJWtUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
