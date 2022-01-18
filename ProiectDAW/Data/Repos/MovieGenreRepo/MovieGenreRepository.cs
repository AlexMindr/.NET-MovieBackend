using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.MovieGenreRepo
{
    public class MovieGenreRepository
    {
        protected readonly ProjectContext _context;
        protected readonly DbSet<MovieGenre> _table;

        public MovieGenreRepository(ProjectContext context)
        {
            _context = context;
            _table = _context.Set<MovieGenre>();
        }

        // Get all

        public async Task<List<MovieGenre>> GetAll()
        {
            // the select to the db 
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<MovieGenre> GetAllAsQueryable()
        {
            return _table.AsNoTracking();

            // try not to use toList, count etc, before filtering the data
            // var entityList = _table.ToList();
            // var entityListFiltered = _table.Where(x => x.Id.ToString() != "");

            // better version; the data is filtered in the query 
            // select * from entity where Id is not null
            // var entitylistFiltered = _table.Where(x => x.Id.ToString() != "").ToList();
        }


        // Create

        public async Task CreateAsync(MovieGenre entity)
        {
            await _table.AddAsync(entity);
        }


        // Update

        public void Update(MovieGenre entity)
        {
            _table.Update(entity);
        }


        // Delete

        public void Delete(MovieGenre entity)
        {
            _table.Remove(entity);
        }


        // Find

        public MovieGenre FindById(object id)
        {
            return _table.Find(id);

            // another option
            // return _table.FirstOrDefault(x=> x.Id.Equals(id));
        }

        public async Task<MovieGenre> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);

            // another option
            // return await _table.FirstOrDefaultAsync(x=> x.Id.Equals(id));
        }


        // Save
        public bool Save()
        {
            //try
            //{
            return _context.SaveChanges() > 0;
            //}
            //catch(SqlException ex)
            // {
            //  Console.WriteLine(ex);
            //}

            //return false;
        }

        public async Task<bool> SaveAsync()
        {
            //try
            //{
            return await _context.SaveChangesAsync() > 0;
            //}
            //catch(SqlException ex)
            //{
            //    Console.WriteLine(ex);
            //}

            // return false;
        }
    }
}
    

