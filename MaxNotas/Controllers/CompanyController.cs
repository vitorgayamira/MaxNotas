using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxNotas.Models;

namespace MaxNotas.Controllers
{
    public class CompanyController : Controller
    {
        private static IList<Company> companies = new List<Company>()
        {
            new Company()
            {
                CompanyId = 1,
                Name = "Nalicra LTDA" 
            },

            new Company()
            {
                CompanyId = 2,
                Name = "Gnireh Fabrica de Papel"
            },

            new Company()
            {
                CompanyId = 3,
                Name = "Larforue Fraudas"
            }


        };


        // GET: Company
        public ActionResult Index()
        {
            return View(companies);
        }


        // GET: Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            companies.Add(company);
            company.CompanyId = companies.Select(c => c.CompanyId).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(companies.Where(m => m.CompanyId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            companies.Remove(companies.Where(c => c.CompanyId == company.CompanyId).First());
            companies.Add(company);

            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(companies.Where(m => m.CompanyId == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(companies.Where(m => m.CompanyId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Company company)
        {
            companies.Remove(companies.Where(c => c.CompanyId == company.CompanyId).First());
            return RedirectToAction("Index");
        }
    }
}