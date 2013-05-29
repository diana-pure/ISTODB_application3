using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISTODB_application3.Models;

namespace ISTODB_application3.Controllers
{ 
    public class PokupateliController : Controller
    {
        private ISTODB_connection db = new ISTODB_connection();

        //
        // GET: /Pokupateli/

        public ViewResult Index()
        {
            return View(db.POKUPATELI.ToList());
        }

        //
        // GET: /Pokupateli/Details/5

        public ViewResult Details(long id)
        {
            POKUPATELI pokupateli = db.POKUPATELI.Find(id);
            return View(pokupateli);
        }

        //
        // GET: /Pokupateli/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Pokupateli/Create

        [HttpPost]
        public ActionResult Create(POKUPATELI pokupateli)
        {
            if (ModelState.IsValid)
            {
                db.POKUPATELI.Add(pokupateli);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(pokupateli);
        }
        
        //
        // GET: /Pokupateli/Edit/5
 
        public ActionResult Edit(long id)
        {
            POKUPATELI pokupateli = db.POKUPATELI.Find(id);
            return View(pokupateli);
        }

        //
        // POST: /Pokupateli/Edit/5

        [HttpPost]
        public ActionResult Edit(POKUPATELI pokupateli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokupateli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokupateli);
        }

        //
        // GET: /Pokupateli/Delete/5
 
        public ActionResult Delete(long id)
        {
            POKUPATELI pokupateli = db.POKUPATELI.Find(id);
            return View(pokupateli);
        }

        //
        // POST: /Pokupateli/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            POKUPATELI pokupateli = db.POKUPATELI.Find(id);
            db.POKUPATELI.Remove(pokupateli);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}