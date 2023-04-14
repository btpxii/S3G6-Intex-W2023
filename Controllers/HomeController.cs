using Intex2.Core;
using Intex2.Models;
using Intex2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Diagnostics;
using System.Net;


namespace Intex2.Controllers
{
    public class HomeController : Controller
    {
        private IIntex2Repository repo;

        public HomeController(IIntex2Repository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult BurialList(string area, string bnum, string dage, string depth, string direction, string ew, string hair, string ns, string sew, string sex, string sns, int pageNum = 1)
        {
            int pageSize = 50;

            var x = new BurialsViewModel
            {
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
                    .OrderBy(b => b.Dateofexcavation)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

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

        public IActionResult BurialDetail(int Id)
        {
            var burial = repo.Burialmains.FirstOrDefault(b => b.Id == Id);
            if (burial == null)
            {
                return NotFound();
            }
            return View(burial);
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