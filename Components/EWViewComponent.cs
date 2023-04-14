using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class EWViewComponent : ViewComponent
    {

        private IIntex2Repository repo { get; set; }
        public EWViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {


            var EW = repo.Burialmains
                .Select(x => x.Eastwest)
                .Distinct()
                .OrderBy(x => x);

            return View(EW);

        }

    }
}