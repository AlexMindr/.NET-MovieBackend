using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Data.Services;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListsController : ControllerBase
    {
        public IWatchListService _watchlist;
        public IUserService _users;
        public WatchListsController(IWatchListService watchlist,IUserService users)
        {
            _watchlist = watchlist;
            _users = users;
        }


        [Authorize()]
        [HttpGet("list")]
        public IActionResult GetList()
        {   
            var id = GetCurrentUser().Id;
            var res = _watchlist.GetWatchList(id);
            if (res != null) 
            {
                return Ok(res); 
            }
            else 
            {
                return BadRequest("No items added to list"); 
            };
        }

        [Authorize()]
        [HttpPost]
        public IActionResult Add([FromBody] WatchListCreateDTO watchlist)
        {
            var user = GetCurrentUser();
            if (user != null)
            {
                _watchlist.Add(user.Id, watchlist.movieId, watchlist.Rating, watchlist.Status);
                return Ok("Added successfuly!");
            }
            return Unauthorized();
        }

        [Authorize()]
        [HttpDelete()]
        public IActionResult Delete([FromForm]Guid movieId) {

            var user = GetCurrentUser();
            if (user != null)
            {
                _watchlist.Delete(user.Id, movieId);
                return Ok("Deleted!");
            }
            return Unauthorized();
        }

        [Authorize()]
        [HttpPut]
        public IActionResult Update([FromForm] WatchListCreateDTO watchlist)
        {

            var user = GetCurrentUser();
            if (user != null)
            {
                _watchlist.Update(user.Id, watchlist.movieId,watchlist.Rating,watchlist.Status);
                return Ok("Updated!");
            }
            return Unauthorized();
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
                    Id = Guid.Parse(userClaims.FirstOrDefault(o => o.Type == "id")?.Value)
                };
            }
            return null;
        }

    }
}
