using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class HairViewComponent : ViewComponent
    {


        private IIntex2Repository repo { get; set; }
        public HairViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {


            var hair = repo.Burialmains
                .Select(x => x.Haircolor)
                .Distinct()
                .OrderBy(x => x);

            return View(hair);
        }


    }
}