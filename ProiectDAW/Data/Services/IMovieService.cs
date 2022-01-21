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
        //Task Update(MovieDTO entity);
        //Task Delete(MovieDTO entity);
    }
}
