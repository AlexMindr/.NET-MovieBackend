﻿using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.DatabaseRepo
{
    interface ITrailerRepository
    {
        // Get all data
        Task<List<Trailer>> GetAll();

        // Create
        Task CreateAsync(Trailer entity);

        // Update
        void Update(Trailer entity);

        // Delete
        void Delete(Trailer entity);

        // Find
        Trailer FindById(object id);
        Task<Trailer> FindByIdAsync(object id);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }

}