using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDBLocalMVC.Models;

namespace TestDBLocalMVC.Controllers
{
    public class PlanesController : Controller
    {
        private ActorliningDBContexto db = new ActorliningDBContexto();

        //
        // GET: /Planes/

        public ActionResult Index()
        {
            return View(db.PlanCelular.ToList());
        }

        //
        // GET: /Planes/Details/5

        public ActionResult Details(int id = 0)
        {
            PlanCelular plancelular = db.PlanCelular.Find(id);
            if (plancelular == null)
            {
                return HttpNotFound();
            }
            return View(plancelular);
        }

        //
        // GET: /Planes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Planes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanCelular plancelular)
        {
            if (ModelState.IsValid)
            {
                db.PlanCelular.Add(plancelular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plancelular);
        }

        //
        // GET: /Planes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PlanCelular plancelular = db.PlanCelular.Find(id);
            if (plancelular == null)
            {
                return HttpNotFound();
            }
            return View(plancelular);
        }

        //
        // POST: /Planes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlanCelular plancelular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plancelular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plancelular);
        }

        //
        // GET: /Planes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PlanCelular plancelular = db.PlanCelular.Find(id);
            if (plancelular == null)
            {
                return HttpNotFound();
            }
            return View(plancelular);
        }

        //
        // POST: /Planes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanCelular plancelular = db.PlanCelular.Find(id);
            db.PlanCelular.Remove(plancelular);
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