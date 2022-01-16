using ProiectDAW.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.Models;
using Microsoft.Data.SqlClient;

namespace ProiectDAW.Repositories.GenericRepository
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ProjectContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(ProjectContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        // Get all

        public async Task<List<TEntity>> GetAll()
        {
            // the select to the db 
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
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

        public async Task CreateAsync(TEntity entity)
        {
             await _table.AddAsync(entity);
        }


        // Update

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }


        // Delete

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        
        // Find

        public TEntity FindById(object id)
        {
            return _table.Find(id);

            // another option
            // return _table.FirstOrDefault(x=> x.Id.Equals(id));
        }

        public async  Task<TEntity> FindByIdAsync(object id)
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
