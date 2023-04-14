using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class DepthViewComponent : ViewComponent
    {
        // View component that builds the depth filter for buriallist
        private IIntex2Repository repo { get; set; }
        public DepthViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            // Filters depth down to distinct, non-null values
            var depth = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Depth))
                .Select(x => x.Depth)
                .Distinct()
                .OrderBy(x => x);

            return View(depth);
        }
    }
}

