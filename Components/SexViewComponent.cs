using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class SexViewComponent : ViewComponent
    {

        // View component that builds the Sex filter for buriallist
        private IIntex2Repository repo { get; set; }
        public SexViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // Filters Sex down to distinct, non-null values
            var sex = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Sex))
                .Select(x => x.Sex)
                .Distinct()
                .OrderBy(x => x);

            return View(sex);
        }


    }
}