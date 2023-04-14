using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class DepthViewComponent : ViewComponent
    {

        private IIntex2Repository repo { get; set; }
        public DepthViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {


            var depth = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Depth))
                .Select(x => x.Depth)
                .Distinct()
                .OrderBy(x => x);

            return View(depth);
        }
    }
}

