using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactNet.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactNet.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {

        private readonly ApplicationDBContext _context;
        public AuthorsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/authors
        public IEnumerable<Author> Get()
        {
            return _context.Authors.ToList();
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _context.Authors.FirstOrDefault(x => x.Id == id);
        }

        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody]Author value)
        {
            _context.Authors.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}
