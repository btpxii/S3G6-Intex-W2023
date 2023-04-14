using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class DirectionViewComponent : ViewComponent
    {

        private IIntex2Repository repo { get; set; }
        public DirectionViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            var direction = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Headdirection))
                .Select(x => x.Headdirection)
                .Distinct()
                .OrderBy(x => x);

            return View(direction);
        }
    }
}