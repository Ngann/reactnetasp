using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactNet.Controllers
{
    public class PrimeServiceController : Controller
    {
        public bool IsPrime(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }
            throw new NotImplementedException("Please create a test first.");
        }

        public static bool isMagicSquare(List<List<decimal>> matrix)
        {
            return true;
        }

    }
}
