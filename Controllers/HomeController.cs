﻿using Intex2.Core;
using Intex2.Models;
using Intex2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Linq;


namespace Intex2.Controllers
{
    public class HomeController : Controller
    {
        private IIntex2Repository repo;
        // Constructs the home controller with the abstracted db connection through a repository
        public HomeController(IIntex2Repository temp)
        {
            repo = temp;
        }
        // Displays the landing page
        public IActionResult Index()
        {
            return View();
        }
        // Displays the privacy policy
        public IActionResult Privacy()
        {
            return View();
        }
        // Displays the burial list page, handles filtering and pagination
        public IActionResult BurialList (string area, string bnum, string dage, string depth, string direction, string ew, string hair, string ns, string sew, string sex, string sns, int pageNum = 1)
        {
            // allows 10 burial records per page
            int pageSize = 10;

            var x = new BurialsViewModel
            {
                // filters, paginates results from burialmains table
                Burialmains = repo.Burialmains
                    .Where(b =>
                        (area == null || b.Area == area) &&
                        (bnum == null || b.Burialnumber == bnum) &&
                        (dage == null || b.Ageatdeath == dage) &&
                        (depth == null || b.Depth == depth) &&
                        (direction == null || b.Headdirection == direction) &&
                        (ew == null || b.Eastwest == ew) &&
                        (hair == null || b.Haircolor == hair) &&
                        (ns == null || b.Northsouth == ns) &&
                        (sew == null || b.Squareeastwest == sew) &&
                        (sex == null || b.Sex == sex) &&
                        (sns == null || b.Squarenorthsouth == sns))
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                // sets page info to be used by the pagination tag helpers
                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                            ((area == null && bnum == null && dage == null && depth == null && direction == null && ew == null && hair == null && ns == null && sew == null && sex == null && sns == null)
                            ? repo.Burialmains.Count()
                            : repo.Burialmains
                                .Where(b =>
                                (b.Area == area || area == null) &&
                                (bnum == null || b.Burialnumber == bnum) &&
                                (dage == null || b.Ageatdeath == dage) &&
                                (depth == null || b.Depth == depth) &&
                                (direction == null || b.Headdirection == direction) &&
                                (ew == null || b.Eastwest == ew) &&
                                (hair == null || b.Haircolor == hair) &&
                                (ns == null || b.Northsouth == ns) &&
                                (sew == null || b.Squareeastwest == sew) &&
                                (sex == null || b.Sex == sex) &&
                                (sns == null || b.Squarenorthsouth == sns))
                                .Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            // Sets viewbag data, used by the filter components
            ViewBag.SelectedArea = string.IsNullOrEmpty(area) ? "Area" : area;
            ViewBag.SelectedBnum = string.IsNullOrEmpty(bnum) ? "Burial Number" : bnum;
            ViewBag.SelectedDage = string.IsNullOrEmpty(dage) ? "Age at Death" : dage;
            ViewBag.SelectedDepth = string.IsNullOrEmpty(depth) ? "Depth" : depth;
            ViewBag.SelectedDirection = string.IsNullOrEmpty(direction) ? "Head Direction" : direction;
            ViewBag.SelectedEW = string.IsNullOrEmpty(ew) ? "East West" : ew;
            ViewBag.SelectedHair = string.IsNullOrEmpty(hair) ? "Hair" : hair;
            ViewBag.SelectedNS = string.IsNullOrEmpty(ns) ? "North South" : ns;
            ViewBag.SelectedSEW = string.IsNullOrEmpty(sew) ? "Square East West" : sew;
            ViewBag.SelectedSex = string.IsNullOrEmpty(sex) ? "Sex" : sex;
            ViewBag.SelectedSNS = string.IsNullOrEmpty(sns) ? "Square North South" : sns;

            return View(x);
        }

        // Displays burialdetails page, an extension of each burial record
        [HttpGet]
        public IActionResult BurialDetail(string burialnumber)
        {
            var burial = repo.Burialmains
                .Where(b => b.Burialnumber == burialnumber).FirstOrDefault();
            if (burial == null)
            {
                return NotFound();
            }
            return View(burial);
        }

        // Displays the edit burial page, can only be accessed by permitted users
        [Authorize(Roles = "Researcher, Administrator")]
        public IActionResult BurialEdit (long burialId)
        {
            var burial = repo.Burialmains.Where(x => x.Id == burialId).FirstOrDefault();
            return View(burial);
        }
        // Displays the delete burial page, can only be accessed by permitted users
        [Authorize(Roles = "Researcher, Administrator")]
        public IActionResult BurialDelete()
        {
            return View();
        }

        public IActionResult Prediction()
        {
            return View();
        }

        public IActionResult Visualization()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}