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
        UserResponseDTO Authentificate(UserRequestDTO model);
        IEnumerable<User> GetAllUsers();
        User GetById(Guid id);
    }
}
