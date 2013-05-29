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
    public class NomenkltrTchkController : Controller
    {
        private ISTODB_connection db = new ISTODB_connection();

        //
        // GET: /NomenkltrTchk/

        public ViewResult Index()
        {
            var nomenkltr_tchk = db.NOMENKLTR_TCHK.Include(n => n.TORGOVAJA_TOCHKA1).Include(n => n.SPISOK_TOVAROV);
            return View(nomenkltr_tchk.ToList());
        }

        //
        // GET: /NomenkltrTchk/Details/5

        public ViewResult Details(long id)
        {
            //NOMENKLTR_TCHK nomenkltr_tchk = db.NOMENKLTR_TCHK.Find(id);
            NOMENKLTR_TCHK nomenkltr_tchk = db.NOMENKLTR_TCHK.FirstOrDefault(c => c.TORGOVAJA_TOCHKA == id);
            return View(nomenkltr_tchk);
        }

        //
        // GET: /NomenkltrTchk/Create

        public ActionResult Create()
        {
            ViewBag.TORGOVAJA_TOCHKA = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI");
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR");
            return View();
        } 

        //
        // POST: /NomenkltrTchk/Create

        [HttpPost]
        public ActionResult Create(NOMENKLTR_TCHK nomenkltr_tchk)
        {
            if (ModelState.IsValid)
            {
                db.NOMENKLTR_TCHK.Add(nomenkltr_tchk);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.TORGOVAJA_TOCHKA = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", nomenkltr_tchk.TORGOVAJA_TOCHKA);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", nomenkltr_tchk.TOVAR);
            return View(nomenkltr_tchk);
        }
        
        //
        // GET: /NomenkltrTchk/Edit/5
 
        public ActionResult Edit(long id)
        {
            NOMENKLTR_TCHK nomenkltr_tchk = db.NOMENKLTR_TCHK.Find(id);
            ViewBag.TORGOVAJA_TOCHKA = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", nomenkltr_tchk.TORGOVAJA_TOCHKA);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", nomenkltr_tchk.TOVAR);
            return View(nomenkltr_tchk);
        }

        //
        // POST: /NomenkltrTchk/Edit/5

        [HttpPost]
        public ActionResult Edit(NOMENKLTR_TCHK nomenkltr_tchk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomenkltr_tchk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TORGOVAJA_TOCHKA = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", nomenkltr_tchk.TORGOVAJA_TOCHKA);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", nomenkltr_tchk.TOVAR);
            return View(nomenkltr_tchk);
        }

        //
        // GET: /NomenkltrTchk/Delete/5
 
        public ActionResult Delete(long id)
        {
            NOMENKLTR_TCHK nomenkltr_tchk = db.NOMENKLTR_TCHK.Find(id);
            return View(nomenkltr_tchk);
        }

        //
        // POST: /NomenkltrTchk/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            NOMENKLTR_TCHK nomenkltr_tchk = db.NOMENKLTR_TCHK.Find(id);
            db.NOMENKLTR_TCHK.Remove(nomenkltr_tchk);
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