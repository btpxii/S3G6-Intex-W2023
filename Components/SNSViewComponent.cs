﻿using Intex2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2.Components
{
    public class SNSViewComponent : ViewComponent
    {

        // View component that builds the SNS filter for buriallist
        private IIntex2Repository repo { get; set; }
        public SNSViewComponent(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // Filters SNS down to distinct, non-null values
            var SNS = repo.Burialmains
                .Where(x => !string.IsNullOrWhiteSpace(x.Squarenorthsouth))
                .Select(x => x.Squarenorthsouth)
                .Distinct()
                .OrderBy(x => x);

            return View(SNS);
        }


    }
}