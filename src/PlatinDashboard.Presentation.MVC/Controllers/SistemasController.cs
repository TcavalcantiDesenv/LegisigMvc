using PlatinDashboard.Infra.Data.Context;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class SistemasController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: Sistemas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sistemas/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Sistemas sistemas = db.Sistemas.Find(id);
        //    if (sistemas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sistemas);
        //}

        //// GET: Sistemas/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Sistemas/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Sistema")] Sistemas sistemas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Sistemas.Add(sistemas);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(sistemas);
        //}

        //// GET: Sistemas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Sistemas sistemas = db.Sistemas.Find(id);
        //    if (sistemas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sistemas);
        //}

        //// POST: Sistemas/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Sistema")] Sistemas sistemas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sistemas).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(sistemas);
        //}

        //// GET: Sistemas/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Sistemas sistemas = db.Sistemas.Find(id);
        //    if (sistemas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sistemas);
        //}

        //// POST: Sistemas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Sistemas sistemas = db.Sistemas.Find(id);
        //    db.Sistemas.Remove(sistemas);
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
