using ProiectDAW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.Models.Entities;

namespace ProiectDAW.Utilities.Attributes
{
    public class AuthorizationAttribute: Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;
        public AuthorizationAttribute(params string[] roles)
        {
            _roles = roles;
            
            
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusCodeObject = new JsonResult(new { Message = "Unauthorized" })
            { StatusCode = StatusCodes.Status401Unauthorized };
            

            // might not be necessary to check the role; some endpoints just need authorization
            if( _roles == null)
            {
                context.Result = unauthorizedStatusCodeObject;
            }

            var user = (User)context.HttpContext.Items["User"];
            /*if (user.RoleId == 1) user.Role.Name = "Admin";
            else user.Role.Name = "User";*/
            //Console.Write(_roles.Contains(user.Role.Name));
            if(user == null || !_roles.Contains(user.Role.Name))
            {
                context.Result = unauthorizedStatusCodeObject;
            }

        }
    }
}
