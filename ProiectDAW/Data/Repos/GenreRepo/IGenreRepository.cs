using ProiectDAW.Models;
using ProiectDAW.Models.Entities;
using ProiectDAW.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.GenreRepo
{
    public interface IGenreRepository
    {
        // Get all data
        Task<List<Genre>> GetAll();

        // Create
        Task CreateAsync(Genre entity);

        // Update
        void Update(Genre entity);

        // Delete
        void Delete(Genre entity);

        // Find
        Genre FindById(object id);
        Task<Genre> FindByIdAsync(object id);

        // Save
        bool Save();
        Task<bool> SaveAsync();

        List<string> GetGenresByMovieId(object id);

    }
}
