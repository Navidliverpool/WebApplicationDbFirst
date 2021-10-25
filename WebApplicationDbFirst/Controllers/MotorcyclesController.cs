using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationDbFirst;

namespace WebApplicationDbFirst.Controllers
{
    public class MotorcyclesController : Controller
    {
        private NavEcommerceDBfirstEntities db = new NavEcommerceDBfirstEntities();

        // GET: Motorcycles
        public async Task<ActionResult> Index()
        {
            var motorcycles = db.Motorcycles.Include(m => m.Brand);
            return View(await motorcycles.ToListAsync());
        }

        // GET: Motorcycles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorcycle motorcycle = await db.Motorcycles.FindAsync(id);
            if (motorcycle == null)
            {
                return HttpNotFound();
            }
            return View(motorcycle);
        }

        // GET: Motorcycles/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            return View();
        }

        // POST: Motorcycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MotorcycleId,Model,Price,BrandId")] Motorcycle motorcycle)
        {
            if (ModelState.IsValid)
            {
                db.Motorcycles.Add(motorcycle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", motorcycle.BrandId);
            return View(motorcycle);
        }

        // GET: Motorcycles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorcycle motorcycle = await db.Motorcycles.FindAsync(id);
            if (motorcycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", motorcycle.BrandId);
            return View(motorcycle);
        }

        // POST: Motorcycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MotorcycleId,Model,Price,BrandId")] Motorcycle motorcycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorcycle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", motorcycle.BrandId);
            return View(motorcycle);
        }

        // GET: Motorcycles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorcycle motorcycle = await db.Motorcycles.FindAsync(id);
            if (motorcycle == null)
            {
                return HttpNotFound();
            }
            return View(motorcycle);
        }

        // POST: Motorcycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Motorcycle motorcycle = await db.Motorcycles.FindAsync(id);
            db.Motorcycles.Remove(motorcycle);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
