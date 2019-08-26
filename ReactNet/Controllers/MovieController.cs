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
    [Route("api/[controller]")]
    public class MovieController : Controller
    {

        private readonly ApplicationDBContext _context;

        public MovieController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<Movie> Index()
        {
            return _context.Movie.ToList();
        }

        // POST api/Movie/Create
        [HttpPost]
        public IActionResult Create(Movie info)
        {
            _context.Movie.Add(info);
            _context.SaveChanges();

            return StatusCode(201, info);
        }

        [HttpGet("[action]")]
        // GET: api/Movie/Detail/{id}

        public ActionResult<Movie> Detail(int id)
        {
            Movie movieInfo = _context.Movie.Find(id);
            return StatusCode(200, $"Reteived deatils for movie {movieInfo}");
        }

        [HttpGet("[action]")]
        // GET: api/Movie/Delete/{id}

        public ActionResult<Movie> Delete(int id)
        {
            Movie info = _context.Movie.Find(id);
            _context.Movie.Remove(info);
            _context.SaveChanges();

            return StatusCode(200, $"deleted {info}");
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