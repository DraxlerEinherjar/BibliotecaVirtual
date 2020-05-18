﻿using System;
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

        public ActionResult AgregarAlCarrito(int? id)
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
            var session = HttpContext.Session["carrito"];
            if (session == null)
            {
                List<Libro> libros = new List<Libro>();
                libros.Add(libro);
                HttpContext.Session["carrito"] = libros;
            }
            else
            {
                List<Libro> libros = HttpContext.Session["carrito"] as List<Libro>;
                libros.Add(libro);
                HttpContext.Session["carrito"] = libros;
            }
            return this.View();
        }

    }
}