using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet("[action]")]
        //public ActionResult<List<Movie>> GetAll()
        //{
        //    return _context.Movies.OrderBy(id => id).ToList();
        //}

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

    }
}