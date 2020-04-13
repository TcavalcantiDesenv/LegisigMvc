using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Entity;
using PlatinDashboard.Presentation.MVC.Models;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class AmbitoesController : Controller
    {
       // private AmbitoContext db = new AmbitoContext();

        // GET: Ambitoes
        public ActionResult Index()
        {
            return View();
        }

        //// GET: Ambitoes/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ambito ambito = db.Ambitoes.Find(id);
        //    if (ambito == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ambito);
        //}

        //// GET: Ambitoes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Ambitoes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Descricao,Estados")] Ambito ambito)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Ambitoes.Add(ambito);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(ambito);
        //}

        //// GET: Ambitoes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ambito ambito = db.Ambitoes.Find(id);
        //    if (ambito == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ambito);
        //}

        //// POST: Ambitoes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Descricao,Estados")] Ambito ambito)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(ambito).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(ambito);
        //}

        //// GET: Ambitoes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ambito ambito = db.Ambitoes.Find(id);
        //    if (ambito == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ambito);
        //}

        //// POST: Ambitoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Ambito ambito = db.Ambitoes.Find(id);
        //    db.Ambitoes.Remove(ambito);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
