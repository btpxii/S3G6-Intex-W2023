using Intex2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Intex2.Controllers
{
    public class HomeController : Controller
    {
        private MummiesDbContext context { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(MummiesDbContext temp)
        {
            context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BurialList()
        {
            var blah = context.Burialmains.ToList();
            return View(blah);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}