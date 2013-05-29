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
    public class CenyTochkiController : Controller
    {
        private ISTODB_connection db = new ISTODB_connection();

        //
        // GET: /CenyTochki/

        public ViewResult Index()
        {
            var ceny_tochki = db.CENY_TOCHKI.Include(c => c.TORGOVAJA_TOCHKA1).Include(c => c.SPISOK_TOVAROV);
            return View(ceny_tochki.ToList());
        }

        //
        // GET: /CenyTochki/Details/5

        public ViewResult Details(long id)
        {
            CENY_TOCHKI ceny_tochki = db.CENY_TOCHKI.Find(id);
            return View(ceny_tochki);
        }

        //
        // GET: /CenyTochki/Create

        public ActionResult Create()
        {
            ViewBag.TORGOVAJA_TOCHKA = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI");
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR");
            return View();
        } 

        //
        // POST: /CenyTochki/Create

        [HttpPost]
        public ActionResult Create(CENY_TOCHKI ceny_tochki)
        {
            if (ModelState.IsValid)
            {
                db.CENY_TOCHKI.Add(ceny_tochki);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.TORGOVAJA_TOCHKA = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", ceny_tochki.TORGOVAJA_TOCHKA);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", ceny_tochki.TOVAR);
            return View(ceny_tochki);
        }
        
        //
        // GET: /CenyTochki/Edit/5
 
        public ActionResult Edit(long id)
        {
            CENY_TOCHKI ceny_tochki = db.CENY_TOCHKI.Find(id);
            ViewBag.TORGOVAJA_TOCHKA = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", ceny_tochki.TORGOVAJA_TOCHKA);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", ceny_tochki.TOVAR);
            return View(ceny_tochki);
        }

        //
        // POST: /CenyTochki/Edit/5

        [HttpPost]
        public ActionResult Edit(CENY_TOCHKI ceny_tochki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ceny_tochki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TORGOVAJA_TOCHKA = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", ceny_tochki.TORGOVAJA_TOCHKA);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", ceny_tochki.TOVAR);
            return View(ceny_tochki);
        }

        //
        // GET: /CenyTochki/Delete/5
 
        public ActionResult Delete(long id)
        {
            CENY_TOCHKI ceny_tochki = db.CENY_TOCHKI.Find(id);
            return View(ceny_tochki);
        }

        //
        // POST: /CenyTochki/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            CENY_TOCHKI ceny_tochki = db.CENY_TOCHKI.Find(id);
            db.CENY_TOCHKI.Remove(ceny_tochki);
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