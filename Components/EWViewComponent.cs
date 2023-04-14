using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class EWViewComponent : ViewComponent
    {
        // View component that builds the ew filter for buriallist
        private IIntex2Repository repo { get; set; }
        public EWViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            // Filters EW down to distinct, non-null values
            var EW = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Eastwest))
                .Select(x => x.Eastwest)
                .Distinct()
                .OrderBy(x => x);

            return View(EW);

        }

    }
}