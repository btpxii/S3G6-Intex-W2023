using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class BnumViewComponent : ViewComponent
    {

        private IIntex2Repository repo { get; set; }
        public BnumViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {


            var bnum = repo.Burialmains
                .Select(x => x.Burialnumber)
                .Distinct()
                .OrderBy(x => x);

            return View(bnum);
        }
    }
}
