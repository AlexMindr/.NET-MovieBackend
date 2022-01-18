using ProiectDAW.Models;
using ProiectDAW.Models.Entities;
using ProiectDAW.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data.Repos.MovieRepo
{
    public class MovieRepository: GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ProjectContext context) : base(context)
        {

        }
    }
}
