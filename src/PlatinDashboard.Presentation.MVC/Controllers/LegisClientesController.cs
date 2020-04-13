using Model.Entity;
using Model.Neg;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static PlatinDashboard.Presentation.MVC.Models.IdentityModels;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class LegisClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public LegisGeralNeg legisgeralNeg = new LegisGeralNeg();
        public Legis_ClienteNeg legisClientesNeg = new Legis_ClienteNeg();

        // GET: LegisClientes
        public ActionResult Index()
        {
            var ID = 30;
            var legis2 = legisClientesNeg.findAll().Where(p => p.Id == ID).ToList();
            var legis = legis2.OrderByDescending(p => p.Id).ToList();
            return View(legis.ToList());
        }

        // GET: LegisClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LegisClientes legisClientes = db.LegisClientes.Find(id);
            if (legisClientes == null)
            {
                return HttpNotFound();
            }
            return View(legisClientes);
        }

        // GET: LegisClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LegisClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IDCliente,IDProduto,IDSubProduto,IDLegisGeral,Aplicavel,Lei")] LegisClientes legisClientes)
        {
            if (ModelState.IsValid)
            {
                db.LegisClientes.Add(legisClientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(legisClientes);
        }

        // GET: LegisClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LegisClientes legisClientes = db.LegisClientes.Find(id);
            if (legisClientes == null)
            {
                return HttpNotFound();
            }
            return View(legisClientes);
        }

        // POST: LegisClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IDCliente,IDProduto,IDSubProduto,IDLegisGeral,Aplicavel,Lei")] LegisClientes legisClientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(legisClientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(legisClientes);
        }

        // GET: LegisClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LegisClientes legisClientes = db.LegisClientes.Find(id);
            if (legisClientes == null)
            {
                return HttpNotFound();
            }
            return View(legisClientes);
        }

        // POST: LegisClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LegisClientes legisClientes = db.LegisClientes.Find(id);
            db.LegisClientes.Remove(legisClientes);
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
