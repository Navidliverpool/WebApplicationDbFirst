using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
//using WebApplicationDbFirst.Models.Services;
using WebApplicationDbFirst.Entities;

namespace WebApplicationDbFirst.Controllers
{
    public class HomeController : Controller
    {
        private NavEcommerceDBfirstEntities2 db = new NavEcommerceDBfirstEntities2();

        public async Task<ActionResult> Index()
        {
            var motorcycles = db.Motorcycles.Include(m => m.Brand);
            return View(await motorcycles.ToListAsync());
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