using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web.Helpers;
using BibliotecaVirtual.Models;

namespace BibliotecaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private BibliotecaEntities_PF db = new BibliotecaEntities_PF();

        public ActionResult Index()
        {
            var libro = db.Libro.Include(l => l.Autor).Include(l => l.Editorial).Include(l => l.EstadoLibro).Include(l => l.Genero);
            return View(libro.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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