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
        // GET: Movies

        public ActionResult<List<Movie>> Index()
        {
            return _context.Movie.OrderBy(id => id).ToList();
        }

        [HttpPost]
        public IActionResult Create(Movie item)
        {
            _context.Movie.Add(item);
            _context.SaveChanges();

            return new OkResult();//CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

    }
}