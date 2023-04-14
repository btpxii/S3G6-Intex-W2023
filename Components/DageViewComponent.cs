using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class DageViewComponent : ViewComponent
    {
        // View component that builds the dage filter for buriallist
        private IIntex2Repository repo { get; set; }
        public DageViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {


            // Filters dage down to distinct, non-null values
            var dage = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Ageatdeath))
                .Select(x => x.Ageatdeath)
                .Distinct()
                .OrderBy(x => x);

            return View(dage);
        }
    }
}