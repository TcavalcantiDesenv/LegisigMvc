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
    public class PlanoAcaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public PlanoAcaoNeg planoAcaoNeg = new PlanoAcaoNeg();
        public ActionResult Index(string codci, string Id, string param, int? pagina, string busca)
        {
            var vendas = new List<PlanoAcao>();
            //if (codci == "" || codci == null) codci = Id;
            //if (codci == "" || codci == null) codci = Session["cliente"].ToString();
            //        var IDCliente = Session["IdCliente"].ToString();
            ViewBag.Cliente = Session["RazaoSocial"].ToString();
            int id = Convert.ToInt32(Id);
            var IDCliente = codci;
            if (codci == null || Id == null || param == null)
            {
                Id = Session["ID"].ToString();
                param = Session["ParamId"].ToString();
                codci = Session["cliente"].ToString();
            }
            if (codci != null || Id != null || param != null)
            {
                Session["cliente"] = codci;
                Session["ParamId"] = param;
                Session["ID"] = Id;
                ViewBag.IDParam = Session["ParamId"].ToString();
                IDCliente = Session["cliente"].ToString();
                ViewBag.IDCliente = Session["cliente"].ToString();
          
                if (string.IsNullOrEmpty(busca))
                {
                    vendas = planoAcaoNeg.buscarPorClienteConformidade(codci).
                    OrderByDescending(p => p.id).ToList();

                    ViewBag.Vendas = vendas;
                    ViewBag.IDLegis = Session["Legis"].ToString();
                }
                else
                {
                    vendas = planoAcaoNeg.buscarPorClienteConformidade(codci).
                    OrderByDescending(p => p.id).
                            Where(p => p.Causa.Contains(busca) || p.Correcao_Corretivas.Contains(busca) || p.Evidencias.Contains(busca) ||
                             p.ResultFinal.Contains(busca) || p.Eficacia.Contains(busca) || p.Evidencias.Contains(busca)).ToList();
                    ViewBag.Vendas = vendas;
                    //vendas = db.PlanoAcao.
                    //OrderByDescending(p => p.id).
                    //        Where(p => p.Causa.Contains(busca) || p.Correcao_Corretivas.Contains(busca) || p.Evidencias.Contains(busca) ||
                    //         p.ResultFinal.Contains(busca) || p.Eficacia.Contains(busca) || p.Evidencias.Contains(busca)).ToList();
                    ViewBag.Busca = busca;
                }

            }
            int pageSize = 50;
            int pageNumber = (pagina ?? 1);
            int total = ViewBag.Vendas.Count;
            if (total < pageSize * pageNumber) pageNumber = 1;

            ViewBag.LeisClientes = ViewBag.Vendas;
            return View(vendas.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(string Id)
        {
            int id = Convert.ToInt32(Id);
            ViewBag.ID = id;
            string cliente = Session["cliente"].ToString();
            Session["CodId"] = id;
            PlanoAcao objCliente = new PlanoAcao(id);
            var todos2 = planoAcaoNeg.buscarPorID(Id);
            if (todos2.Count == 0)
            {
                return RedirectToAction("Index", "PlanoAcao", new { cliente = cliente });
            }
            objCliente.Causa = todos2[0].Causa.ToString();
            objCliente.Correcao_Corretivas = todos2[0].Correcao_Corretivas.ToString();
            objCliente.DataCausa = Convert.ToDateTime(todos2[0].DataCausa.ToString("dd/MM/yyyy"));
            objCliente.DataEficacia = Convert.ToDateTime(todos2[0].DataEficacia.ToString("dd/MM/yyyy"));
            objCliente.Eficacia = todos2[0].Eficacia.ToString();
            objCliente.Evidencias = todos2[0].Evidencias.ToString();
            objCliente.IDCliente = Convert.ToInt32(todos2[0].IDCliente.ToString());
            objCliente.IDLegis = Convert.ToInt32(todos2[0].IDLegis.ToString());
            objCliente.IDParametros = Convert.ToInt32(todos2[0].IDParametros.ToString());
            objCliente.IDAcao = Convert.ToInt32(todos2[0].IDAcao.ToString());
            objCliente.Prazo = Convert.ToDateTime(todos2[0].Prazo.ToString());
            objCliente.ResultFinal = todos2[0].ResultFinal.ToString();
            Session["CodCli"] = objCliente.IDCliente;
            Session["ParamId"] = objCliente.IDParametros;
            Session["LegisId"] = objCliente.IDLegis;
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Details(PlanoAcao objCliente)
        {
            string Legis = Session["Legis"].ToString();
            string cliente = Session["cliente"].ToString();
            string IdAcao = Session["CodId"].ToString();
            string Param = Session["ParamId"].ToString();
            objCliente.IDCliente = Convert.ToInt32(cliente);
            objCliente.IDAcao = Convert.ToInt32(IdAcao);
            objCliente.IDLegis = Convert.ToInt32(Legis);
            planoAcaoNeg.update(objCliente); //13202?legis=4&cliente=2098
            return RedirectToAction("Index", "PlanoAcao", new { id = cliente });
        }

        [HttpGet]
        public ActionResult Create()
        {
            string Legis = Session["Legis"].ToString();
            string cliente = Session["cliente"].ToString();
            string IdAcao = Session["CodId"].ToString();
            //            string Param = Session["ParamId"].ToString();
            PlanoAcao objCliente = new PlanoAcao();
            objCliente.IDCliente = Convert.ToInt32(cliente);
            objCliente.IDAcao = Convert.ToInt32(IdAcao);
            objCliente.IDLegis = Convert.ToInt32(Legis);
            //       objCliente.id = Convert.ToInt32(Id);

            return View(objCliente);
        }

        [HttpPost]
        public ActionResult Create(PlanoAcao objProduto)
        {
            string Legis = Session["Legis"].ToString();
            string cliente = Session["cliente"].ToString();
            string IdAcao = Session["CodId"].ToString();
            //        string Param = Session["ParamId"].ToString();
            objProduto.IDCliente = Convert.ToInt32(cliente);
            objProduto.IDAcao = Convert.ToInt32(IdAcao);
            objProduto.IDLegis = Convert.ToInt32(Legis);
            //            objProduto.IDParametros = Convert.ToInt32(Param);
            planoAcaoNeg.create(objProduto);
            objProduto.IDAcao = Convert.ToInt32(Session["CodId"].ToString());
            return RedirectToAction("Index", "PlanoAcao", new { id = Session["CodId"].ToString() });

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            ViewBag.Cliente = Session["RazaoSocial"].ToString();
            string cliente = Session["cliente"].ToString();
            PlanoAcao objProduto = new PlanoAcao(Convert.ToInt32(id));

            PlanoAcao objCliente = new PlanoAcao();
            var todos2 = planoAcaoNeg.buscarPorID(id);
            if (todos2.Count == 0)
            {
                return RedirectToAction("Index", "PlanoAcao", new { cliente = cliente });
            }
            objCliente.Causa = todos2[0].Causa.ToString();
            objCliente.Correcao_Corretivas = todos2[0].Correcao_Corretivas.ToString();
            objCliente.DataCausa = Convert.ToDateTime(todos2[0].DataCausa.ToString("dd/MM/yyyy"));
            objCliente.DataEficacia = Convert.ToDateTime(todos2[0].DataEficacia.ToString("dd/MM/yyyy"));
            objCliente.Eficacia = todos2[0].Eficacia.ToString();
            objCliente.Evidencias = todos2[0].Evidencias.ToString();
            objCliente.IDCliente = Convert.ToInt32(todos2[0].IDCliente.ToString());
            objCliente.IDLegis = Convert.ToInt32(todos2[0].IDLegis.ToString());
            objCliente.IDParametros = Convert.ToInt32(todos2[0].IDParametros.ToString());
            objCliente.IDAcao = Convert.ToInt32(todos2[0].IDAcao.ToString());
            objCliente.Prazo = Convert.ToDateTime(todos2[0].Prazo.ToString());
            objCliente.ResultFinal = todos2[0].ResultFinal.ToString();
            Session["CodCli"] = objCliente.IDCliente;
            Session["ParamId"] = objCliente.IDParametros;
            Session["LegisId"] = objCliente.IDLegis;
            return View(objCliente);
        }

        [HttpPost]
        public ActionResult Delete(PlanoAcao objProduto)
        {
            planoAcaoNeg.delete(objProduto);
            PlanoAcao objProduto2 = new PlanoAcao();
            return RedirectToAction("Index", "PlanoAcao", new { cliente = objProduto.IDCliente });
        }
    }
}