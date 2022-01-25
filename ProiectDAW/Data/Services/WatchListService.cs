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

        public List<WatchListItemDTO> GetWatchList(object userId)
        {
            return _watchlist.GetMovieNamesList(userId);
        }

        public void Update(object userId, object movieId, int rating, string status)
        {
            WatchList wl=_watchlist.FindById(userId,movieId);
            if (wl == null) throw new NotSupportedException("NOPE");
            wl.Rating = rating;
            wl.Status = status;
            _watchlist.Update(wl);
            _watchlist.Save();
        }

        public void Delete(object userId, object movieId)
        {
            WatchList wl = _watchlist.FindById(userId,movieId);
            if (wl == null) throw new KeyNotFoundException();
            _watchlist.Delete(wl);
            _watchlist.Save();
        }


    }
}
