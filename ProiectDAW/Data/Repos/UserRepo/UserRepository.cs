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
        protected readonly DbSet<Role> _roles;
        public UserRepository(ProjectContext context) : base(context)
        {

        }

        public User GetForAuth(object username)
        {
            return (User)_table.Where(x => x.Username.Equals((string)username))
                         .Select(x => new { x.Id,x.FirstName,x.LastName,x.PasswordHash,x.Username});
        }

        public string GetUserRole(object id)
        {
            var table = _table.Join(_roles, x => x.RoleId, y => y.Id, (x, y) => new
            {
                x.Id,
                y.Name
            });

            var res = table.Where(x => x.Id.Equals(id))
                           .Select(x=>x.Name).ToList();
            return res[0];
        }
    }
}
