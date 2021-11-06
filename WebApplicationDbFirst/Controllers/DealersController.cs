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
using WebApplicationDbFirst.Models;

namespace WebApplicationDbFirst.Controllers
{
    public class DealersController : Controller
    {
        private NavEcommerceDBfirstEntities db = new NavEcommerceDBfirstEntities();

        // GET: Dealers
        public async Task<ActionResult> Index()
        {
            return View(await db.Dealers.ToListAsync());
        }

        // GET: Dealers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = await db.Dealers.FindAsync(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        // GET: Dealers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dealers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DealerId,Name,Address,PhoneNumber")] Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                db.Dealers.Add(dealer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dealer);
        }

        // GET: Dealers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var motorcycleViewModel = new DealerVM
            {
                Dealer = db.Dealers.Include(i => i.Brands).First(i => i.DealerId == id),
            };

            if (motorcycleViewModel.Dealer == null)
                return HttpNotFound();

            var allDealersList = db.Brands.ToList();

            motorcycleViewModel.AllBrands = allDealersList.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.BrandId.ToString()
            });

            return View(motorcycleViewModel);
        }

        // POST: Dealers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DealerId,Name,Address,PhoneNumber")] Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dealer);
        }

        // GET: Dealers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = await db.Dealers.FindAsync(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        // POST: Dealers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dealer dealer = await db.Dealers.FindAsync(id);
            db.Dealers.Remove(dealer);
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
