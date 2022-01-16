using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    public class WatchListsController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
