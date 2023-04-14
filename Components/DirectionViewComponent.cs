using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class DirectionViewComponent : ViewComponent
    {
        // View component that builds the direction filter for buriallist
        private IIntex2Repository repo { get; set; }
        public DirectionViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // Filters direction down to distinct, non-null values
            var direction = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Headdirection))
                .Select(x => x.Headdirection)
                .Distinct()
                .OrderBy(x => x);

            return View(direction);
        }
    }
}