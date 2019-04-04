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
    public class ComunidadesController : Controller
    {
        private ComunidadesContext db = new ComunidadesContext();

        // GET: Comunidades
        public ActionResult Index()
        {
            return View(db.Comunidades.ToList());
        }

        // GET: Comunidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunidad comunidad = db.Comunidades.Find(id);
            if (comunidad == null)
            {
                return HttpNotFound();
            }
            return View(comunidad);
        }

        // GET: Comunidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comunidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComunidad,Nombre")] Comunidad comunidad)
        {
            if (ModelState.IsValid)
            {
                db.Comunidades.Add(comunidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comunidad);
        }

        // GET: Comunidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunidad comunidad = db.Comunidades.Find(id);
            if (comunidad == null)
            {
                return HttpNotFound();
            }
            return View(comunidad);
        }

        // POST: Comunidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComunidad,Nombre")] Comunidad comunidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comunidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comunidad);
        }

        // GET: Comunidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunidad comunidad = db.Comunidades.Find(id);
            if (comunidad == null)
            {
                return HttpNotFound();
            }
            return View(comunidad);
        }

        // POST: Comunidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comunidad comunidad = db.Comunidades.Find(id);
            db.Comunidades.Remove(comunidad);
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
