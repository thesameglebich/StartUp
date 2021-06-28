using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class MockupsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
        public IActionResult Menu()
        {
            return this.View();
        }
    }
}
