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
    public class ProdavciController : Controller
    {
        private ISTODB_connection db = new ISTODB_connection();

        //
        // GET: /Prodavci/

        public ViewResult Index()
        {
            return View(db.PRODAVCY.ToList());
        }

        //
        // GET: /Prodavci/Details/5

        public ViewResult Details(long id)
        {
            PRODAVCY prodavcy = db.PRODAVCY.Find(id);
            return View(prodavcy);
        }

        //
        // GET: /Prodavci/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Prodavci/Create

        [HttpPost]
        public ActionResult Create(PRODAVCY prodavcy)
        {
            if (ModelState.IsValid)
            {
                db.PRODAVCY.Add(prodavcy);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(prodavcy);
        }
        
        //
        // GET: /Prodavci/Edit/5
 
        public ActionResult Edit(long id)
        {
            PRODAVCY prodavcy = db.PRODAVCY.Find(id);
            return View(prodavcy);
        }

        //
        // POST: /Prodavci/Edit/5

        [HttpPost]
        public ActionResult Edit(PRODAVCY prodavcy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodavcy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodavcy);
        }

        //
        // GET: /Prodavci/Delete/5
 
        public ActionResult Delete(long id)
        {
            PRODAVCY prodavcy = db.PRODAVCY.Find(id);
            return View(prodavcy);
        }

        //
        // POST: /Prodavci/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            PRODAVCY prodavcy = db.PRODAVCY.Find(id);
            db.PRODAVCY.Remove(prodavcy);
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