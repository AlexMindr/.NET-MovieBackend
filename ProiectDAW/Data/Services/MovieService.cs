using ProiectDAW.Data.Repos.MovieRepo;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Services
{
    public class MovieService:IMovieService
    {
        public IMovieRepository _movie;

        public MovieService(IMovieRepository movie)
        {
            _movie = movie;
        }

        public async Task CreateAsync(MovieDTO entity)
        {
            var genres = new List<MovieGenre>();
            for (int i = 0; i < entity.Genresofmovie.Count; i++)
            {
                var genre = new MovieGenre { GenreId = entity.Genresofmovie.ToArray()[i] };
                genres.Add(genre);
            }


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
                MovieGenres = genres
                 
            };

        
            await _movie.CreateAsync(movie);
            await _movie.SaveAsync();
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
