using System;
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
    public class InvoiceController : Controller
    {
        private EFContext context = new EFContext();
        
        // GET: Invoices
        public ActionResult Index()
        {
            return View(context.Invoices.OrderBy(c => c.Name));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Invoice invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                context.Entry(invoice).State =
                EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Testes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Invoice invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Invoice invoice = context.Invoices.
            Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Invoice invoice = context.Invoices.
            Find(id);
            context.Invoices.Remove(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}