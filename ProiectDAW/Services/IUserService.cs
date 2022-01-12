using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services
{
    public interface IUserService
    {
        UserResponseDTO Authentificate(UserRequestDTO model);
        IEnumerable<User> GetAllUsers();
        User GetById(Guid id);
    }
}
