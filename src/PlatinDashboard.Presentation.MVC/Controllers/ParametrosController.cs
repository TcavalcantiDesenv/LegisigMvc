using PlatinDashboard.Presentation.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static PlatinDashboard.Presentation.MVC.Models.IdentityModels;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class ParametrosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Parametros
        public ActionResult Index(int? pagina, int id, string busca)
        {
            var parametros = new List<Parametros>();
            parametros = db.Parametros.OrderByDescending(p => p.Id).Where(p => p.IDLegisGeral == id).ToList();
            ViewBag.param = parametros;
            return View();
        }
    }
}