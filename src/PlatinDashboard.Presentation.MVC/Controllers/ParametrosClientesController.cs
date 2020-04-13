using Model.Entity;
using Model.Neg;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PlatinDashboard.Presentation.MVC.Models.IdentityModels;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class ParametrosClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ParametrosClientesNeg parametrosClientesNeg = new ParametrosClientesNeg();
        public ActionResult Index(string Id, int? pagina, string busca)
        {
            var IDCliente = Session["IdCliente"].ToString();
            var vendas = new List<ParametrosCliente>();
            ViewBag.Cliente = Session["RazaoSocial"].ToString();
            if (string.IsNullOrEmpty(busca))
            {
                vendas = parametrosClientesNeg.buscarPorLeiCliente(IDCliente, Id).
                    OrderByDescending(p => p.Capitulo).ToList();
            }
            else
            {
                vendas = parametrosClientesNeg.buscarPorLeiCliente(IDCliente, Id).
        OrderByDescending(p => p.Id).
         Where(p => p.Capitulo.Contains(busca) || p.Parametro.Contains(busca) ||
         p.Item.Contains(busca)).ToList();
                ViewBag.Busca = busca;
            }
            int pageSize = 50;
            int pageNumber = (pagina ?? 1);
            if (vendas.Count() < pageSize * pageNumber) pageNumber = 1;
            ViewBag.Execucao = vendas;
            return View(vendas.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(string Id)
        {
            int id = Convert.ToInt32(Id);
            ViewBag.ID = id;
            Session["CodId"] = id;
            ParametrosCliente objCliente = new ParametrosCliente(id);
            var todos2 = parametrosClientesNeg.buscarPorID(Id);
            objCliente.Aplicavel = todos2[0].Aplicavel.ToString();
            objCliente.Capitulo = todos2[0].Capitulo.ToString();
            objCliente.Conhecimento = todos2[0].Conhecimento.ToString();
            objCliente.Item = todos2[0].Item.ToString();
            objCliente.Numero = Convert.ToInt32(todos2[0].Numero.ToString());
            objCliente.IDCliente = Convert.ToInt32(todos2[0].IDCliente.ToString());
            objCliente.IDLegisGeral = Convert.ToInt32(todos2[0].IDLegisGeral.ToString());
            objCliente.Obrigacao = todos2[0].Obrigacao.ToString();
            objCliente.Parametro = todos2[0].Parametro.ToString();
            Session["CodCli"] = objCliente.IDCliente;
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Details(ParametrosCliente objCliente)
        {
            parametrosClientesNeg.update(objCliente);
            return RedirectToAction("Index", "ParametrosClientes", new { id = Session["CodId"].ToString() });
        }
    }
}