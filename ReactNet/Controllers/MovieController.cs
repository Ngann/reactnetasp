using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReactNet.Data;
using ReactNet.Models;
using Microsoft.EntityFrameworkCore;

namespace ReactNet.Controllers
{
    //[Route("api/[controller]")]
    public class MovieController : Controller
    {

        private readonly ApplicationDBContext _context;

        public MovieController(ApplicationDBContext context)
        {
            _context = context;
        }

        //[HttpGet("[action]")]
        [HttpGet]
        [Route("api/Movie/Index")]
        public IEnumerable<Movie> Index()
        {
            return _context.Movie.ToList();
        }

        // POST api/Movie/Create
        ///api/Movie/Create/?title=test&genre=This&price=1.90&note=somenote&releaseDate=0001-01-01T00
        [HttpGet]
        [Route("api/Movie/Create")]
        public IActionResult Create(Movie info)
        {
            _context.Movie.Add(info);
            _context.SaveChanges();

            return StatusCode(201, info);
        }

        [HttpGet]
        [Route("api/Movie/Detail")]
        // GET: api/Movie/Detail/{id}
        ///api/Movie/Detail/?id=1
        public Movie Detail(int id)
        {
            Movie movieInfo = _context.Movie.Find(id);
            return movieInfo;
        }

        //www.learnentityframeworkcore.com/dbcontext/modifying-data
        [HttpPut]
        [Route("api/Movie/Edit")]
        public string Edit(int id, Movie movie)
        {
            Movie movieId = _context.Movie.Find(id);
            _context.Entry(movieId).CurrentValues.SetValues(movie);
            return movie.Title;

        }

        [HttpGet]
        [Route("api/Movie/Delete")]
        // GET: api/Movie/Delete/{id}
        ///api/Movie/Delete/?id=1

        public Movie Delete(int id)
        {
            Movie info = _context.Movie.Find(id);
            _context.Movie.Remove(info);
            _context.SaveChanges();

            return info;
        }

        [HttpGet]
        [Route("api/Movie/Search")]
        // GET: api/Movie/Search
        //api/Movie/Search/?term=Comedy

        public List<Movie> Search(string term)
        {
            return _context.Movie
                .Where(b => b.Title.Contains(term))
                .OrderBy(b => b.Title)
                .ToList();
        }

    }
}