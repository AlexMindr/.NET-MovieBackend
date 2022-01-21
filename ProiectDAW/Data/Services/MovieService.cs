using ProiectDAW.Data.Repos.GenreRepo;
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
        public IGenreRepository _genre;

        public MovieService(IMovieRepository movie, IGenreRepository genre)
        {
            _movie = movie;
            _genre = genre;
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

        
        public List<MovieresDTO> GetAllMovies()
        {
            var movies = _movie.GetAllMovies();
            var list= new List<MovieresDTO>();
            
            foreach (Movie movie in movies)
            {
                var genres = _genre.GetGenresByMovieId(movie.Id);
                list.Add(new MovieresDTO
                {
                    Id = movie.Id,
                    Adult = movie.Adult,
                    Title = movie.Title,
                    Budget = movie.Budget,
                    Duration = movie.Duration,
                    ReleaseDate = movie.ReleaseDate,
                    TrailerPath = movie.Trailer.Path,
                    Language = movie.Language,
                    PosterPath = movie.PosterPath,
                    TmdbId = movie.TmdbId,
                    Rating = movie.Rating,
                    Genresofmovie = genres
                });
                

            }
            return list;
        }

   
        public MovieresDTO GetByTitle(string title)
        {
            var res =_movie.FindByName(title);
            var genres = _genre.GetGenresByMovieId(res.Id);
            MovieresDTO movie = new()
            {
                Adult = res.Adult,
                Duration=res.Duration,
                Title=res.Title,
                PosterPath=res.PosterPath,
                Language=res.Language,
                Budget=res.Budget,
                ReleaseDate=res.ReleaseDate,
                Id=res.Id,
                Rating=res.Rating,
                TmdbId=res.TmdbId,
                TrailerPath=res.Trailer.Path,
                Genresofmovie=genres
            };
            
            return movie;
            
        }
    }
}
