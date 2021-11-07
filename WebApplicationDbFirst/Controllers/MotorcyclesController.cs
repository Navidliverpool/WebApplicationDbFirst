﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationDbFirst;
using WebApplicationDbFirst.ViewModels;
using WebApplicationDbFirst.Models;

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

            var motorcycleViewModel = new MotorcycleVM
            {
                Motorcycle = db.Motorcycles.Include(i => i.Dealers).First(i => i.MotorcycleId == id),
            };

            if (motorcycleViewModel.Motorcycle == null)
                return HttpNotFound();

            var allDealersList = db.Dealers.ToList();

            motorcycleViewModel.AllDealers = allDealersList.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.DealerId.ToString()
            });

            ViewBag.BrandId =
                    new SelectList(db.Brands, "BrandId", "Name", motorcycleViewModel.Motorcycle.BrandId);

            return View(motorcycleViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MotorcycleVM motorcycleViewModel)
           {
   	    
  			if (motorcycleViewModel == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
  
              if (ModelState.IsValid)
              {
  				var motorcycleToUpdate = db.Motorcycles
  					.Include(i => i.Dealers).First(i => i.MotorcycleId == motorcycleViewModel.Motorcycle.MotorcycleId);
  
  	            if (TryUpdateModel(motorcycleToUpdate,"Motorcycle",new string[]{"Model", "Price", "BrandId", "Dealers", "MotorcycleId" } ))
  	            {
  		            var newDealers = db.Dealers.Where(
                         m => motorcycleViewModel.SelectedDealers.Contains(m.DealerId)).ToList();
  					var updatedDealers = new HashSet<int>(motorcycleViewModel.SelectedDealers);
  					foreach (Dealer dealer in db.Dealers)
  					{
  						if (!updatedDealers.Contains(dealer.DealerId))
  						{
  							motorcycleToUpdate.Dealers.Remove(dealer);
  						}
                         else
                             {
                                 motorcycleToUpdate.Dealers.Add((dealer));
                             }
                     }

                    db.Entry(motorcycleToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                 }

                  return RedirectToAction("Index");
              }
            ViewBag.BrandId =
                    new SelectList(db.Brands, "BrandId", "Name", motorcycleViewModel.Motorcycle.BrandId);
            return View(motorcycleViewModel);
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
