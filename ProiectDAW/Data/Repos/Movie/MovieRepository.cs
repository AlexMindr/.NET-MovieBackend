using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.DatabaseRepo
{
    public class MovieRepository: GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ProjectContext context) : base(context)
        {

        }
    }
}
