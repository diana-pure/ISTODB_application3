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
    public class ProdazhiController : Controller
    {
        private ISTODB_connection db = new ISTODB_connection();

        //
        // GET: /Prodazhi/

        public ViewResult Index()
        {
            var prodazhi = db.PRODAZHI.Include(p => p.POKUPATELI).Include(p => p.PRODAVCY).Include(p => p.SPISOK_TOVAROV);
//            var query = from t in db.PRODAZHI where (t.KOLICHESTVO > 10) select t;
            var query = from prod in db.PRODAZHI
                        join tov in db.SPISOK_TOVAROV
                        on prod.TOVAR equals tov.ID
                        join ceny in db.CENY_TOCHKI
                        on tov.ID equals ceny.TOVAR
                        where (ceny.CENA > 100000)
                        select prod;

//            return View(prodazhi.ToList());
            return View(query.ToList());
        }

        //
        // GET: /Prodazhi/Details/5

        public ViewResult Details(long id)
        {
            PRODAZHI prodazhi = db.PRODAZHI.Find(id);
            return View(prodazhi);
        }

        //
        // GET: /Prodazhi/Create

        public ActionResult Create()
        {
            ViewBag.POKUPATEL = new SelectList(db.POKUPATELI, "ID", "IMJA_POKUPATELJA");
            ViewBag.PRODAVEC = new SelectList(db.PRODAVCY, "ID", "IMJA_PRODAVCA");
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR");
            return View();
        } 

        //
        // POST: /Prodazhi/Create

        [HttpPost]
        public ActionResult Create(PRODAZHI prodazhi)
        {
            if (ModelState.IsValid)
            {
                db.PRODAZHI.Add(prodazhi);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.POKUPATEL = new SelectList(db.POKUPATELI, "ID", "IMJA_POKUPATELJA", prodazhi.POKUPATEL);
            ViewBag.PRODAVEC = new SelectList(db.PRODAVCY, "ID", "IMJA_PRODAVCA", prodazhi.PRODAVEC);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", prodazhi.TOVAR);
            return View(prodazhi);
        }
        
        //
        // GET: /Prodazhi/Edit/5
 
        public ActionResult Edit(long id)
        {
            PRODAZHI prodazhi = db.PRODAZHI.Find(id);
            ViewBag.POKUPATEL = new SelectList(db.POKUPATELI, "ID", "IMJA_POKUPATELJA", prodazhi.POKUPATEL);
            ViewBag.PRODAVEC = new SelectList(db.PRODAVCY, "ID", "IMJA_PRODAVCA", prodazhi.PRODAVEC);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", prodazhi.TOVAR);
            return View(prodazhi);
        }

        //
        // POST: /Prodazhi/Edit/5

        [HttpPost]
        public ActionResult Edit(PRODAZHI prodazhi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodazhi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.POKUPATEL = new SelectList(db.POKUPATELI, "ID", "IMJA_POKUPATELJA", prodazhi.POKUPATEL);
            ViewBag.PRODAVEC = new SelectList(db.PRODAVCY, "ID", "IMJA_PRODAVCA", prodazhi.PRODAVEC);
            ViewBag.TOVAR = new SelectList(db.SPISOK_TOVAROV, "ID", "TOVAR", prodazhi.TOVAR);
            return View(prodazhi);
        }

        //
        // GET: /Prodazhi/Delete/5
 
        public ActionResult Delete(long id)
        {
            PRODAZHI prodazhi = db.PRODAZHI.Find(id);
            return View(prodazhi);
        }

        //
        // POST: /Prodazhi/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            PRODAZHI prodazhi = db.PRODAZHI.Find(id);
            db.PRODAZHI.Remove(prodazhi);
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