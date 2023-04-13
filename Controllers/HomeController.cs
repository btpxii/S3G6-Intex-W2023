using Intex2.Models;
using Intex2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Intex2.Controllers
{
    public class HomeController : Controller
    {
        private IIntex2Repository repo;

        public HomeController (IIntex2Repository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BurialList(string direction, string dage,  int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BurialsViewModel
            {
                Burialmains = repo.Burialmains
                .Where(b => 
                (b.Headdirection == direction || direction == null) &&
                (dage == null || b.Ageatdeath == dage))
                .OrderBy(b => b.Dateofexcavation)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials = repo.Burialmains 
                        .Count(b =>
                        (direction == null || b.Headdirection == direction) &&
                        (dage == null || b.Ageatdeath == dage)),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}