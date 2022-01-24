using Microsoft.EntityFrameworkCore;
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

        //get all, get movie by name, get movie by genre,delete by name
        

        public Movie FindByName(string name)
        {
            var table=_table.Include("Trailer");
            var res = from s in table
                      where s.Title.Equals(name)
                      select s;

            
            return res.ToList()[0];
            
            //return await dbo.Movies.Where(s => s.Title.Equals(name)).Select(s=>s);

        }

        public List<Movie> GetAllMovies() 
        {
            var table = _table.Include("Trailer");
            var res = table.Select(x => x).ToList();
            return res;
        }
       
        
    }
}
