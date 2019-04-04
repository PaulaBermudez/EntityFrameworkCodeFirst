using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComunidadesCodeFirst.Data;
using ComunidadesCodeFirst.Models;

namespace ComunidadesCodeFirst.Controllers
{
    public class ProvinciasController : Controller
    {
        private ComunidadesContext db = new ComunidadesContext();

        // GET: Provincias
        public ActionResult Index()
        {
            var provincias = db.Provincias.Include(p => p.comunidad);
            return View(provincias.ToList());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            ViewBag.IdComunidad = new SelectList(db.Comunidades, "IdComunidad", "Nombre");
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProvincia,Nombre,IdComunidad")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Provincias.Add(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdComunidad = new SelectList(db.Comunidades, "IdComunidad", "Nombre", provincia.IdComunidad);
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdComunidad = new SelectList(db.Comunidades, "IdComunidad", "Nombre", provincia.IdComunidad);
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProvincia,Nombre,IdComunidad")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdComunidad = new SelectList(db.Comunidades, "IdComunidad", "Nombre", provincia.IdComunidad);
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincia provincia = db.Provincias.Find(id);
            db.Provincias.Remove(provincia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
