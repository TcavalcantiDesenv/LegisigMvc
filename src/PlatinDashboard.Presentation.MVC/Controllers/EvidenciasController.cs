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
    public class EvidenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ConformidadeNeg conformidadeNeg  = new ConformidadeNeg();
        public ActionResult Evidencias(string Id, string Legis, string cliente, int? pagina, string busca)
        {
            var IDCliente = Session["IdCliente"].ToString();
            Session["Legis"] = Legis;
            Session["cliente"] = cliente;
            Session["param"] = Id;

            int id = Convert.ToInt32(Id);
            ViewBag.Cliente = Session["RazaoSocial"].ToString();
            var vendas = new List<Conformidade>();
            if (string.IsNullOrEmpty(busca))
            {
                //vendas = db.Conformidade.
                //    OrderByDescending(p => p.id).Where(p => p.id == id).ToList();
                vendas = conformidadeNeg.buscarPorClienteParametro(IDCliente, Id);
            }
            else
            {
                vendas = conformidadeNeg.buscarPorClienteParametro(IDCliente, Id).
                OrderByDescending(p => p.id).
                        Where(p => p.Anexo.Contains(busca) || p.Avaliado.Contains(busca) || p.Evidencias.Contains(busca) ||
                        p.Validado.Contains(busca) || p.Resultado.Contains(busca) ).ToList();
                ViewBag.Busca = busca;
            }
            int pageSize = 50;
            int pageNumber = (pagina ?? 1);
            if (vendas.Count() < pageSize * pageNumber) pageNumber = 1;
            ViewBag.LeisClientes = vendas;
            return View(vendas.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(string Id)
        {
            int id = Convert.ToInt32(Id);
            ViewBag.ID = id;
            Session["CodId"] = id;
            Conformidade objCliente = new Conformidade(id);
            var todos2 = conformidadeNeg.buscarPorID(Id);
            if(todos2.Count > 0)
            {
                objCliente.Anexo = todos2[0].Anexo.ToString();
                objCliente.Avaliado = todos2[0].Avaliado.ToString();
                objCliente.DataAvaliacao = Convert.ToDateTime(todos2[0].DataAvaliacao.ToString("dd/MM/yyyy"));
                objCliente.DataValidacao = Convert.ToDateTime(todos2[0].DataValidacao.ToString("dd/MM/yyyy"));
                objCliente.Evidencias = todos2[0].Evidencias.ToString();
                objCliente.id = Convert.ToInt32(todos2[0].id.ToString());
                objCliente.IDCliente = Convert.ToInt32(todos2[0].IDCliente.ToString());
                objCliente.IDLegis = Convert.ToInt32(todos2[0].IDLegis.ToString());
                objCliente.IDParametros = Convert.ToInt32(todos2[0].IDParametros.ToString());
                objCliente.Obrigacao = todos2[0].Obrigacao.ToString();
                objCliente.ProxAvaliacao = Convert.ToDateTime(todos2[0].ProxAvaliacao.ToString());
                objCliente.Resultado = todos2[0].Resultado.ToString();
                objCliente.Validado = todos2[0].Validado.ToString();
                Session["CodCli"] = objCliente.IDCliente;
                Session["ParamId"] = objCliente.IDParametros;
                Session["LegisId"] = objCliente.IDLegis;
            }
            
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Details(Conformidade objCliente)
        {
            conformidadeNeg.update(objCliente); //13202?legis=4&cliente=2098
            return RedirectToAction("Evidencias", "Evidencias", new { id = Session["ParamId"].ToString(), cliente = Session["CodCli"].ToString(), IdLegis = Session["LegisId"].ToString() });
        }

        [HttpGet]
        public ActionResult Create()
        {
            string Legis = Session["Legis"].ToString();
            string cliente = Session["cliente"].ToString();
            string param = Session["param"].ToString();
            Conformidade objCliente = new Conformidade();
            objCliente.IDCliente = Convert.ToInt32(cliente);
            objCliente.IDParametros = Convert.ToInt32(param);
            objCliente.IDLegis = Convert.ToInt32(Legis);

            return View(objCliente);
        }

        [HttpPost]
        public ActionResult Create(Conformidade objProduto)
        {
            conformidadeNeg.create(objProduto);
            return RedirectToAction("Evidencias", "Evidencias", new { id = Session["ParamId"].ToString(), cliente = Session["CodCli"].ToString(), IdLegis = Session["LegisId"].ToString() });

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            ViewBag.Cliente = Session["RazaoSocial"].ToString();
            Conformidade objProduto = new Conformidade(Convert.ToInt32(id));
            
            Conformidade objCliente = new Conformidade();
            var todos2 = conformidadeNeg.buscarPorID(id);
            objCliente.Anexo = todos2[0].Anexo.ToString();
            objCliente.Avaliado = todos2[0].Avaliado.ToString();
            objCliente.DataAvaliacao = Convert.ToDateTime(todos2[0].DataAvaliacao.ToString("dd/MM/yyyy"));
            objCliente.DataValidacao = Convert.ToDateTime(todos2[0].DataValidacao.ToString("dd/MM/yyyy"));
            objCliente.Evidencias = todos2[0].Evidencias.ToString();
            objCliente.id = Convert.ToInt32(todos2[0].id.ToString());
            objCliente.IDCliente = Convert.ToInt32(todos2[0].IDCliente.ToString());
            objCliente.IDLegis = Convert.ToInt32(todos2[0].IDLegis.ToString());
            objCliente.IDParametros = Convert.ToInt32(todos2[0].IDParametros.ToString());
            objCliente.Obrigacao = todos2[0].Obrigacao.ToString();
            objCliente.ProxAvaliacao = Convert.ToDateTime(todos2[0].ProxAvaliacao.ToString());
            objCliente.Resultado = todos2[0].Resultado.ToString();
            objCliente.Validado = todos2[0].Validado.ToString();
            Session["CodCli"] = objCliente.IDCliente;
            Session["ParamId"] = objCliente.IDParametros;
            Session["LegisId"] = objCliente.IDLegis;
            return View(objCliente);
        }

        [HttpPost]
        public ActionResult Delete(Conformidade objProduto)
        {
            conformidadeNeg.delete(objProduto);
            Conformidade objProduto2 = new Conformidade();
            return RedirectToAction("Evidencias", "Evidencias", new { id = Session["ParamId"].ToString(), legis = Session["LegisId"].ToString(), cliente = Session["CodCli"].ToString() });
            //return RedirectToAction("Index");
        }
    }
}