using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReactNet.Data;

namespace ReactNet.Models
{
    public class MovieDataAccessLayer
    {
        
        private readonly ApplicationDBContext _context;

        public MovieDataAccessLayer(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {

             return _context.Movie.ToList();

        }

        //To Add new movie record
        public int AddMovie(Movie info)
        {
            _context.Movie.Add(info);
            _context.SaveChanges();
            return 1;
           
        }

        //Get the details of a particular movie    
        public Movie GetMovieData(int id)
        {
            Movie movieInfo = _context.Movie.Find(id);
            return movieInfo;
        }

        //To Update the records of a particluar movie
        public int UpdateMovie(Movie info)
        {
            _context.Entry(info).State = EntityState.Modified;
            _context.SaveChanges();
            return 1;
        }

        //To Delete the record of a particular movie
        public int DeleteMovie(int id)
        {
            Movie info = _context.Movie.Find(id);
            _context.Movie.Remove(info);
            _context.SaveChanges();
            return 1;
        }
    }
}


