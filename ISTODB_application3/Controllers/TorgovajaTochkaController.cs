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
    public class TorgovajaTochkaController : Controller
    {
        private ISTODB_connection db = new ISTODB_connection();

        //
        // GET: /TorgovajaTochka/

        public ViewResult Index()
        {
            return View(db.TORGOVAJA_TOCHKA.ToList());
        }

        //
        // GET: /TorgovajaTochka/Details/5

        public ViewResult Details(long id)
        {
            TORGOVAJA_TOCHKA torgovaja_tochka = db.TORGOVAJA_TOCHKA.Find(id);
            return View(torgovaja_tochka);
        }

        //
        // GET: /TorgovajaTochka/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TorgovajaTochka/Create

        [HttpPost]
        public ActionResult Create(TORGOVAJA_TOCHKA torgovaja_tochka)
        {
            if (ModelState.IsValid)
            {
                db.TORGOVAJA_TOCHKA.Add(torgovaja_tochka);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(torgovaja_tochka);
        }
        
        //
        // GET: /TorgovajaTochka/Edit/5
 
        public ActionResult Edit(long id)
        {
            TORGOVAJA_TOCHKA torgovaja_tochka = db.TORGOVAJA_TOCHKA.Find(id);
            return View(torgovaja_tochka);
        }

        //
        // POST: /TorgovajaTochka/Edit/5

        [HttpPost]
        public ActionResult Edit(TORGOVAJA_TOCHKA torgovaja_tochka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torgovaja_tochka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(torgovaja_tochka);
        }

        //
        // GET: /TorgovajaTochka/Delete/5
 
        public ActionResult Delete(long id)
        {
            TORGOVAJA_TOCHKA torgovaja_tochka = db.TORGOVAJA_TOCHKA.Find(id);
            return View(torgovaja_tochka);
        }

        //
        // POST: /TorgovajaTochka/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            TORGOVAJA_TOCHKA torgovaja_tochka = db.TORGOVAJA_TOCHKA.Find(id);
            db.TORGOVAJA_TOCHKA.Remove(torgovaja_tochka);
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