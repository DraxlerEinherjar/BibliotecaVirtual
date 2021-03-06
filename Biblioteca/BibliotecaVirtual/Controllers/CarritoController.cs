﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;
using BibliotecaVirtual.Models;

namespace BibliotecaVirtual.Controllers
{
    public class CarritoController : Controller
    {
        private BibliotecaEntities_PF db = new BibliotecaEntities_PF();
        // GET: Carrito
        public ActionResult Index()
        {
            List<Libro> libros = new List<Libro>();
            var session = HttpContext.Session["carrito"];
            if (session != null)
            {
                libros = HttpContext.Session["carrito"] as List<Libro>;
            }
            ViewBag.ids = libros.GroupBy(g => g.IdLibro).Select(s => s.Key).ToList();
            return View(libros.ToList());
        }

        public ActionResult Compra()
        {
            //List<Libro> libros = new List<Libro>();
            //var session = HttpContext.Session["carrito"];
            //if (session != null)
            //{
            //    libros = HttpContext.Session["carrito"] as List<Libro>;
            //}
            //ViewBag.ids = libros.GroupBy(g => g.IdLibro).Select(s => s.Key).ToList();
            //return View(libros.ToList());
            return View();
        }
    }
}