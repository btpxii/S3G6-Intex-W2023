using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class HairViewComponent : ViewComponent
    {

        // View component that builds the hair filter for buriallist
        private IIntex2Repository repo { get; set; }
        public HairViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            // Filters hair down to distinct, non-null values
            var hair = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Haircolor))
                .Select(x => x.Haircolor)
                .Distinct()
                .OrderBy(x => x);

            return View(hair);
        }


    }
}