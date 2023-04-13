using Intex2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace Intex2.Components
{
    public class DirectionViewComponent : ViewComponent
    {

        private IIntex2Repository repo { get; set; }
        public DirectionViewComponent (IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedDirection = RouteData?.Values["direction"];

            var direction = repo.Burialmains
                .Select(x => x.Headdirection)
                .Distinct()
                .OrderBy(x => x);

            return View(direction);

        }

    }
}
