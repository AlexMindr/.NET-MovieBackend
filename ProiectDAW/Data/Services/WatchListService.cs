using ProiectDAW.Data.Repos.WatchListRepo;
using ProiectDAW.Models.DTOs;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Services
{
    public class WatchListService:IWatchListService
    {
        public IWatchListRepository _watchlist;
        public WatchListService(IWatchListRepository watchlist)
        {
            _watchlist = watchlist;
        }

        
        public async Task Add(object userId, object movieId,int rating,string status)
        {
            var list = new WatchList
            { UserId = (Guid)userId,
                MovieId = (Guid)movieId,
                Rating = rating,
                Status = status
            };
            await _watchlist.CreateAsync(list);
            await _watchlist.SaveAsync();
        }

        public WatchListDTO GetList(object userId)
        {
            var res = _watchlist.GetMovieNamesList(userId);
           
                return res;
        }
        
    }
}
