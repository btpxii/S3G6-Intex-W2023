using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class SEWViewComponent : ViewComponent
    {


        private IIntex2Repository repo { get; set; }
        public SEWViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        { 

            var SEW = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Squareeastwest))
                .Select(x => x.Squareeastwest)
                .Distinct()
                .OrderBy(x => x);

            return View(SEW);
        }


    }
}