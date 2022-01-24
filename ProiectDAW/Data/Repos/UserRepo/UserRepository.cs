using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using ProiectDAW.Models.Entities;
using ProiectDAW.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.UserRepo
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {

        }

        public User GetForAuth(object username)
        {   
            var res= _table.Where(x => x.Username.Equals((string)username))
                         .Select(x=>new { x.Id,x.Username,x.PasswordHash,x.FirstName,x.LastName,x.Role})
                         .FirstOrDefault();
            
            if (res != null) 
            {
                return new User
                {
                    Id = res.Id,
                    Username = res.Username,
                    PasswordHash = res.PasswordHash,
                    FirstName = res.FirstName,
                    LastName = res.LastName,
                    Role=res.Role
                };
            }
            return null;
        }

        

        public string GetUserRole(object id) 
        {
            var res = _table.Where(x => x.Id.Equals(id))
                  .Select(x => x.Role).ToList();

            return res[0];
        }

    }
}
