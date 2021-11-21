using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationDbFirst.Models;
using System.Data;
using System.Data.Entity;
using WebApplicationDbFirst;
using WebApplicationDbFirst.ViewModels;
//using WebApplicationDbFirst.Models.Services;
using Microsoft.AspNetCore.Http;
using WebApplicationDbFirst.Models.Services;
using System.IO;

namespace WebApplicationDbFirst.Controllers
{
    public class HomeController : Controller
    {
        private NavEcommerceDBfirstEntities db = new NavEcommerceDBfirstEntities();

        public async Task<ActionResult> Index()
        {
            var motorcycles = db.Motorcycles;
            var brand = db.Brands;
            var homeVM = new HomeVM
            {
                Motorcycles = motorcycles.ToList(),
                Brands = brand.ToList()
            };
            return View(homeVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}