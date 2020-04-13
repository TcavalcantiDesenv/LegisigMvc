using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PlatinDashboard.Domain.Entities;
using PlatinDashboard.Infra.Data.Context;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class ValidadoresController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: Validadores
        public ActionResult Index()
        {
            var clientes = db.Clientes.Select(c => new
            {
                Id = c.Id,
                NomeFantasia = c.NomeFantasia
            }).ToList();

            List<Clientes> data = db.Clientes.ToList();// objManufatureNeg.findAll().ToList();
            ViewBag.Clientes = new SelectList(data, "Id", "NomeFantasia");
        //    ViewBag.Clientes = new SelectList(clientes, "Id", "NomeFantasia");

            return View(db.Validadores.ToList());
        }

        // GET: Validadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Validadores validadores = db.Validadores.Find(id);
            if (validadores == null)
            {
                return HttpNotFound();
            }
            return View(validadores);
        }

        // GET: Validadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Validadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCliente,Usuário,Operacao,Email")] Validadores validadores)
        {
            if (ModelState.IsValid)
            {
                db.Validadores.Add(validadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(validadores);
        }

        // GET: Validadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Validadores validadores = db.Validadores.Find(id);
            if (validadores == null)
            {
                return HttpNotFound();
            }
            return View(validadores);
        }

        // POST: Validadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCliente,Usuário,Operacao,Email")] Validadores validadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(validadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(validadores);
        }

        // GET: Validadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Validadores validadores = db.Validadores.Find(id);
            if (validadores == null)
            {
                return HttpNotFound();
            }
            return View(validadores);
        }

        // POST: Validadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Validadores validadores = db.Validadores.Find(id);
            db.Validadores.Remove(validadores);
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
