﻿using Intex2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net;
using System;

namespace Intex2.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        //dynamically create the page links for us

        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public dynamic PageFilter { get; set; }
        public string PageClass { get; set; }
        public bool PageClassEnabled { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                if (PageFilter != null)
                {
                    if (PageFilter.SelectedArea != "Area" ||
                       PageFilter.SelectedBnum != "Burial Number" ||
                       PageFilter.SelectedDage != "Age at Death" ||
                       PageFilter.SelectedDepth != "Depth" ||
                       PageFilter.SelectedDirection != "Head Direction" ||
                       PageFilter.SelectedEW != "East West" ||
                       PageFilter.SelectedHair != "Hair" ||
                       PageFilter.SelectedNS != "North South" ||
                       PageFilter.SelectedSEW != "Square East West" ||
                       PageFilter.SelectedSex != "Sex" ||
                       PageFilter.SelectedSNS != "Square North South")
                    {
                        tb.Attributes["href"] = uh.Action(PageAction, new
                        {
                            pageNum = i,
                            area = PageFilter.SelectedArea != "Area" ? PageFilter.SelectedArea : null,
                            bnum = PageFilter.SelectedBnum != "Burial Number" ? PageFilter.SelectedBnum : null,
                            dage = PageFilter.SelectedDage != "Age at Death" ? PageFilter.SelectedDage : null,
                            depth = PageFilter.SelectedDepth != "Depth" ? PageFilter.SelectedDepth : null,
                            direction = PageFilter.SelectedDirection != "Head Direction" ? PageFilter.SelectedDirection : null,
                            ew = PageFilter.SelectedEW != "East West" ? PageFilter.SelectedEW : null,
                            hair = PageFilter.SelectedHair != "Hair" ? PageFilter.SelectedHair : null,
                            ns = PageFilter.SelectedNS != "North South" ? PageFilter.SelectedNS : null,
                            sew = PageFilter.SelectedSEW != "Square East West" ? PageFilter.SelectedSEW : null,
                            sex = PageFilter.SelectedSex != "Sex" ? PageFilter.SelectedSex : null,
                            sns = PageFilter.SelectedSNS != "Square North South" ? PageFilter.SelectedSNS : null
                        });
                    }
                    else
                    {
                        tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    }
                }
                else
                {
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                }
                // NOTE WE MAY NEED TO CHANGE TO ACCOMODATE FOR FILTERING

                if (PageClassEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tb.AddCssClass(PageClass);
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            tho.Content.AppendHtml(final.InnerHtml);
        }


    }
}