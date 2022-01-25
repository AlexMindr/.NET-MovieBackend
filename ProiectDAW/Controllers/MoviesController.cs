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
    public class MoviesController : ControllerBase
    {
        public IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [Authorize()]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] MovieDTO movie)
        {
            var role = GetCurrentUser().Role;
            if (role == "Administrator")
            {
                await _movieService.CreateAsync(movie);
                return Ok("Movie added!");
            }
            return Unauthorized();
        }

        [HttpGet("getmovie")]
        public IActionResult GetByName([FromQuery]string title) 
        {
            var res = _movieService.GetByTitle(title);
            
            return Ok(res);
        }

        [HttpGet("all")]
        public IActionResult GetAll() 
        {
            return Ok(_movieService.GetAllMovies());
        }

        [Authorize()]
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery]string title)
        {
            var role = GetCurrentUser().Role;
            if (role == "Administrator")
            {
                var res = _movieService.GetByTitle(title);
                
                _movieService.Delete(res.Id);
                return Ok("Deleted!");
            }
            return Unauthorized();
            
        }

        [Authorize()]
        [HttpPut("update")]
        public IActionResult Update([FromBody] MovieresDTO movie)
        {
            var role = GetCurrentUser().Role;
            if (role == "Administrator")
            {
                var data=_movieService.GetByTitle(movie.Title);
                Movie mov = new Movie
                {
                    Id = data.Id,
                    Adult = movie.Adult,
                    Budget = movie.Budget,
                    Duration = movie.Duration,
                    PosterPath=movie.PosterPath,
                    Rating=movie.Rating,
                    Title=movie.Title,
                    TmdbId=movie.TmdbId,
                    Language=movie.Language
                };
                _movieService.Update(mov);
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
