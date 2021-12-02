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
        private NavEcommerceDBfirstEntities3 db = new NavEcommerceDBfirstEntities3();

        public async Task<ActionResult> Index()
        {
            var motorcycle = db.Motorcycles;
            var brand = db.Brands;
            var homeVM = new HomeVM
            {
                MotorcyclesHomeVM = motorcycle.ToList(),
                BrandsHomeVM = brand.ToList()
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