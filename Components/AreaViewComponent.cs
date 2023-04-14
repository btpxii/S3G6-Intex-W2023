using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class AreaViewComponent : ViewComponent
    {
        // View component that builds the area filter for buriallist
        private IIntex2Repository repo { get; set; }
        public AreaViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // Filters areas down to distinct, non-null values
            var area = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Area))
                .Select(x => x.Area)
                .Distinct()
                .OrderBy(x => x);

            return View(area);
        }
    }
}
