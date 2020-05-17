using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BibliotecaVirtual.Models;

namespace BibliotecaVirtual.Controllers
{
    public class LibroController : Controller
    {
        private BibliotecaEntities_PF db = new BibliotecaEntities_PF();

        // GET: Libro
        public ActionResult Index()
        {
            var libro = db.Libro.Include(l => l.Autor).Include(l => l.Editorial).Include(l => l.EstadoLibro).Include(l => l.Genero);
            return View(libro.ToList());
        }

        // GET: Libro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre");
            ViewBag.IdEditorial = new SelectList(db.Editorial, "IdEditorial", "Nombre");
            ViewBag.IdEstadoLibro = new SelectList(db.EstadoLibro, "IdEstadoLibro", "Nombre");
            ViewBag.IdGenero = new SelectList(db.Genero, "IdGenero", "Nombre");
            return View();
        }

        // POST: Libro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLibro,Nombre,IdAutor,IdEditorial,FechaPublicacion,IdEstadoLibro,Stock,PrecioUnitario,Imagen,IdGenero")] Libro libro)
        {
            HttpPostedFileBase fileBase = Request.Files[0];
            if (fileBase.ContentLength == 0)
            {
                ModelState.AddModelError("Imagen", "El campo Imagen es requerido");
            }
            else
            {
                if (fileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage image = new WebImage(fileBase.InputStream);
                    libro.Imagen = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "La Imagen debe ser de formato .jpg");
                }
            }
           
            if (ModelState.IsValid)
            {
                db.Libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", libro.IdAutor);
            ViewBag.IdEditorial = new SelectList(db.Editorial, "IdEditorial", "Nombre", libro.IdEditorial);
            ViewBag.IdEstadoLibro = new SelectList(db.EstadoLibro, "IdEstadoLibro", "Nombre", libro.IdEstadoLibro);
            ViewBag.IdGenero = new SelectList(db.Genero, "IdGenero", "Nombre", libro.IdGenero);
            return View(libro);
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", libro.IdAutor);
            ViewBag.IdEditorial = new SelectList(db.Editorial, "IdEditorial", "Nombre", libro.IdEditorial);
            ViewBag.IdEstadoLibro = new SelectList(db.EstadoLibro, "IdEstadoLibro", "Nombre", libro.IdEstadoLibro);
            ViewBag.IdGenero = new SelectList(db.Genero, "IdGenero", "Nombre", libro.IdGenero);
            return View(libro);
        }

        // POST: Libro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLibro,Nombre,IdAutor,IdEditorial,FechaPublicacion,IdEstadoLibro,Stock,PrecioUnitario,Imagen,IdGenero")] Libro libro)
        {

            byte[] imagenActual = null;
            HttpPostedFileBase fileBase = Request.Files[0];
            if (fileBase.ContentLength == 0)
            {
                imagenActual = db.Libro.SingleOrDefault(t => t.IdLibro == libro.IdLibro).Imagen;
                libro.Imagen = imagenActual;
            }
            else
            {
                if (fileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage image = new WebImage(fileBase.InputStream);
                    libro.Imagen = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "La Imagen debe ser de formato .jpg");
                }
            }
            if (ModelState.IsValid)
            {
                db.Libro.AddOrUpdate(libro);
                //db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", libro.IdAutor);
            ViewBag.IdEditorial = new SelectList(db.Editorial, "IdEditorial", "Nombre", libro.IdEditorial);
            ViewBag.IdEstadoLibro = new SelectList(db.EstadoLibro, "IdEstadoLibro", "Nombre", libro.IdEstadoLibro);
            ViewBag.IdGenero = new SelectList(db.Genero, "IdGenero", "Nombre", libro.IdGenero);
            return View(libro);
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libro.Find(id);
            db.Libro.Remove(libro);
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

        public ActionResult GetImage(int id)
        {
            Libro libro = db.Libro.Find(id);
            byte[] byteImage = libro.Imagen;
            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;
            return File(memoryStream, "image/jpg");
        }
    }
}
