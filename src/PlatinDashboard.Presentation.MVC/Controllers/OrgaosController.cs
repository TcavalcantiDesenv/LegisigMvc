using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class OrgaosController : Controller
    {
        //private OrgaoContext db = new OrgaoContext();

        // GET: Orgaos
        public ActionResult Index()
        {
            return View();
        }

        //// GET: Orgaos/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Orgao orgao = db.Orgaos.Find(id);
        //    if (orgao == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(orgao);
        //}

        //// GET: Orgaos/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Orgaos/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Estados,Descricao")] Orgao orgao)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Orgaos.Add(orgao);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(orgao);
        //}

        //// GET: Orgaos/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Orgao orgao = db.Orgaos.Find(id);
        //    if (orgao == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(orgao);
        //}

        //// POST: Orgaos/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Estados,Descricao")] Orgao orgao)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(orgao).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(orgao);
        //}

        //// GET: Orgaos/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Orgao orgao = db.Orgaos.Find(id);
        //    if (orgao == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(orgao);
        //}

        //// POST: Orgaos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Orgao orgao = db.Orgaos.Find(id);
        //    db.Orgaos.Remove(orgao);
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
