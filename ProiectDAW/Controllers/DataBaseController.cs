using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        private readonly ProjectContext _ProjectContext;

        public DataBaseController(ProjectContext ProjectContext)
        {
            _ProjectContext = ProjectContext;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ProjectContext.DataBaseModels.ToListAsync());
        }
    }
}
