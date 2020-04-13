using Model.Neg;
using PagedList;
using PlatinDashboard.Presentation.MVC.MvcFilters;
using System;
using System.Linq;
using System.Web.Mvc;
using PlatinDashboard.Application.Administrativo.Interfaces;
using PlatinDashboard.Application.Interfaces;
using PlatinDashboard.Infra.CrossCutting.Identity.Configuration;
using System.Collections.Generic;
using Model.Entity;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class LicencasController : BaseController
    {
        public LicensasNeg licensasNeg = new LicensasNeg();
        public ClientesNeg clientesNeg = new ClientesNeg();
        private readonly ApplicationUserManager _userManager;
        private readonly IClienteAppService _clienteAppService;
        private readonly IVideoAppService _videoAppService;
        public Legis_ClienteNeg legisClientelNeg = new Legis_ClienteNeg();
        public LegisGeralNeg legisGeralNeg = new LegisGeralNeg();
        public LegisClienteNeg legisClienteNeg = new LegisClienteNeg();

        public LicencasController(ICompanyAppService companyAppService,
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
        public ActionResult Index(string codci, string Id, string param, int? pagina, string busca)
        {
            var nivel = LoggedUser.UserType;
   //         int cliente = Convert.ToInt32(LoggedUser.UserType);
   
           var licenca = licensasNeg.findAll().ToList();
            if (nivel == "G-1" || nivel == "G-2" || nivel == "G-3")
            {
                //          int cliente = Convert.ToInt32(Session["CodCli"].ToString());
                //    licensa = licensasNeg.findAll().Where(p => p.IdCliente == cliente).ToList();
              licenca = licensasNeg.findAll().Where(p => p.IdCliente == LoggedUser.CompanyId).ToList();
            }
            else
            {
                licenca = licensasNeg.findAll().ToList();
            }
            int pageSize = 50;
            int pageNumber = (pagina ?? 1);
            if (licenca.Count() < pageSize * pageNumber) pageNumber = 1;
            return View(licenca.ToPagedList(pageNumber, pageSize));
        }
       
    }
}