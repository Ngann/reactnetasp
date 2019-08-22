using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactNet.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {

        public class Student
        {
            public string Name;
            public int Grade;
            public string Birthday;
            public string Address;
            public int Phone;
        };
    }
}
