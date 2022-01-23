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
        [HttpPost("authenticate")]
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
            if (usr == true)
                return Ok(usr);
            else
                return BadRequest(new { Message = "Username already taken!" });
        }

        [Authorization("Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        [Authorization("Admin")]
        [HttpPut]
        public IActionResult Update([FromForm]UserUpdateDTO user)
        {
            var id =User.Claims.First(x=>x.Type=="id").Value;
            //Guid ids = (Guid)id;
            //_userService.GetRole(id);
            //_userService.Update(user);
            return Ok(id);
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

