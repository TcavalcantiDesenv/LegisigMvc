using Model.Entity;
using Model.Neg;
using PlatinDashboard.Application.Farmacia.Interfaces;
using PlatinDashboard.Application.Farmacia.ViewModels.Classificacao;
using PlatinDashboard.Application.Farmacia.ViewModels.Loja;
using PlatinDashboard.Application.Interfaces;
using PlatinDashboard.Domain.Farmacia.Interfaces.Repositories;
using PlatinDashboard.Domain.Farmacia.Interfaces.StoredProcedures;
using PlatinDashboard.Presentation.MVC.Helpers;
using PlatinDashboard.Presentation.MVC.MvcFilters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class DashboardController : BaseController
    {
        public string cliente = "";
        private readonly IClsCabAppService _clsCabAppService;
        private readonly IClsVenAllAppService _clsVenAllAppService;
        private readonly IGraficoWebAppService _graficoWebAppService;
        private readonly IVendaLojaPorMesAppService _vendaLojaPorMesAppService;
        private readonly IVenUadAppService _venUadAppService;
        private readonly IUadCabAppService _uadCabAppService;
        private readonly IVendaBalconistaPorClassificacaoRepository _vendaBalconistaPorClassificacaoRepository;
        private readonly IVenUadClsRepository _venUadClsRepository;
        private readonly IVenUadClsDashRepository _venUadClsDashRepository;
        private readonly IGraficoWebLojaStoredProcedure _graficoWebLojaStoredProcedure;

        public DashboardController(IUserAppService userAppService,
                                     ICompanyAppService companyAppService,
                                     IClsCabAppService clsCabAppService,
                                     IClsVenAllAppService clsVenAllAppService,
                                     IGraficoWebAppService graficoWebAppService,
                                     IVendaLojaPorMesAppService vendaLojaPorMesAppService,
                                     IVenUadAppService venUadAppService,
                                     IUadCabAppService uadCabAppService,
                                     IVendaBalconistaPorClassificacaoRepository vendaBalconistaPorClassificacaoRepository,
                                     IVenUadClsRepository venUadClsRepository,
                                     IVenUadClsDashRepository venUadClsDashRepository,
                                     IGraficoWebLojaStoredProcedure graficoWebLojaStoredProcedure)
                                     : base(userAppService, companyAppService)
        {
            _clsCabAppService = clsCabAppService;
            _clsVenAllAppService = clsVenAllAppService;
            _graficoWebAppService = graficoWebAppService;
            _vendaLojaPorMesAppService = vendaLojaPorMesAppService;
            _venUadAppService = venUadAppService;
            _uadCabAppService = uadCabAppService;
            _vendaBalconistaPorClassificacaoRepository = vendaBalconistaPorClassificacaoRepository;
            _venUadClsRepository = venUadClsRepository;
            _venUadClsDashRepository = venUadClsDashRepository;
            _graficoWebLojaStoredProcedure = graficoWebLojaStoredProcedure;
        }

        [HttpGet]
        [ClaimsAuthorize("ChartDashboard", "Allowed")]
        public ActionResult Index()
        {


            ViewBag.Months = ListGeneratorHelper.GenerateMonths();
            ViewBag.Years = ListGeneratorHelper.GenerateYears();
            var store = "";// _uadCabAppService.GetStores(CompanyUser.GetDbConnection());
            if (LoggedUser.UserStoresIds.Any())
            {
                //store = store.Where(s => LoggedUser.UserStoresIds.Any(u => u.Equals(s.Uad)));
            }
            //Session["IDCliente"] = usuarioViewModel.CompanyId;
            //Session["IdUser"] = usuarioViewModel.UserId;

            Session["IdUser"] = LoggedUser.UserId;
            try
            {
                Session["IDCliente"] = Session["AlteraCliente"].ToString();
                Session["Nivel"] = LoggedUser.UserType;
                Session["Nome"] = LoggedUser.Name;
                if(Session["IDCliente"].ToString() == "1") Session["AlteraCliente"] = "";
            }
            catch
            {
                Session["IDCliente"] = LoggedUser.CompanyId;
                Session["Nivel"] = LoggedUser.UserType;
                Session["Nome"] = LoggedUser.Name;
                Session["AlteraCliente"] = Session["IDCliente"].ToString();
            }


       
            ViewBag.Stores = "";// new SelectList(store, "Uad", "Des");
            ViewBag.Cliente = LoggedUser.Name;// (LoggedUser != null ? LoggedUser.Name : string.Empty);
            ViewBag.LastName = LoggedUser.LastName;// (LoggedUser != null ? LoggedUser.LastName : string.Empty);
            return View();
        }

        public class Ratio
        {
            public int total_estadual { get; set; }
            public int total_federal { get; set; }
            public int total_municipal { get; set; }
            public int total_normas { get; set; }
            public string ambito_normas { get; set; }
            public string ambito_estadual { get; set; }
            public string ambito_federal { get; set; }
            public string ambito_municipal { get; set; }
        }
        public class TotalSistema
        {
            public int total_MeioAmbiente { get; set; }
            public int total_Qualidade { get; set; }
            public int total_ResponsabilidadeSocial { get; set; }
            public int total_SegurançaeSaude { get; set; }
            public string sistema_MeioAmbiente { get; set; }
            public string sistema_Qualidade { get; set; }
            public string sistema_ResponsabilidadeSocia { get; set; }
            public string sistema_SegurançaeSaude { get; set; }
        }

        public class TotalAplicabilidade
        {
            public int total_Aplicabilidade { get; set; }
            public int total_Conhecimento { get; set; }
            public string Aplicabilidade_Aplicabilidade { get; set; }
            public string Aplicabilidade_Conhecimento { get; set; }
        }

        public class TotalAvaliacoes
        {
            public int total_Atende { get; set; }
            public int total_NaoInformado { get; set; }
            public int total_AtendeParcial { get; set; }
            public int total_EmAndamento { get; set; }
            public int total_NaoAplicavel { get; set; }
            public string Avaliacoes_Atende { get; set; }
            public string Avaliacoes_NaoInformado { get; set; }
            public string Avaliacoes_AtendeParcial { get; set; }
            public string Avaliacoes_EmAndamento { get; set; }
            public string Avaliacoes_NaoAplicavel { get; set; }
        }

        public ActionResult GetData()
        {
            cliente = Session["AlteraCliente"].ToString();
            var nivel = LoggedUser.UserType;
            if (nivel == "Adm-1" || nivel == "Adm-2" || nivel == "Adm-3" || nivel == "Gestor") cliente = "";

             Legis_ClienteNeg legiscliente = new Legis_ClienteNeg();

            Legis_Cliente objestadual = new Legis_Cliente();
            List<Legis_Cliente>  estadual = legiscliente.Total_Cliente_Ambito_Estadual(cliente);
            foreach (var lista in estadual)
            {
                objestadual.Total = lista.Total;
                objestadual.Ambito = lista.Ambito;
            }

            Legis_Cliente objmunicipal = new Legis_Cliente();
            List<Legis_Cliente> municipal = legiscliente.Total_Cliente_Ambito_Municipal(cliente);
            foreach (var lista in municipal)
            {
                objmunicipal.Total = lista.Total;
                objmunicipal.Ambito = lista.Ambito;
            }

            Legis_Cliente objfederal = new Legis_Cliente();
            List<Legis_Cliente> federal = legiscliente.Total_Cliente_Ambito_Federal(cliente);
            foreach (var lista in federal)
            {
                objfederal.Total = lista.Total;
                objfederal.Ambito = lista.Ambito;
            }

            Legis_Cliente objnormas = new Legis_Cliente();
            List<Legis_Cliente> normas = legiscliente.Total_Cliente_Ambito_Normas(cliente);
            foreach (var lista in normas)
            {
                objnormas.Total = lista.Total;
                objnormas.Ambito = lista.Ambito;
            }
            Ratio obj = new Ratio();
            obj.total_estadual = objestadual.Total;
            obj.total_federal = objfederal.Total;
            obj.total_municipal = objmunicipal.Total;
            obj.total_normas = objnormas.Total;

            obj.ambito_normas = objnormas.Ambito;
            obj.ambito_estadual = objestadual.Ambito;
            obj.ambito_federal = objfederal.Ambito;
            obj.ambito_municipal = objmunicipal.Ambito;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSistema()
        {
            cliente = Session["AlteraCliente"].ToString();
            var nivel = LoggedUser.UserType;
            if (nivel == "Adm-1" || nivel == "Adm-2" || nivel == "Adm-3" || nivel == "Gestor") cliente = "";

            Legis_ClienteNeg legiscliente = new Legis_ClienteNeg();

            Legis_Cliente objMeioAmbiente = new Legis_Cliente();
            List<Legis_Cliente> MeioAmbiente = legiscliente.Total_Cliente_Sistema_MeioAmbiente(cliente);
            foreach (var lista in MeioAmbiente)
            {
                objMeioAmbiente.Total = lista.Total;
                objMeioAmbiente.Sistema = lista.Sistema;
            }

            Legis_Cliente objQualidade = new Legis_Cliente();
            List<Legis_Cliente> Qualidade = legiscliente.Total_Cliente_Sistema_Qualidade(cliente);
            foreach (var lista in MeioAmbiente)
            {
                objQualidade.Total = lista.Total;
                objQualidade.Sistema = lista.Sistema;
            }

            Legis_Cliente objResponsabilidadeSocial = new Legis_Cliente();
            List<Legis_Cliente> ResponsabilidadeSocial = legiscliente.Total_Cliente_Sistema_ResponsabilidadeSocial(cliente);
            foreach (var lista in ResponsabilidadeSocial)
            {
                objResponsabilidadeSocial.Total = lista.Total;
                objResponsabilidadeSocial.Sistema = lista.Sistema;
            }

            Legis_Cliente objSegurançaeSaude = new Legis_Cliente();
            List<Legis_Cliente> SegurançaeSaude = legiscliente.Total_Cliente_Sistema_SegurançaeSaude(cliente);
            foreach (var lista in SegurançaeSaude)
            {
                objSegurançaeSaude.Total = lista.Total;
                objSegurançaeSaude.Sistema = lista.Sistema;
            }


            TotalSistema obj = new TotalSistema();
            obj.total_MeioAmbiente = objMeioAmbiente.Total;
            obj.total_Qualidade = objQualidade.Total;
            obj.total_ResponsabilidadeSocial= objResponsabilidadeSocial.Total;
            obj.total_SegurançaeSaude = objSegurançaeSaude.Total;

            obj.sistema_MeioAmbiente = objMeioAmbiente.Sistema;
            obj.sistema_Qualidade = objQualidade.Sistema;
            obj.sistema_ResponsabilidadeSocia = objResponsabilidadeSocial.Sistema;
            obj.sistema_SegurançaeSaude = objSegurançaeSaude.Sistema;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAplicabilidade()
        {
            cliente = Session["AlteraCliente"].ToString();
            var nivel = LoggedUser.UserType;
            if (nivel == "Adm-1" || nivel == "Adm-2" || nivel == "Adm-3" || nivel == "Gestor") cliente = "";

            Legis_ClienteNeg legiscliente = new Legis_ClienteNeg();

            Legis_Cliente objAplicabilidade = new Legis_Cliente();
            List<Legis_Cliente> Aplicabilidade = legiscliente.Total_Cliente_Aplicabilidade_Aplicavel(cliente);
            foreach (var lista in Aplicabilidade)
            {
                objAplicabilidade.Total = lista.Total;
                objAplicabilidade.Aplicabilidade = lista.Aplicabilidade;
            }

            Legis_Cliente objConhecimento = new Legis_Cliente();
            List<Legis_Cliente> Conhecimento = legiscliente.Total_Cliente_Aplicabilidade_Conhecimento(cliente);
            foreach (var lista in Conhecimento)
            {
                objConhecimento.Total = lista.Total;
                objConhecimento.Conhecimento = lista.Conhecimento;
            }
            

            TotalAplicabilidade obj = new TotalAplicabilidade();
            obj.total_Aplicabilidade = objAplicabilidade.Total;
            obj.total_Conhecimento = objConhecimento.Total;

            obj.Aplicabilidade_Aplicabilidade = objAplicabilidade.Aplicabilidade;
            obj.Aplicabilidade_Conhecimento = objAplicabilidade.Conhecimento;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAvaliacoes()
        {
            cliente = Session["AlteraCliente"].ToString();
            var nivel = LoggedUser.UserType;
            if (nivel == "Adm-1" || nivel == "Adm-2" || nivel == "Adm-3" || nivel == "Gestor") cliente = "";

            Legis_ClienteNeg legiscliente = new Legis_ClienteNeg();

            Legis_Cliente objAtende = new Legis_Cliente();
            List<Legis_Cliente> Atende = legiscliente.Total_Cliente_Avaliacoes_Atende(cliente);
            foreach (var lista in Atende)
            {
                objAtende.Total = lista.Total;
                objAtende.Atende = lista.Atende;
            }

            Legis_Cliente objNaoInformado = new Legis_Cliente();
            List<Legis_Cliente> NaoInformado = legiscliente.Total_Cliente_Avaliacoes_NaoInformado(cliente);
            foreach (var lista in NaoInformado)
            {
                objNaoInformado.Total = lista.Total;
                objNaoInformado.NaoInformado = lista.NaoInformado;
            }

            Legis_Cliente objAtendeParcial = new Legis_Cliente();
            List<Legis_Cliente> AtendeParcial = legiscliente.Total_Cliente_Avaliacoes_AtendeParcial(cliente);
            foreach (var lista in AtendeParcial)
            {
                objAtendeParcial.Total = lista.Total;
                objAtendeParcial.AtendeParcial = lista.AtendeParcial;
            }

            Legis_Cliente objEmAndamento = new Legis_Cliente();
            List<Legis_Cliente> EmAndamento = legiscliente.Total_Cliente_Avaliacoes_EmAndamento(cliente);
            foreach (var lista in EmAndamento)
            {
                objEmAndamento.Total = lista.Total;
                objEmAndamento.EmAndamento = lista.EmAndamento;
            }

            Legis_Cliente objNaoAplicavel = new Legis_Cliente();
            List<Legis_Cliente> NaoAplicavel = legiscliente.Total_Cliente_Avaliacoes_NaoAplicavel(cliente);
            foreach (var lista in NaoAplicavel)
            {
                objNaoAplicavel.Total = lista.Total;
                objNaoAplicavel.EmAndamento = lista.NaoAplicavel;
            }


            TotalAvaliacoes obj = new TotalAvaliacoes();
            obj.total_Atende = objAtende.Total;
            obj.total_NaoInformado = objNaoInformado.Total;
            obj.total_AtendeParcial = objAtendeParcial.Total;
            obj.total_EmAndamento = objEmAndamento.Total;
            obj.total_NaoAplicavel = objNaoAplicavel.Total;

            obj.Avaliacoes_Atende = objAtende.Atende;
            obj.Avaliacoes_NaoInformado = objNaoInformado.NaoInformado;
            obj.Avaliacoes_AtendeParcial = objAtendeParcial.AtendeParcial;
            obj.Avaliacoes_EmAndamento = objEmAndamento.EmAndamento;
            obj.Avaliacoes_NaoAplicavel = objNaoAplicavel.NaoAplicavel;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        [ClaimsAuthorize("ChartDashboard", "Allowed")]
        public ActionResult GraficoFaturamentoClassificacao(string mes, string ano, int? loja)
        {
            var vendas =  new List<ClassificacaoVendaViewModel>();
            var vendasMesAnterior =  new List<ClassificacaoVendaViewModel>();
            var periodo = $"{ano}{mes}";
            var anoMesAnterior = Convert.ToInt32(mes) == 1 ? (Convert.ToInt32(ano) - 1).ToString() : ano;
            var mesAnterior = Convert.ToInt32(mes) == 1 ? 12.ToString() : (Convert.ToInt32(mes) - 1).ToString();
            var segundoPeriodo = $"{anoMesAnterior}{(mesAnterior.Length < 2 ? "0" + mesAnterior : mesAnterior)}";
            //for (int i = 1; i < 9; i++)
            //{
            //    //Buscando as vendas por classificação e período informado
            //    var venda = new ClassificacaoVendaViewModel
            //    {
            //        ClassificacaoId = i,
            //        Nome = _clsCabAppService.GetByFilter(c => c.Cod == i.ToString(), CompanyUser.GetDbConnection()).FirstOrDefault()?.Des ?? "Sem Identificação"
            //    };
            //    var vendaMesAnterior = new ClassificacaoVendaViewModel
            //    {
            //        ClassificacaoId = i,
            //        Nome = _clsCabAppService.GetByFilter(c => c.Cod == i.ToString(), CompanyUser.GetDbConnection()).FirstOrDefault()?.Des ?? "Sem Identificação"
            //    };
            //    if (LoggedUser.UserStoresIds.Any())
            //    {
            //        venda.Valor = loja == null ?
            //        _venUadClsDashRepository.GetByFilter(c => c.Cls == i && c.My == periodo && LoggedUser.UserStoresIds.Contains(c.Uad), CompanyUser.GetDbConnection()).ToList().Sum(c => c.ValorBruto) :
            //        _venUadClsDashRepository.GetByFilter(c => c.Cls == i && c.My == periodo && c.Uad == loja && LoggedUser.UserStoresIds.Contains(c.Uad), CompanyUser.GetDbConnection()).ToList().Sum(c => c.ValorBruto);
            //        vendaMesAnterior.Valor = loja == null ?
            //        _venUadClsDashRepository.GetByFilter(c => c.Cls == i && c.My == segundoPeriodo && LoggedUser.UserStoresIds.Contains(c.Uad), CompanyUser.GetDbConnection()).Sum(c => c.ValorBruto) :
            //        _venUadClsDashRepository.GetByFilter(c => c.Cls == i && c.My == segundoPeriodo && c.Uad == loja && LoggedUser.UserStoresIds.Contains(c.Uad), CompanyUser.GetDbConnection()).Sum(c => c.ValorBruto);
            //    }
            //    else
            //    {
            //        venda.Valor = loja == null ?
            //        _venUadClsDashRepository.GetByFilter(c => c.Cls == i && c.My == periodo, CompanyUser.GetDbConnection()).ToList().Sum(c => c.ValorBruto) :
            //        _venUadClsDashRepository.GetByFilter(c => c.Cls == i && c.My == periodo && c.Uad == loja, CompanyUser.GetDbConnection()).ToList().Sum(c => c.ValorBruto);
            //        vendaMesAnterior.Valor = loja == null ?
            //        _venUadClsDashRepository.GetByFilter(c => c.Cls == i && c.My == segundoPeriodo, CompanyUser.GetDbConnection()).Sum(c => c.ValorBruto) :
            //        _venUadClsDashRepository.GetByFilter(c => c.Cls == i && c.My == segundoPeriodo && c.Uad == loja, CompanyUser.GetDbConnection()).Sum(c => c.ValorBruto);
            //    }
            //    vendas.Add(venda);   
            //    vendasMesAnterior.Add(vendaMesAnterior);
            //}
            var venda = new ClassificacaoVendaViewModel();
            var culture = new CultureInfo("pt-BR");
        //    var month = new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), 1).ToString("MMMM", culture);
            return Json(new { vendas }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ClaimsAuthorize("ChartDashboard", "Allowed")]
        public JsonResult GridTotalDeVendas(string mes, string ano)
        {
            var periodo = ano + mes;            
            var vendasLoja = new List<VendaLojaViewModel>();
            //if (LoggedUser.UserStoresIds.Any())
            //{
            //    var graficosWeb = _graficoWebLojaStoredProcedure.Buscar(periodo, LoggedUser.UserStoresIds, CompanyUser.GetConnectionString(), CompanyUser.DatabaseProvider);
            //    foreach (var graficoWeb in graficosWeb)
            //    {
            //        vendasLoja.Add(new VendaLojaViewModel(graficoWeb));
            //    }
            //}
            //else
            //{
            //    var graficosWeb = _graficoWebAppService.GetByFilter(c => c.My == periodo, CompanyUser.GetDbConnection()).OrderBy(v => v.Dat);
            //    foreach (var graficoWeb in graficosWeb)
            //    {
            //        vendasLoja.Add(new VendaLojaViewModel(graficoWeb));
            //    }
            //}            
            return Json(vendasLoja, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ClaimsAuthorize("ChartDashboard", "Allowed")]
        public JsonResult GridVendaPorLojas(string mes, string ano)
        {
            var periodo = ano + mes;
            var vendasLoja = new List<VenUadViewModel>();
            //if (LoggedUser.UserStoresIds.Any())
            //{
            //    vendasLoja = _venUadAppService.GetByFilter(c => c.My == periodo && LoggedUser.UserStoresIds.Contains(c.Uad.Value), CompanyUser.GetDbConnection()).OrderBy(v => v.Dat).ToList();
            //}
            //else
            //{
            //    vendasLoja = _venUadAppService.GetByFilter(c => c.My == periodo, CompanyUser.GetDbConnection()).OrderBy(v => v.Dat).ToList();
            //}
            //var lojas = _uadCabAppService.GetAll(CompanyUser.GetDbConnection());
            var vendaLojaViewModels = new List<VendaLojaViewModel>();
            //foreach (var vendaLoja in vendasLoja)
            //{
            //    vendaLojaViewModels.Add(new VendaLojaViewModel(vendaLoja, lojas));
            //}
          //  vendaLojaViewModels.Add(new VendaLojaViewModel(vendaLoja, lojas));
            return Json(vendaLojaViewModels, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ClaimsAuthorize("ChartDashboard", "Allowed")]
        public JsonResult GridVendaMensalPorLojas(string mes, string ano)
        {
            //var periodo = ano + mes;
            //var vendasLoja = new List<VendaLojaPorMesViewModel>();
            //if (LoggedUser.UserStoresIds.Any())
            //{
            //    vendasLoja = _vendaLojaPorMesAppService.GetByFilter(c => c.AnoMes == periodo && LoggedUser.UserStoresIds.Contains(c.Uad.Value), CompanyUser.GetDbConnection()).OrderBy(v => v.Uad).ToList();
            //}
            //else
            //{
            //    vendasLoja = _vendaLojaPorMesAppService.GetByFilter(c => c.AnoMes == periodo, CompanyUser.GetDbConnection()).OrderBy(v => v.Uad).ToList();
            //}
            //var lojas = _uadCabAppService.GetAll(CompanyUser.GetDbConnection());
            var vendaLojaViewModels = new List<VendaLojaViewModel>();
            //foreach (var vendaLoja in vendasLoja)
            //{
            //    vendaLojaViewModels.Add(new VendaLojaViewModel(vendaLoja, lojas));
            //}
            return Json(vendaLojaViewModels, JsonRequestBehavior.AllowGet);
        }
    }
}