using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class SEWViewComponent : ViewComponent
    {

        // View component that builds the SEW filter for buriallist
        private IIntex2Repository repo { get; set; }
        public SEWViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // Filters SEW down to distinct, non-null values
            var SEW = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Squareeastwest))
                .Select(x => x.Squareeastwest)
                .Distinct()
                .OrderBy(x => x);

            return View(SEW);
        }


    }
}