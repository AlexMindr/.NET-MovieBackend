using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.DatabaseRepo
{
    interface IMovieGenreRepository
    {
        // Get all data
        Task<List<MovieGenre>> GetAll();

        // Create
        Task CreateAsync(MovieGenre entity);

        // Update
        void Update(MovieGenre entity);

        // Delete
        void Delete(MovieGenre entity);

        // Find
        MovieGenre FindById(object id);
        Task<MovieGenre> FindByIdAsync(object id);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
}
