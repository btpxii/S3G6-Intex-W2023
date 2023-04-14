using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class BnumViewComponent : ViewComponent
    {
        // View component that builds the bnum filter for buriallist
        private IIntex2Repository repo { get; set; }
        public BnumViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            // Filters bnums down to distinct, non-null values
            var bnum = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Burialnumber))
                .Select(x => x.Burialnumber)
                .Distinct()
                .OrderBy(x => x);

            return View(bnum);
        }
    }
}
