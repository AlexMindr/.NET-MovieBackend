using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Services
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        Task<IEnumerable<User>> GetAllUsers();
        User GetById(Guid id);
        string GetRole(Guid id);
        bool Create(UserRegisterDTO user);
        void Update(UserUpdateDTO user);
        void Delete(Guid id);
    }
}
