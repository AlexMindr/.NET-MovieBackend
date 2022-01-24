using ProiectDAW.Models.DTOs;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Services
{
    public interface IMovieService
    {
        Task CreateAsync(MovieDTO entity);
        List<MovieresDTO> GetAllMovies();
        MovieresDTO GetByTitle(string title);
        void Update(Movie entity);
        void Delete(Guid id);
    }
}
