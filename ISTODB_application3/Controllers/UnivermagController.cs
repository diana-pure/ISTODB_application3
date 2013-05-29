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
    public class UnivermagController : Controller
    {
        private ISTODB_connection db = new ISTODB_connection();

        //
        // GET: /Univermag/

        public ViewResult Index()
        {
            var univermag = db.UNIVERMAG.Include(u => u.PRODAZHI1).Include(u => u.TORGOVAJA_TOCHKA);
            return View(univermag.ToList());
        }

        //
        // GET: /Univermag/Details/5

        public ViewResult Details(long id)
        //public ViewResult Details(FormCollection collection)
        //public ViewResult Details(object keys)
        {
            //object[] keyValues = new object[](id, prodazhi_id);
            //UNIVERMAG univermag = db.UNIVERMAG.Find(keyValues);//(id, prodazhi_id);
            //DbSet<UNIVERMAG>
            //UNIVERMAG univermag = db.UNIVERMAG.Where((c => c.ID == id) && (d => d.PRODZHI == prodazhi_id)).SingleOrDefault();
 /*           object[] param = new object[2];
            param[0] = id;
            param[1] = prodazhi_id;
 */         UNIVERMAG univermag = db.UNIVERMAG.FirstOrDefault(c => c.ID == id);
            //UNIVERMAG univermag = db.UNIVERMAG.Find(param);
            return View(univermag);
            /*var query = "SELECT DISTINCT IMJA_TORG_TOCHKI," +
                                        "RAZMER_TORG_TCHK, CHISLO_PRILAVKOV " +
                                        "FROM UNIVERMAG JOIN (SELECT DISTINCT TORGOVAJA_TOCHKA.IMJA_TORG_TOCHKI, " + 
                                        "ID FROM TORGOVAJA_TOCHKA JOIN UNIVERMAG USING(ID)) connection" +
                                        "ON connection.ID = UNIVERMAG.ID WHERE (UNIVERMAG.ID = 56)";
            return View(unitOfWork.CourseRepository.GetWithRawSql(query, id).Single());*/
        }

        //
        // GET: /Univermag/Create

        public ActionResult Create()
        {
            ViewBag.PRODAZHI = new SelectList(db.PRODAZHI, "ID", "ID");
            ViewBag.ID = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI");
            return View();
        } 

        //
        // POST: /Univermag/Create

        [HttpPost]
        public ActionResult Create(UNIVERMAG univermag)
        {
            if (ModelState.IsValid)
            {
                db.UNIVERMAG.Add(univermag);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PRODAZHI = new SelectList(db.PRODAZHI, "ID", "ID", univermag.PRODAZHI);
            ViewBag.ID = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", univermag.ID);
            return View(univermag);
        }
        
        //
        // GET: /Univermag/Edit/5
 
        public ActionResult Edit(long id)
        {
            UNIVERMAG univermag = db.UNIVERMAG.Find(id);
            ViewBag.PRODAZHI = new SelectList(db.PRODAZHI, "ID", "ID", univermag.PRODAZHI);
            ViewBag.ID = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", univermag.ID);
            return View(univermag);
        }

        //
        // POST: /Univermag/Edit/5

        [HttpPost]
        public ActionResult Edit(UNIVERMAG univermag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(univermag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRODAZHI = new SelectList(db.PRODAZHI, "ID", "ID", univermag.PRODAZHI);
            ViewBag.ID = new SelectList(db.TORGOVAJA_TOCHKA, "ID", "IMJA_TORG_TOCHKI", univermag.ID);
            return View(univermag);
        }

        //
        // GET: /Univermag/Delete/5
 
        public ActionResult Delete(long id)
        {
            UNIVERMAG univermag = db.UNIVERMAG.Find(id);
            return View(univermag);
        }

        //
        // POST: /Univermag/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            UNIVERMAG univermag = db.UNIVERMAG.Find(id);
            db.UNIVERMAG.Remove(univermag);
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