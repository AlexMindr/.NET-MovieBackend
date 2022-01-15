using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Services;
using ProiectDAW.Utilities.Attributes;
using BCryptNet = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        [HttpPost("authentificate")]
        public IActionResult Authentificate(UserRequestDTO user)
        {
            var response = _userService.Authentificate(user);

            if (response == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                FirstName = user.FirstName,
                //Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            // should use context to add the user to db
            return Ok();
        }

        //[Authorization(Role.Admin)]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}

