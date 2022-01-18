using ProiectDAW.Models;
using ProiectDAW.Models.Entities;
using ProiectDAW.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.WatchListRepo
{
    interface IWatchListRepository
    {
        // Get all data
        Task<List<WatchList>> GetAll();

        // Create
        Task CreateAsync(WatchList entity);

        // Update
        void Update(WatchList entity);

        // Delete
        void Delete(WatchList entity);

        // Find
        WatchList FindById(object id);
        Task<WatchList> FindByIdAsync(object id);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
