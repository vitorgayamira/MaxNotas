﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxNotas.Contexts;
using MaxNotas.Models;
using System.Net;
using System.Data.Entity;

namespace MaxNotas.Controllers
{
    public class FabricanteController : Controller
    {
        private EFContext context = new EFContext();
        
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Name));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fabricante).State =
                EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        // GET: Testes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.
            Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.
            Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}