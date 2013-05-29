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
    public class SpisokTovarovController : Controller
    {
        private ISTODB_connection db = new ISTODB_connection();

        //
        // GET: /SpisokTovarov/

        public ViewResult Index()
        {
            return View(db.SPISOK_TOVAROV.ToList());
        }

        //
        // GET: /SpisokTovarov/Details/5

        public ViewResult Details(long id)
        {
            SPISOK_TOVAROV spisok_tovarov = db.SPISOK_TOVAROV.Find(id);
            return View(spisok_tovarov);
        }

        //
        // GET: /SpisokTovarov/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SpisokTovarov/Create

        [HttpPost]
        public ActionResult Create(SPISOK_TOVAROV spisok_tovarov)
        {
            if (ModelState.IsValid)
            {
                db.SPISOK_TOVAROV.Add(spisok_tovarov);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(spisok_tovarov);
        }
        
        //
        // GET: /SpisokTovarov/Edit/5
 
        public ActionResult Edit(long id)
        {
            SPISOK_TOVAROV spisok_tovarov = db.SPISOK_TOVAROV.Find(id);
            return View(spisok_tovarov);
        }

        //
        // POST: /SpisokTovarov/Edit/5

        [HttpPost]
        public ActionResult Edit(SPISOK_TOVAROV spisok_tovarov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spisok_tovarov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spisok_tovarov);
        }

        //
        // GET: /SpisokTovarov/Delete/5
 
        public ActionResult Delete(long id)
        {
            SPISOK_TOVAROV spisok_tovarov = db.SPISOK_TOVAROV.Find(id);
            return View(spisok_tovarov);
        }

        //
        // POST: /SpisokTovarov/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            SPISOK_TOVAROV spisok_tovarov = db.SPISOK_TOVAROV.Find(id);
            db.SPISOK_TOVAROV.Remove(spisok_tovarov);
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