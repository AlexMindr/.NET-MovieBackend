using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Create(UserRegisterDTO user)
        {
            var usr=_userService.Create(user);
            if (usr == true)
                return Ok(usr);
            else
                return BadRequest(new { Message = "Username already taken!" });
        }

        [Authorize()]
        [HttpGet("info")]
        public IActionResult Info()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}");
        }


        [Authorize()]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var role = GetCurrentUser().Role;
            if (role == "Administrator")
            {
                var users =await _userService.GetAllUsers();
                return Ok(users);
            }
            else return Unauthorized();
        }

        [Authorize]
        [HttpPut("update")]
        public IActionResult Update([FromBody]UserUpdateDTO user)
        {
            var id = GetCurrentUser().Id;
            
            _userService.Update(user,id);
            return Ok("Success");
        }

        [Authorize()]
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody]Guid id)
        {
            var role = GetCurrentUser().Role;
            if (role == "Administrator")
            {
                _userService.Delete(id);
                return Ok("User deleted");
            }
            else return Unauthorized();
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    Id= Guid.Parse(userClaims.FirstOrDefault(o=>o.Type=="id")?.Value)
                };
            }
            return null;
        }
    }
}

