using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibliotecaVirtual.Models;

namespace BibliotecaVirtual.Controllers
{
    public class EstadoLibroController : Controller
    {
        private BibliotecaEntities_PF db = new BibliotecaEntities_PF();

        // GET: EstadoLibro
        public ActionResult Index()
        {
            return View(db.EstadoLibro.ToList());
        }

        // GET: EstadoLibro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoLibro estadoLibro = db.EstadoLibro.Find(id);
            if (estadoLibro == null)
            {
                return HttpNotFound();
            }
            return View(estadoLibro);
        }

        // GET: EstadoLibro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoLibro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoLibro,Nombre")] EstadoLibro estadoLibro)
        {
            if (ModelState.IsValid)
            {
                db.EstadoLibro.Add(estadoLibro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoLibro);
        }

        // GET: EstadoLibro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoLibro estadoLibro = db.EstadoLibro.Find(id);
            if (estadoLibro == null)
            {
                return HttpNotFound();
            }
            return View(estadoLibro);
        }

        // POST: EstadoLibro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoLibro,Nombre")] EstadoLibro estadoLibro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoLibro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoLibro);
        }

        // GET: EstadoLibro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoLibro estadoLibro = db.EstadoLibro.Find(id);
            if (estadoLibro == null)
            {
                return HttpNotFound();
            }
            return View(estadoLibro);
        }

        // POST: EstadoLibro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoLibro estadoLibro = db.EstadoLibro.Find(id);
            db.EstadoLibro.Remove(estadoLibro);
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
