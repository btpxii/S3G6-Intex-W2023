using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class SexViewComponent : ViewComponent
    {


        private IIntex2Repository repo { get; set; }
        public SexViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            var sex = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Sex))
                .Select(x => x.Sex)
                .Distinct()
                .OrderBy(x => x);

            return View(sex);
        }


    }
}