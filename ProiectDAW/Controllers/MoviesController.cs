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

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] MovieDTO movie)
        {
            await _movieService.CreateAsync(movie);

            // should use context to add the user to db
            return Ok("Movie added!");
        }

        [HttpGet("/getmovie")]
        public IActionResult GetByName([FromBody]string title) 
        {
            var res = _movieService.GetByTitle(title);
            
            return Ok(res.Id);
        }

        [HttpGet("all")]
        public IActionResult GetAll() 
        {
            return Ok(_movieService.GetAllMovies());
        }

        [Authorize()]
        [HttpDelete("/delete")]
        public IActionResult Delete([FromBody]Guid id)
        {
            var role = GetCurrentUser().Role;
            if (role == "Administrator")
            {
                _movieService.Delete(id);
                return Ok("Deleted!");
            }
            return Unauthorized();
            
        }

        [Authorize()]
        [HttpPut("/update")]
        public IActionResult Update([FromBody] MovieresDTO movie)
        {
            var role = GetCurrentUser().Role;
            if (role == "Administrator")
            {
                Movie mov = new Movie
                {
                    Id = movie.Id,
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
