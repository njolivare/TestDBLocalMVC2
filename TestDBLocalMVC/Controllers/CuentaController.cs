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
    public class CuentaController : Controller
    {
        private ActorliningDBContexto db = new ActorliningDBContexto();

        //
        // GET: /Cuenta/

        public ActionResult Index()
        {
            var cuenta = db.Cuenta.Include(c => c.Cliente).Include(c => c.PlanCelular);

            return View(cuenta.ToList());
        }

        //
        // GET: /Cuenta/Details/5

        public ActionResult Details(int id = 0)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        //
        // GET: /Cuenta/Create

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nombre");
            ViewBag.PlanId = new SelectList(db.PlanCelular, "Id", "Codigo");
            return View();
        }

        //
        // POST: /Cuenta/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Cuenta.Add(cuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nombre", cuenta.ClienteId);
            ViewBag.PlanId = new SelectList(db.PlanCelular, "Id", "Codigo", cuenta.PlanId);
            return View(cuenta);
        }

        //
        // GET: /Cuenta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nombre", cuenta.ClienteId);
            ViewBag.PlanId = new SelectList(db.PlanCelular, "Id", "Codigo", cuenta.PlanId);
            return View(cuenta);
        }

        //
        // POST: /Cuenta/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nombre", cuenta.ClienteId);
            ViewBag.PlanId = new SelectList(db.PlanCelular, "Id", "Codigo", cuenta.PlanId);
            return View(cuenta);
        }

        //
        // GET: /Cuenta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        //
        // POST: /Cuenta/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            db.Cuenta.Remove(cuenta);
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