using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Model.Entity;
using Model.Neg;
using PlatinDashboard.Application.Administrativo.Interfaces;
using PlatinDashboard.Application.Interfaces;
using PlatinDashboard.Application.ViewModels.CompanyViewModels;
using PlatinDashboard.Application.ViewModels.UserViewModels;
using PlatinDashboard.Infra.CrossCutting.Identity.Configuration;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{

    [AllowAnonymous]
    public class AcessoController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly IClienteAppService _clienteAppService;

        public AcessoController(IUserAppService userAppService,
                                ICompanyAppService companyAppService,
                                IClienteAppService clienteAppService,
                                ApplicationSignInManager signInManager,
                                ApplicationUserManager userManager)
                                : base(userAppService, companyAppService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _clienteAppService = clienteAppService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                if (_signInManager != null && HttpContext.GetOwinContext().Get<ApplicationSignInManager>() == null)
                {
                    HttpContext.GetOwinContext().Set<ApplicationSignInManager>(_signInManager);
                }

                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            if (!string.IsNullOrEmpty(User.Identity.GetUserId()))
            {
                return RedirectToLocal(returnUrl);
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel loginViewModel, string returnUrl)
        {
            Session["IDAcesso"] = "";
            var ID = 0;
            var ObjAcessosNeg = new AcessosNeg();
            var acessos = new Acessos();

            // Conexão utilizando proxy 
            System.Net.ServicePointManager.Expect100Continue = false;
            string ipUser = string.Empty;
            try
            {
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
                {
                    // Conexão sem utilizar proxy 
                    ipUser = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    ipUser = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
            }
            catch
            {
                ipUser = string.Empty;
            }

            //Retornando o IP capturado que estava guardado na variável de servidor 
            //string host = Dns.GetHostName();
            //string ip = Dns.GetHostAddresses(host)[2].ToString();
            //string url = "http://checkip.dyndns.org";
            //System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            //System.Net.WebResponse resp = req.GetResponse();
            //System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            //string response = sr.ReadToEnd().Trim();
            //string[] a = response.Split(':');
            //string a2 = a[1].Substring(1);
            //string[] a3 = a2.Split('<');
            //string a4 = a3[0];

            if (ModelState.IsValid)
            {
                var applicationUser = _userManager.FindByName(loginViewModel.UserName);

                if (applicationUser != null)
                {
                    acessos.Nome = applicationUser.Name;
                    acessos.DataEntrada = DateTime.Now;
                    acessos.IP = ipUser;
                    acessos.Usuario = applicationUser.UserName;
                    acessos.Empresa = applicationUser.Name + " " + applicationUser.LastName;
                    ObjAcessosNeg.create(acessos);
                    ID = ObjAcessosNeg.buscarUltimoID();
                    Session["IDAcesso"] = ID.ToString();
                }
                //Caso o usuário não exista ele deve verificar se o usuario existe na base administrativa
                if (applicationUser == null)
                {
                    ModelState.AddModelError("", "Conta bloqueada ou inexistente.");
                }
                //Verificando se conexão da empresa está configurada
                else if (!_companyAppService.GetById(applicationUser.CompanyId).CheckConnectionConfiguration())
                {
                    ModelState.AddModelError("", "O seu acesso ao Portal ainda não está habilitado, por favor entre em contato com o HelpDesk.");
                }
                //Verificando se a conta esta bloqueada
                else if (!applicationUser.Active)
                {
                    ModelState.AddModelError("", "Conta bloqueada ou inexistente.");
                }
                else
                {
                    var result = SignInManager.PasswordSignIn(loginViewModel.UserName, loginViewModel.Password, true, true);
                    switch (result)
                    {
                        case SignInStatus.Success:
                            return RedirectToLocal(returnUrl);
                        case SignInStatus.LockedOut:
                            ModelState.AddModelError("", "Conta bloqueada por várias tentativas de acesso.");
                            break;
                        case SignInStatus.Failure:
                            ModelState.AddModelError("", "Login ou senha Inválido.");
                            break;
                        default:
                            ModelState.AddModelError("", "Tentativa inválida de login.");
                            break;
                    }
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(loginViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Sair()
        {
            var ObjAcessosNeg = new AcessosNeg();

            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    var saiID = Session["IDAcesso"].ToString();
                    ObjAcessosNeg.AtualizaSaida(saiID);
                }
                catch (Exception ex)
                {

                }
                _signInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            }
            return RedirectToAction("Index", "Acesso");
        }

    }
}