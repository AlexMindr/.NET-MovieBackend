using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Data.Services;
using ProiectDAW.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return Ok();
        }
    }
}
