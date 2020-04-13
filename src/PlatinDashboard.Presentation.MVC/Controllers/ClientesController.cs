using Model.Entity;
using Model.Neg;
using PlatinDashboard.Presentation.MVC.MvcFilters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class ClientesController : Controller
    {
        ClientesNeg objClientesNeg;

        public ClientesController()
        {
            objClientesNeg = new ClientesNeg();
        }
        // GET: Clientes
        public ActionResult Index()
        {
            List<Clientes> lista = objClientesNeg.findAll();
            return View(lista);
        }

        [HttpGet]
        [ClaimsAuthorize("CompanyType", "Master")]
        public ActionResult Details(int id)
        {
            Clientes objCliente = new Clientes(id);
            objClientesNeg.find(objCliente); 
            return View(objCliente);
        }

        [HttpPost]
        [ClaimsAuthorize("CompanyType", "Master")]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Clientes objClientes)
        {
            objClientesNeg.update(objClientes);
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
