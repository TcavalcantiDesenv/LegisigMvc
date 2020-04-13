using PlatinDashboard.Application.Interfaces;
using PlatinDashboard.Application.ViewModels.UserViewModels;
using PlatinDashboard.Infra.CrossCutting.Identity.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    [Authorize]
    public class PerfilController : BaseController
    {
        private readonly ApplicationUserManager _userManager;

        public PerfilController(IUserAppService userAppService,
                                  ICompanyAppService companyAppService,
                                  ApplicationUserManager userManager)
                                  : base(userAppService, companyAppService)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(LoggedUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ProfileUserViewModel profileUserViewModel)
        {
            if (ModelState.IsValid)
            {
                profileUserViewModel = _userAppService.Update(profileUserViewModel);
                return Json(new { updated = true, view = RenderPartialView("_Editar", profileUserViewModel) });
            }
            return Json(new { updated = false, view = RenderPartialView("_Editar", profileUserViewModel) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TrocarSenha(ChangePasswordViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                string token = await _userManager.GeneratePasswordResetTokenAsync(userViewModel.UserId);
                var result = await _userManager.ResetPasswordAsync(userViewModel.UserId, token, userViewModel.Password);
                return Json(new { updated = result.Succeeded, view = RenderPartialView("_TrocarSenha", userViewModel) });
            }
            return Json(new { updated = false, view = RenderPartialView("_TrocarSenha", userViewModel) });
        }
    }
}