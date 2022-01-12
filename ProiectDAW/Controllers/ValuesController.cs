using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper _mapper;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ModelResultDTO model)
        {
            var userIdentity = _mapper.Map<ModelResultDTO, User>(model);

            var result = await userManager.CreateAsync(userIdentity, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(userIdentity, "User");
                return Ok();
            }

            return BadRequest(result.Errors);
        }

    }
}
