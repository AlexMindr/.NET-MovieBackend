using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.WatchListRepo
{
    public class WatchListRepository:IWatchListRepository
    {
        protected readonly ProjectContext _context;
        protected readonly DbSet<WatchList> _table;
        protected readonly DbSet<Movie> _movie;

        public WatchListRepository(ProjectContext context)
        {
            _context = context;
            _table = _context.Set<WatchList>();
            _movie= _context.Set<Movie>();
        }

        // Get all

        public async Task<List<WatchList>> GetAll()
        {
            // the select to the db 
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<WatchList> GetAllAsQueryable()
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

        public async Task CreateAsync(WatchList entity)
        {
            await _table.AddAsync(entity);
        }


        // Update

        public void Update(WatchList entity)
        {
            _table.Update(entity);
        }


        // Delete

        public void Delete(WatchList entity)
        {
            _table.Remove(entity);
        }


        // Find

        public WatchList FindById(object iduser,object idmovie)
        {
            var wl = _table.Where(x => x.UserId.Equals(iduser)&&x.MovieId.Equals(idmovie)).FirstOrDefault();
            
            return wl;

        }

        public async Task<WatchList> FindByIdAsync(object iduser,object idmovie)
        {
            return await _table.FindAsync(iduser,idmovie);

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

        public List<WatchListItemDTO> GetMovieNamesList(object id)
        {
            var table =_table.Join(_movie,x=>x.MovieId,y=>y.Id,(x,y)=> new { 
            x.UserId,
            x.Rating,
            x.Status,
            y.Title,
            y.Id
            }).Where(x=>x.UserId.Equals(id)).ToList();

            var watchlist = new List<WatchListItemDTO>();

            foreach (var el in table)
            {
                var obj = new WatchListItemDTO
                {
                    userId = el.UserId,
                    movieId=el.Id,
                    Title=el.Title,
                    Status=el.Status,
                    Rating= (int)el.Rating
                    
                };
                watchlist.Add(obj);    
            };


            
            
            return watchlist;
        }
    }
}
