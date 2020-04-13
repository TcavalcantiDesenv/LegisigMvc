using Model.Neg;
using PlatinDashboard.Application.Interfaces;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {

        public HomeController(IUserAppService userAppService,
                                  ICompanyAppService companyAppService)
                                  : base(userAppService, companyAppService)
        {   }

        public ActionResult Index()
        {
            var ObjAcessosNeg = new AcessosNeg();
            ViewBag.Acessos = ObjAcessosNeg.findAll();

            if (CompanyUser.CompanyType == "Cliente")
            {
                Session.Remove("userId");
                Session.Remove("changeCompanyId");
                ViewBag.Cliente = (LoggedUser != null ? LoggedUser.Name : string.Empty);
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

    }

}