using DataAccess.Enums;
using DataAccess.Interfeces;
using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    public class InvoiceController : Controller
    {
        readonly IRepInvoice repository;

        public InvoiceController()
        {
            repository = RepositoryBase.Get(UseRepositories.Invoice, "");
        }
        
        // GET: FacturaController
        public ActionResult Index()
        {
            Invoice[] invoice = repository.GetInvoice();

            if(invoice[0].IsError == true)
            {
                return View(new Invoice[] { new Invoice() } );
            }

            return View(invoice);
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
