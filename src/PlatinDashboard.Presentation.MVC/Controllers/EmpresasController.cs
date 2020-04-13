using PlatinDashboard.Application.Administrativo.Interfaces;
using PlatinDashboard.Application.Interfaces;
using PlatinDashboard.Application.ViewModels.CompanyViewModels;
using PlatinDashboard.Infra.CrossCutting.Identity.Configuration;
using PlatinDashboard.Presentation.MVC.Helpers;
using PlatinDashboard.Presentation.MVC.MvcFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    [Authorize]
    public class EmpresasController : BaseController
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IClienteAppService _clienteAppService;
        private readonly IVideoAppService _videoAppService;

        public EmpresasController(ICompanyAppService companyAppService,
                                  IUserAppService userAppService,
                                  IClienteAppService clienteAppService,
                                  IVideoAppService videoAppService,
                                  ApplicationUserManager userManager)
                                  : base(userAppService, companyAppService)
        {
            _userManager = userManager;
            _clienteAppService = clienteAppService;
            _videoAppService = videoAppService;
        }

        [HttpGet]
        [ClaimsAuthorize("CompanyType", "Master")]
        public ActionResult Index()
        {
            var companyViewModels = _companyAppService.GetAllClients();
            ViewBag.Cliente = (Session["userId"] == null ? "" : LoggedUser.Name);
            return View(companyViewModels);
        }

        [HttpGet]
        [ClaimsAuthorize("CompanyType", "Master")]
        public ActionResult Nova()
        {
            ViewBag.Providers = ListGeneratorHelper.GenerateProviders();
            var companyViewModels = _companyAppService.GetAll();
            var redeViewModels = _clienteAppService.BuscarRedesAtivas();
            //Filtrando as redes que ainda não cadastradas na base do Portal
            redeViewModels = redeViewModels.Where(r => !companyViewModels.Any(c => c.CustomerCode == r.CodigoCliente));
            ViewBag.RedeViewModels = new SelectList(redeViewModels, "CodigoCliente", "NomeFantasia");

         //   ClientesNeg clientes = new ClientesNeg();
         //   ViewBag.RedeViewModels = clientes.findAll().ToList();
            ViewBag.RedeViewModels = new SelectList(ViewBag.RedeViewModels, "Id", "RazaoSocial");
            return View(new CreateCompanyViewModel());
        }

        [HttpPost]
        [ClaimsAuthorize("CompanyType", "Master")]
        [ValidateAntiForgeryToken]
        public ActionResult Nova(CreateCompanyViewModel companyViewModel)
        {
    //        Verificando se a empresa está sendo importada do sistema administrativo
            if (ModelState.IsValid || companyViewModel.ImportedFromAdministrative)
            {
                //Se caso for importação deve buscar os dados da empresa na base administrativa
                if (companyViewModel.ImportedFromAdministrative)
                {
                    //var rede =  _clienteAppService.BuscarRedePorCodigoCliente(companyViewModel.CustomerCode.Value);
                    ////Buscando o usuário da matriz da rede
                    //var usuario = _clienteAppService.BuscarUsuarioPorId(rede.Id);
                    //companyViewModel.GetRedeInformation(rede);
                    //companyViewModel.GetUsuarioInformation(usuario);
                }
                else
                {
                    companyViewModel.CustomerCode = null;
                }
                var userTuple = _userAppService.VerifyUser(companyViewModel);

           //     ClientesNeg clientes2 = new ClientesNeg();
           //List<Clientes> modelocliente = clientes2.findAll().Where(p => p.Id == companyViewModel.CustomerCode).ToList();


                //Verificando disponibilidade de login e e-mail
                if (userTuple.Item2)
                {
                    //Criando Empresa
                    companyViewModel.CompanyType = "Cliente";
                    var codigo = companyViewModel.CustomerCode;
                    companyViewModel.CompanyId = Convert.ToInt32(codigo);
                    companyViewModel.AdministrativeCode = Convert.ToInt32(codigo);
                    companyViewModel.UserName = "cliente";
                    companyViewModel.Password = "cliente";
                    companyViewModel.FirstName = "Não Disponivel";
                    companyViewModel.LastName = "Não Disponivel";
                    companyViewModel.CreatedAt = DateTime.Now;
               //     companyViewModel.Name = modelocliente[0].RazaoSocial;// companyViewModel.DatabaseServer;// "Cadastro Automatico";
                    companyViewModel.Email = "cliente@mail.com";
                    
                    companyViewModel = _companyAppService.Add(companyViewModel);
                    //Criando primeiro Usuário SubAdmin da empresa
                    var passwordHash = _userManager.PasswordHasher.HashPassword(companyViewModel.Password);
                    _userAppService.Add(companyViewModel, passwordHash);
                    return RedirectToAction("Index", "Empresas");
                }
                else
                {
                    //Adicionando mensagem de erro
                    ModelState.AddModelError(userTuple.Item3, userTuple.Item4);
                }
            }
            ViewBag.Providers = ListGeneratorHelper.GenerateProviders();
            var companyViewModels = _companyAppService.GetAll();
            var redeViewModels = _clienteAppService.BuscarRedesAtivas();
            //Filtrando as redes que ainda não cadastradas na base do Portal
            redeViewModels = redeViewModels.Where(r => !companyViewModels.Any(c => c.CustomerCode == r.CodigoCliente));
            ViewBag.RedeViewModels = new SelectList(redeViewModels, "CodigoCliente", "NomeFantasia");

  //          ClientesNeg clientes = new ClientesNeg();
    //        ViewBag.RedeViewModels = clientes.findAll().Where(p => p.Id == companyViewModel.CustomerCode).ToList();
            ViewBag.RedeViewModels = new SelectList(ViewBag.RedeViewModels, "Id", "RazaoSocial");

            return View(companyViewModel);
        }

        [HttpGet]
        [ClaimsAuthorize("CompanyType", "Master")]
        public ActionResult Detalhes(int? id)
        {
            var nivel = Session["Nivel"].ToString();
            if (nivel != "Gestor" && id == 1)
            {
                return RedirectToAction("Index", "Empresas");
            }
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var companyViewModel = _companyAppService.GetById(id.Value);
            if (companyViewModel == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            ViewBag.UserViewModels = _userAppService.GetByCompany(id.Value);
            ViewBag.CompanyViewModel = companyViewModel;
            ViewBag.CompanyCharts = _companyAppService.GetCompanyCharts(id.Value);
            ViewBag.Providers = ListGeneratorHelper.GenerateProviders();
            return View(companyViewModel);
        }

        [HttpPost]
        [ClaimsAuthorize("CompanyType", "Master")]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CompanyViewModel companyViewModel)
        {
            ViewBag.Providers = ListGeneratorHelper.GenerateProviders();
            if (ModelState.IsValid)
            {
                companyViewModel = _companyAppService.Update(companyViewModel);
                return Json(new { updated = true, view = RenderPartialView("_Editar", companyViewModel) });
            }
            return Json(new { updated = false, view = RenderPartialView("_Editar", companyViewModel) });
        }

        [HttpGet]
        [ClaimsAuthorize("CompanyType", "Master")]
        public ActionResult ModalRemover(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var company = _companyAppService.GetById(id.Value);
            if (company == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);            
            return PartialView("_ModalRemoverEmpresa", company);
        }

        [HttpPost]
        [ClaimsAuthorize("CompanyType", "Master")]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int? companyId)
        {
            var nivel = Session["Nivel"].ToString();
            if (nivel != "Gestor" && companyId == 1)
            {
                return RedirectToAction("Index", "Empresas");
            }
            if (companyId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var company = _companyAppService.GetById(companyId.Value);
            if (company == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //Removendo os videos cadastrados pela empresa
            var videoViewModels = _videoAppService.GetByCompany(companyId.Value);
            foreach (var videoViewModel in videoViewModels)
            {
                _videoAppService.Remove(videoViewModel.VideoId);
                if (System.IO.File.Exists(Server.MapPath(videoViewModel.FileName)))
                {
                    System.IO.File.Delete(Server.MapPath(videoViewModel.FileName));
                }
            }
            _companyAppService.Remove(company.CompanyId);
            return Json(new { deleted = true, companyId = company.CompanyId });
        }

        [HttpPost]
        [ClaimsAuthorize("CompanyType", "Master")]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAcessoGraficos(CompanyChartViewModel companyChartViewModel)
        {
            if (ModelState.IsValid)
            {
                _companyAppService.UpdateCompanyCharts(companyChartViewModel);
                ViewBag.CompanyViewModel = _companyAppService.GetById(companyChartViewModel.CompanyId);
                var companyCharts = _companyAppService.GetCompanyCharts(companyChartViewModel.CompanyId);
                return Json(new { updated = true, view = RenderPartialView("_EditarAcessoGraficos", companyCharts) });
            }
            ViewBag.CompanyViewModel = _companyAppService.GetById(companyChartViewModel.CompanyId);
            return Json(new { updated = false, view = RenderPartialView("_EditarAcessoGraficos", companyChartViewModel) });
        }
    }
}