using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using ProiectDAW.Models.Entities;
using ProiectDAW.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.GenreRepo
{
    public class GenreRepository:IGenreRepository
    {
        protected readonly ProjectContext _context;
        protected readonly DbSet<Genre> _table;
        protected readonly DbSet<MovieGenre> _moviegenre;
        public GenreRepository(ProjectContext context)
        {
            _context = context;
            _table = _context.Set<Genre>();
            _moviegenre = _context.Set<MovieGenre>();
        }

        // Get all

        public async Task<List<Genre>> GetAll()
        {
            // the select to the db 
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<Genre> GetAllAsQueryable()
        {
            return _table.AsNoTracking();

        }


        // Create

        public async Task CreateAsync(Genre entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.DateModified = DateTime.UtcNow;
            await _table.AddAsync(entity);
        }


        // Update

        public void Update(Genre entity)
        {

            entity.DateModified = DateTime.UtcNow;
            _table.Update(entity);
        }


        // Delete

        public void Delete(Genre entity)
        {
            _table.Remove(entity);
        }


        // Find

        public Genre FindById(object id)
        {
            return _table.Find(id);

        }

        public async Task<Genre> FindByIdAsync(object id)
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

        

        public List<string> GetGenresByMovieId(object id) 
        {

            var joined = _table.Join(_moviegenre, g => g.Id, mg => mg.GenreId, (g, mg) => new {
            g.Name,
            mg.MovieId
            });

            var res = joined.Where(x => x.MovieId.Equals(id))
                            .Select(x => x.Name).ToList();
                

            return res;
        }



    }
}
