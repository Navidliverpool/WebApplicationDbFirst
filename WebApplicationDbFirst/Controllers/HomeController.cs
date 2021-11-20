using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
//using WebApplicationDbFirst.Models.Services;
using WebApplicationDbFirst.Entities;
using WebApplicationDbFirst.ViewModels;

namespace WebApplicationDbFirst.Controllers
{
    public class HomeController : Controller
    {
        private NavEcommerceDBfirstEntities2 db = new NavEcommerceDBfirstEntities2();

        public async Task<ActionResult> Index()
        {
            var homeVM = new HomeVM
            {
                MotorcyclesHomeVM = db.Motorcycles.FirstOrDefault(),
                BrandsHomeVM = db.Brands.FirstOrDefault()
            };

            var motorcycleImageData = db.Motorcycles.Where(m => m.Image == homeVM.MotorcyclesHomeVM.Image).FirstOrDefault();
            if (motorcycleImageData != null)
            {
                homeVM.MotorcyclesHomeVM.Image = motorcycleImageData.Image;
            }

            var brandImageData = db.Motorcycles.Where(m => m.Image == homeVM.BrandsHomeVM.Image).FirstOrDefault();
            if (brandImageData != null)
            {
                homeVM.MotorcyclesHomeVM.Image = motorcycleImageData.Image;
            }

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