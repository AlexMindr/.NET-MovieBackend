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



        [HttpGet("list")]
        public IActionResult GetListForUser(string username)
        {
            var userId = username;
            //var userId = HttpContext.User;
            var res = _watchlist.GetWatchList(userId);
            if (res!=null) { Ok(res); }
            else { Ok("No items added to list"); }
        }
    }
}
