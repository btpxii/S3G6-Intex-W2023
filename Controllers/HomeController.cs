using Intex2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Intex2.Controllers
{
    public class HomeController : Controller
    {
        private IIntex2Repository repo;

        public HomeController (IIntex2Repository x)
        {
            repo = x;
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
            var burials = repo.Burialmains.ToList();
            return View(burials);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}