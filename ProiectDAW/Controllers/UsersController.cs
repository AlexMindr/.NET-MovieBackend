using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Data.Services;
using ProiectDAW.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.Models.Entities;
using Microsoft.AspNetCore.Authorization;


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
        [HttpPost("authentificate")]
        public IActionResult Authentificate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);

            if (response == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Create(UserRegisterDTO user)
        {
            var usr=_userService.Create(user);
            return Ok(usr);
        }

        [Authorization("Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        [Authorization("Admin","User")]
        [HttpPut]
        public IActionResult Update([FromForm]UserUpdateDTO user)
        {
            _userService.Update(user);
            return Ok();
        }

        [Authorization("Admin")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}

