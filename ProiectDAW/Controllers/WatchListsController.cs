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
        public IUserService _users;
        public WatchListsController(IWatchListService watchlist,IUserService users)
        {
            _watchlist = watchlist;
            _users = users;
        }



        [HttpGet("list")]
        public IActionResult GetListForUser(Guid id)
        {
            
            var res = _watchlist.GetWatchList(id);
            if (res != null) 
            {
                return Ok(res); 
            }
            else 
            {
                return BadRequest("No items added to list"); 
            };
        }
        
    }
}
