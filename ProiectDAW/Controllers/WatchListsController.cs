using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListsController : ControllerBase
    {
        public IWatchListService _watchlist;

        public WatchListsController(IWatchListService watchlist)
        {
            _watchlist = watchlist;
        }



        [HttpGet]
        public IActionResult GetListForUser() {
            var userId = HttpContext.User;
            Ok(_watchlist.GetList(userId));
        }
    }
}
