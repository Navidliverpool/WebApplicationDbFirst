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

            motorcycleViewModel.AllDealers = allDealersList.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.DealerId.ToString()
            });

            ViewBag.BrandId =
                    new SelectList(db.Brands, "BrandId", "Name", motorcycleViewModel.Motorcycle.BrandId);

            return View(motorcycleViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MotorcycleVM model, FormCollection formCollection)
        {

            var moto = db.Motorcycles
                    .Where(m => m.MotorcycleId == model.Motorcycle.MotorcycleId).FirstOrDefault();
            moto.Model = formCollection[model.Motorcycle.Model];
            var motoPriceToString = moto.Price.ToString();
            motoPriceToString = formCollection[model.Motorcycle.Price.ToString()];
            //var motoBrandToString = moto.Brand.BrandId.ToString();
            //motoBrandToString = formCollection[model.Motorcycle.Brand.BrandId];
            moto.Brand.Name = formCollection[model.Motorcycle.Brand.Name];


            //var brd2 = db.Motorcycles.Where(m => m.Brand.Name == model.Motorcycle.Brand.Name).FirstOrDefault();

            //var brd3 = new Brand();

            //brd3.Name = formCollection[model.BrandVM.Name];

            //var dlr1 = db.Dealers
            //    .Where(d => d.DealerId == model.Dealer.DealerId).FirstOrDefault();
            //var dlr2 = new Dealer();
            //dlr2.Name = formCollection[model.Dealer.Name];

            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                //db.Entry(brd3).State = EntityState.Modified;
                //db.Entry(dlr2).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            var dlrForSpecificMoto = db.Motorcycles.Select(m => m.Dealers).ToList();
            var motoVM = new MotorcycleVM()
            {
                Motorcycle = moto,
                //Dealer = dlr2,
                //BrandVM = brd3
            };
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", model.Motorcycle.BrandId);
            return View(moto);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(MotorcycleVM model, FormCollection formCollection)
        //{
        //    //var moto = db.Motorcycles
        //    //        .Where(m => m.MotorcycleId == model.Motorcycle.MotorcycleId).FirstOrDefault();
        //    var moto2 = new Motorcycle();
        //    moto2.Model = formCollection[model.Motorcycle.Model];
        //    var motoPriceToString = moto2.Price.ToString();
        //    motoPriceToString = formCollection[model.Motorcycle.Price.ToString()];

        //    //var brd2 = db.Motorcycles.Where(m => m.Brand.Name == model.Motorcycle.Brand.Name).FirstOrDefault();

        //    //var brd3 = new Brand();

        //    //brd3.Name = formCollection[model.BrandVM.Name];

        //    //var dlr1 = db.Dealers
        //    //    .Where(d => d.DealerId == model.Dealer.DealerId).FirstOrDefault();
        //    //var dlr2 = new Dealer();
        //    //dlr2.Name = formCollection[model.Dealer.Name];

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(moto2).State = EntityState.Modified;
        //        //db.Entry(brd3).State = EntityState.Modified;
        //        //db.Entry(dlr2).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //    }

        //    var dlrForSpecificMoto = db.Motorcycles.Select(m => m.Dealers).ToList();
        //    var motoVM = new MotorcycleVM()
        //    {
        //        Motorcycle = moto2,
        //        //Dealer = dlr2,
        //        //BrandVM = brd3
        //    };
        //    ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", model.Motorcycle.BrandId);
        //    return View(motoVM);
        //}

        // POST: Motorcycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(MotorcycleVM model)
        //{
        //    var formColletion = new FormCollection();
        //    formColletion.AllKeys;
        //    var form = FormCollection[model.Dealer.DealerId];
        //        //if (model == null)
        //        //throw new ArgumentNullException();

        //    //var dealerName = motorcycle.Dealer.Name;

        //    //var f = await db.Motorcycles.Where(d => d.Dealers == model.Dealers)..Select(new Dealer 
        //    //{
        //    //    Name = model.Dealer.Name,
        //    //    DealerId = model.Dealer.DealerId,
        //    //    Address = model.Dealer.Address,
        //    //    Brands = model.Dealer.Brands,
        //    //    PhoneNumber = model.Dealer.PhoneNumber
        //    //});

        //    var moto = db.Motorcycles
        //        .Where(m => m.MotorcycleId == model.Motorcycle.MotorcycleId).FirstOrDefault();

        //    if(moto != null)
        //    {
        //        moto.MotorcycleId = model.Motorcycle.MotorcycleId;
        //        moto.Model = model.Motorcycle.Model;
        //        moto.Price = model.Motorcycle.Price;
        //        moto.Brand = model.Motorcycle.Brand;
        //        moto.Dealers = model.Motorcycle.Dealers;
        //    }

        //    var findSelectedDealers = new Dealer
        //    {
        //        Name = model.Dealer.Name,
        //        DealerId = model.Dealer.DealerId,
        //        Address = model.Dealer.Address,
        //        Brands = model.Dealer.Brands,
        //        PhoneNumber = model.Dealer.PhoneNumber
        //    };

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(moto).State = EntityState.Modified;
        //        db.Entry(findSelectedDealers).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }


        //    var motorcycle2 = await db.Motorcycles.FindAsync(model.Motorcycle.MotorcycleId);
        //    //var allDealers = await db.Dealers.ToListAsync();
        //    //var dealers = await db.Motorcycles.Where(d => d.Dealers == model.Dealers).ToListAsync();
        //    MotorcycleVM motorcycle3 = new MotorcycleVM
        //    {
        //        Motorcycle = moto,
        //        Dealers = new List<Dealer>(),
        //        //Dealers = new List<Dealer>().Where(d => d.DealerId == findSelectedDealers.DealerId).ToList(),
        //        //AllDealers = allDealers
        //    };


        //    //var findSelectedDealers = db.Dealers.Where(d => d.Name == motorcycle.Dealer.Name).FirstOrDefault();

        //    //if (findSelectedDealers != null)
        //    //{
        //    //    findSelectedDealers.Name = motorcycle.Dealer.Name;
        //    //    findSelectedDealers.DealerId = motorcycle.Dealer.DealerId;
        //    //    findSelectedDealers.Address = motorcycle.Dealer.Address;
        //    //    findSelectedDealers.Brands = motorcycle.Dealer.Brands;
        //    //    findSelectedDealers.PhoneNumber = motorcycle.Dealer.PhoneNumber;
        //    //}

        //    ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", model.Motorcycle.BrandId);
        //    //ViewBag.DealerId = new SelectList(db.Dealers, "DealerId", "Name", motorcycle.Dealer.DealerId);
        //    return View(motorcycle3);
        //}

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
