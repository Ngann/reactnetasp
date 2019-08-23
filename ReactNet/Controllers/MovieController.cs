using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // GET: api/Movie/Index

        public ActionResult<List<Movie>> Index()
        {
            return _context.Movie.OrderBy(id => id).ToList();
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
		// GET: api/Movie/Find

		public ActionResult<List<Movie>> Find(string term)
		{
			return _context.Movie
				.Where(b => b.Title.Contains(term))
				.OrderBy(b => b.Title)
				.ToList();
		}

	}
}