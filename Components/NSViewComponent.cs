using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class NSViewComponent : ViewComponent
    {

        // View component that builds the ns filter for buriallist
        private IIntex2Repository repo { get; set; }
        public NSViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // Filters NS down to distinct, non-null values
            var NS = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Northsouth))
                .Select(x => x.Northsouth)
                .Distinct()
                .OrderBy(x => x);

            return View(NS);
        }


    }
}