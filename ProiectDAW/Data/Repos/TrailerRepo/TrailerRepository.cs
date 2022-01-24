using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.TrailerRepo
{
    public class TrailerRepository
    {
        protected readonly ProjectContext _context;
        protected readonly DbSet<Trailer> _table;

        public TrailerRepository(ProjectContext context)
        {
            _context = context;
            _table = _context.Set<Trailer>();
        }

        // Get all

        public async Task<List<Trailer>> GetAll()
        {
            // the select to the db 
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<Trailer> GetAllAsQueryable()
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

        public async Task CreateAsync(Trailer entity)
        {

            entity.DateCreated = DateTime.UtcNow;
            entity.DateModified = DateTime.UtcNow;
            await _table.AddAsync(entity);
        }


        // Update

        public void Update(Trailer entity)
        {

            entity.DateModified = DateTime.UtcNow;
            _table.Update(entity);
        }


        // Delete

        public void Delete(Trailer entity)
        {
            _table.Remove(entity);
        }


        // Find

        public Trailer FindById(object id)
        {
            return _table.Find(id);

            // another option
            // return _table.FirstOrDefault(x=> x.Id.Equals(id));
        }

        public async Task<Trailer> FindByIdAsync(object id)
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
