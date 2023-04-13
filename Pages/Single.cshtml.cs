using Intex2.Models;
using Intex2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.Xml;

namespace Intex2.Page
{
    public class SingleModel : PageModel
    {

        private IIntex2Repository repo { get; set; }
        public SingleModel (IIntex2Repository temp)
        {
            repo = temp;
        }

 
        public void OnGet()
        {
       
        }

        public IActionResult OnPost(int burialId)
        {
            Burialmain bm = repo.Burialmains.FirstOrDefault(x => x.Id == burialId);

            return Page();
        }


    }
}
