using Model.Entity;
using Model.Neg;
using OfficeOpenXml;
using PagedList;
using PlatinDashboard.Application.Administrativo.Interfaces;
using PlatinDashboard.Application.Interfaces;
using PlatinDashboard.Infra.CrossCutting.Identity.Configuration;
using PlatinDashboard.Presentation.MVC.MvcFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static PlatinDashboard.Presentation.MVC.Models.IdentityModels;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class RequisitosLegaisController : BaseController
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IClienteAppService _clienteAppService;
        private readonly IVideoAppService _videoAppService;
        private ApplicationDbContext db = new ApplicationDbContext();
        public Legis_ClienteNeg legisClientelNeg = new Legis_ClienteNeg();
        public LegisGeralNeg legisGeralNeg = new LegisGeralNeg();
        public LegisClienteNeg legisClienteNeg = new LegisClienteNeg();

        public RequisitosLegaisController(ICompanyAppService companyAppService,
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
            var nivel = LoggedUser.UserType;
            var companyViewModels = _companyAppService.GetAllClients();
            var companyViewModels2 = _companyAppService.GetAllClients().Where(p => p.CompanyId == LoggedUser.CompanyId);
            if (nivel == "G-1" || nivel == "G-2" || nivel == "G-3")
            {
                companyViewModels = companyViewModels2;
            }

  //          var xcompanyViewModels = db.Empresas.OrderByDescending(p => p.RazaoSocial).ToList();

            ViewBag.Cliente = (Session["userId"] == null ? "" : LoggedUser.Name);
            return View(companyViewModels);
        }

        public ActionResult Requisitos(string Id, int? pagina, string busca)
        {
            int Cod = Convert.ToInt32(Id);
            if (Id == null || Id == "")
            {
                Id = Session["IDCliente"].ToString();
            }
            int codigo = Convert.ToInt32(Id);
            ViewBag.IDCliente = Session["IDCliente"].ToString();

            //     var companyViewModels = _companyAppService.GetAllClients().Where(p => p.CompanyId == codigo).FirstOrDefault();
            var companyViewModels = legisClientelNeg.buscarLeisClientesPorCliente(Id).FirstOrDefault();//.ToList();
            ViewBag.Cliente = companyViewModels.RazaoSocial;
            Session["RazaoSocial"] = companyViewModels.RazaoSocial;
            Session["IDLegisGeral"] = companyViewModels.IDLegisGeral;

            try
            {
                ViewBag.Cliente = Session["RazaoSocial"].ToString();
                Session["IdCli"] = Id;// "2096";
                Session["Nome"] = LoggedUser.Name;// "USUARUI TESTE";
                Session["IdUser"] = LoggedUser.UserId;// Session["userId"].ToString();// "1";
                Session["IdCliente"] = Id;
            }
            catch
            {
                ViewBag.Cliente = LoggedUser.Name;
                Session["IdCli"] = Id;// "2096";
                Session["IdCliente"] = Id;
                Session["Nome"] = LoggedUser.Name;// "USUARUI TESTE";
                Session["IdUser"] = LoggedUser.UserId;// Session["userId"].ToString();// "1";
            }

            var vendas = new List<LeisClientes>();
  
            if (string.IsNullOrEmpty(busca))
            {
                var legis2 = legisClientelNeg.buscarLeisClientesPorCliente(Id).ToList();
           ///     var legis = db.LegisClientes.OrderByDescending(p => p.Id).ToList();
                vendas = legis2;// db.LeisClientes.
                 //   OrderByDescending(p => p.Id).Where(p => p.IDCliente == Cod).ToList();
            }
            else
            {
                vendas = db.LeisClientes.
                OrderByDescending(p => p.Id).
                        Where(p => p.Sistema.Contains(busca) || p.Tema.Contains(busca) || p.Orgao.Contains(busca) ||
                        p.Tipo.Contains(busca) || p.Tema.Contains(busca) || p.Numero.Contains(busca) || p.Orgao.Contains(busca) || p.Estado.Contains(busca) || p.Municipio.Contains(busca) ||
                        p.Ambito.Contains(busca) || p.Arqpdf.Contains(busca) || p.Ambito.Contains(busca) || p.Ementa.Contains(busca)).ToList();
                ViewBag.Busca = busca;
            }
            int pageSize = 50;
            int pageNumber = (pagina ?? 1);
            if (vendas.Count() < pageSize * pageNumber) pageNumber = 1;
            ViewBag.LeisClientes = vendas;
            return View(vendas.ToPagedList(pageNumber, pageSize));

          //  return View();
        }

        [HttpGet]
        public ActionResult Details(string Id)
        {
            int id = Convert.ToInt32(Id);
            ViewBag.ID = id;
            Session["IdLEI"] = id;
            ViewBag.Caminho = "/Content/Arquivos/pdf/";
            LeisClientes objCliente = new LeisClientes(id);
            Legis_Cliente objLegis_Cliente = new Legis_Cliente(id);
            var todos = legisClientelNeg.findAll();
            ViewBag.LegisCli = todos.OrderByDescending(p => p.IDLegisGeral).Where(p => p.Id == id).ToList();// legisClientelNeg.findAll();
            legisClientelNeg.buscarLeisClientesPorID(objCliente);
            Session["CodCli"] = objCliente.IDCliente;
            Session["IDLegisGeral"] = objCliente.IDLegisGeral;
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Details(LeisClientes objCliente)
        {
            objCliente.IDCliente = Convert.ToInt32(Session["IdCliente"].ToString());
            objCliente.IDLegisGeral = Convert.ToInt32(Session["IDLegisGeral"].ToString());
            legisClienteNeg.updatePartial(objCliente);

            LegisGeral objLegisGeral = new LegisGeral();
            objLegisGeral.Id = objCliente.IDLegisGeral;
            objLegisGeral. Arqpdf = objCliente.Arqpdf;
            objLegisGeral.link = objCliente.Link;
            legisGeralNeg.update(objLegisGeral);
            return RedirectToAction("Requisitos", "RequisitosLegais", new { id = Session["CodCli"].ToString() });
        }

        public void DownloadLei()
        {
            string cliente = Session["IdCliente"].ToString();
            var nivel = LoggedUser.UserType;
            var leisViewModels = legisClientelNeg.ExportarLeisClientesPorCliente("0");// _companyAppService.GetAllClients();
       ///     var companyViewModels2 = _companyAppService.GetAllClients().Where(p => p.CompanyId == LoggedUser.CompanyId);
            if (nivel == "G-1" || nivel == "G-2" || nivel == "G-3")
            {
                leisViewModels = legisClientelNeg.ExportarLeisClientesPorCliente(cliente);
            }

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "NumCliente";
            Sheet.Cells["B1"].Value = "NumLei";
            Sheet.Cells["C1"].Value = "RazaoSocial";
            Sheet.Cells["D1"].Value = "Sistema";
            Sheet.Cells["E1"].Value = "Ambito";
            Sheet.Cells["F1"].Value = "Numero";
            Sheet.Cells["G1"].Value = "Ano";
            Sheet.Cells["H1"].Value = "Orgao";
            Sheet.Cells["I1"].Value = "Tema";
            Sheet.Cells["J1"].Value = "Ementa";
            Sheet.Cells["L1"].Value = "Ambito";
            Sheet.Cells["M1"].Value = "Tipo";
            Sheet.Cells["N1"].Value = "Municipio";
            Sheet.Cells["O1"].Value = "Estado";
            Sheet.Cells["P1"].Value = "Pais";
            Sheet.Cells["Q1"].Value = "Situacao";
            Sheet.Cells["R1"].Value = "Aplicavel";
            Sheet.Cells["S1"].Value = "Link";
            Sheet.Cells["T1"].Value = "PDF";

            int row = 2;
            foreach (var item in leisViewModels)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.IDCliente;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.IDLegisGeral;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.RazaoSocial;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.Sistema;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Ambito;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.Numero;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.Ano;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.Orgao;
                Sheet.Cells[string.Format("I{0}", row)].Value = item.Tema;
                Sheet.Cells[string.Format("J{0}", row)].Value = item.Ementa;
                Sheet.Cells[string.Format("L{0}", row)].Value = item.Ambito;
                Sheet.Cells[string.Format("M{0}", row)].Value = item.Tipo;
                Sheet.Cells[string.Format("N{0}", row)].Value = item.Municipio;
                Sheet.Cells[string.Format("O{0}", row)].Value = item.Estado;
                Sheet.Cells[string.Format("P{0}", row)].Value = item.Pais;
                Sheet.Cells[string.Format("Q{0}", row)].Value = item.Lei;
                Sheet.Cells[string.Format("R{0}", row)].Value = item.Aplicavel;
                Sheet.Cells[string.Format("S{0}", row)].Value = item.Link;
                Sheet.Cells[string.Format("T{0}", row)].Value = item.Arqpdf;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }
        public void DownloadParametro()
        {
            string cliente = Session["IdCliente"].ToString();
            var nivel = LoggedUser.UserType;
            var leisViewModels = legisClientelNeg.ExportarParametrosClientesPorCliente("0");// _companyAppService.GetAllClients();
                                                                                      ///     var companyViewModels2 = _companyAppService.GetAllClients().Where(p => p.CompanyId == LoggedUser.CompanyId);
            if (nivel == "G-1" || nivel == "G-2" || nivel == "G-3")
            {
                leisViewModels = legisClientelNeg.ExportarParametrosClientesPorCliente(cliente);
            }

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "NumCliente";
            Sheet.Cells["B1"].Value = "NumParametro";
            Sheet.Cells["C1"].Value = "Exigencia";
            Sheet.Cells["D1"].Value = "Assunto";
            Sheet.Cells["E1"].Value = "Capitulo";
            Sheet.Cells["F1"].Value = "Parametro";
            Sheet.Cells["G1"].Value = "Numero";
            Sheet.Cells["H1"].Value = "Obrigacao";
            Sheet.Cells["I1"].Value = "Aplicavel";
            Sheet.Cells["J1"].Value = "Conhecimento";
            int row = 2;
            foreach (var item in leisViewModels)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.NumCliente;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.NumParametro;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.Exigencia;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.Assunto;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Capitulo;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.Parametro;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.Numero;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.Obrigacao;
                Sheet.Cells[string.Format("I{0}", row)].Value = item.Aplicavel;
                Sheet.Cells[string.Format("J{0}", row)].Value = item.Conhecimento;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }



        [HttpGet]
        public void Gravar(string aplicavel, string ativo, string IdLei)
        {
            string ids = Session["IdLEI"].ToString();
            int id = Convert.ToInt32(ids);
            LegisClientes legiscliente = new LegisClientes();
            legiscliente.Id = id;
            legiscliente.Aplicavel = aplicavel;
            if( ativo == "Ativo")
            {
                ativo = "1";
            }else { ativo = "0";}
            legiscliente.Lei = ativo;
            legisClienteNeg.update(legiscliente);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.ID = id;
            LeisClientes objCliente = new LeisClientes(id);
            Legis_Cliente objLegis_Cliente = new Legis_Cliente(id);
            var todos = legisClientelNeg.findAll();
            ViewBag.LegisCli = todos.OrderByDescending(p => p.IDLegisGeral).Where(p => p.Id == id).ToList();// legisClientelNeg.findAll();
            legisClientelNeg.buscarLeisClientesPorID(objCliente);
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Update(Legis_Cliente objCliente)
        {
            legisClientelNeg.update(objCliente);
            return Redirect("~/RequisitosLegais/Requisitos/"+ Session["CodCli"].ToString());
        }
    }
}