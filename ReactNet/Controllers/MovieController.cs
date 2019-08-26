using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactNet.Data;
using ReactNet.Models;

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

        [HttpGet("[action]")]
        // GET: api/Movie/Delete/{id}
        ///api/Movie/Delete/?id=1

        public Movie Delete(int id)
        {
            Movie info = _context.Movie.Find(id);
            _context.Movie.Remove(info);
            _context.SaveChanges();

            return info;
        }

        [HttpGet("[action]")]
        // GET: api/Movie/Search

        public ActionResult<List<Movie>> Search(string term)
        {
            return _context.Movie
                .Where(b => b.Title.Contains(term))
                .OrderBy(b => b.Title)
                .ToList();
        }

    }
}