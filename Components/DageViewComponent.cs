using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class DageViewComponent : ViewComponent
    {

        private IIntex2Repository repo { get; set; }
        public DageViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {



            var dage = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Ageatdeath))
                .Select(x => x.Ageatdeath)
                .Distinct()
                .OrderBy(x => x);

            return View(dage);
        }
    }
}