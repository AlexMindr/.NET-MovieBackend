﻿using ProiectDAW.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Services
{
   public interface IWatchListService
    {
        Task Add(object userId, object movieId,int rating, string status);
        List<WatchListItemDTO> GetWatchList(object userId);

        void Update(object userId, object movieId, int rating, string status);

        void Delete(object userId, object movieId);
    }
}
