using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class AreaViewComponent : ViewComponent
    {

        private IIntex2Repository repo { get; set; }
        public AreaViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            var area = repo.Burialmains
                .Select(x => x.Area)
                .Distinct()
                .OrderBy(x => x);

            return View(area);
        }
    }
}
