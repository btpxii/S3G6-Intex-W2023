using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class NSViewComponent : ViewComponent
    {


        private IIntex2Repository repo { get; set; }
        public NSViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            var NS = repo.Burialmains
                .Select(x => x.Northsouth)
                .Distinct()
                .OrderBy(x => x);

            return View(NS);
        }


    }
}