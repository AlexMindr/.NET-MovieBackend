using ProiectDAW.Data.Repos.MovieRepo;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Services
{
    public class MovieServicecs:IMovieService
    {
        private readonly MovieRepository _movie;

        public MovieServicecs(MovieRepository movie)
        {
            _movie = movie;
        }
        public async Task CreateAsync(MovieDTO entity)
        {
            
            Movie movie = new Movie
            {
                Adult = entity.Adult,
                Title = entity.Title,
                Duration = entity.Duration,
                Budget = entity.Budget,
                PosterPath = entity.PosterPath,
                Language = entity.Language,
                ReleaseDate = entity.ReleaseDate,
                TmdbId = entity.TmdbId,
                Rating = null,
                Trailer = new Trailer { Path = entity.TrailerPath },
                MovieGenres = (ICollection<MovieGenre>)entity.Genresofmovie
            };

        
            await _movie.CreateAsync(movie);
        }

        
        public IEnumerable<MovieDTO> GetAllMovies()
        {
            throw new NotImplementedException();
        }

   
        public MovieDTO GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
