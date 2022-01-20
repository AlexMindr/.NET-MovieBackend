using ProiectDAW.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Services
{
    public interface IMovieService
    {
        Task CreateAsync(MovieDTO entity);
        IEnumerable<MovieDTO> GetAllMovies();
        MovieDTO GetByTitle(string title);
    }
}
