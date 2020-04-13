using Model.Neg;
using Model.Entity;
using PagedList;
//using PlatinDashboard.Presentation.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static PlatinDashboard.Presentation.MVC.Models.IdentityModels;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class LegisGeralController : Controller
    {
       private ApplicationDbContext db = new ApplicationDbContext();
        public LegisGeralNeg legisGeralNeg = new LegisGeralNeg();
        #region Conexao Padrao

        //int pageSize = 10;
        //var produtos = new List<LegisGeral>();
        //if (string.IsNullOrEmpty(busca))
        //{
        //    produtos = db.LegisGeral.
        //        OrderByDescending(p => p.Id).ToList();
        //}
        //else
        //{
        //    if (ViewBag.Busca == "") ViewBag.Busca = ViewBag.Busca2;
        //    produtos = db.LegisGeral.
        //        OrderByDescending(p => p.Id).
        //        Where(p => p.Sistema.Contains(busca) || p.Tema.Contains(busca) || p.Orgao.Contains(busca) ||
        //        p.link.Contains(busca) || p.lei.Contains(busca) || p.Estado.Contains(busca) || p.Municipio.Contains(busca) ||
        //        p.Arqpdf.Contains(busca) || p.Ambito.Contains(busca) || p.Ementa.Contains(busca)).ToList();
        //    ViewBag.Busca = busca;
        //    pageSize = 100;
        //}

        //int pageNumber = (pagina ?? 1);
        //if (produtos.Count() < pageSize * pageNumber) pageNumber = 1;
        //ViewBag.Companies = produtos.ToPagedList(pageNumber, pageSize);
        //return View(ViewBag.Companies);
        #endregion
        // GET: Descontos
        public ActionResult Index(int? pagina,  string busca)
        {
            //var vendas = new List<LegisGeral>();
            //if (string.IsNullOrEmpty(busca))
            //{
            //    vendas = db.LegisGeral.
            //        OrderByDescending(p => p.Id).ToList();
            //}
            //else
            //{
            //    vendas = db.LegisGeral.
            //    OrderByDescending(p => p.Id).
            //            Where(p => p.Sistema.Contains(busca) || p.Tema.Contains(busca) || p.Orgao.Contains(busca) ||
            //            p.link.Contains(busca) || p.lei.Contains(busca) || p.Estado.Contains(busca) || p.Municipio.Contains(busca) ||
            //            p.Arqpdf.Contains(busca) || p.Ambito.Contains(busca) || p.Ementa.Contains(busca)).ToList();
            //    ViewBag.Busca = busca;

            LegisGeral objCliente = new LegisGeral();
            var todos = legisGeralNeg.findAll();
            objCliente.Id = todos[0].Id;
            objCliente.Ambito = todos[0].Ambito;
            objCliente.Ano = todos[0].Ano;
            objCliente.Arqpdf = todos[0].Arqpdf;
            objCliente.Data = todos[0].Data;
            objCliente.Ementa = todos[0].Ementa;
            objCliente.lei = todos[0].lei;
            objCliente.link = todos[0].link;
            objCliente.Localidade = todos[0].Localidade;
            objCliente.Municipio = todos[0].Municipio;
            objCliente.Numero = todos[0].Numero;
            objCliente.Orgao = todos[0].Orgao;
            objCliente.Pais = todos[0].Pais;
            objCliente.param = todos[0].param;
            objCliente.Sistema = todos[0].Sistema;
            objCliente.Tema = todos[0].Tema;
            objCliente.Tipo = todos[0].Tipo;
            int pageSize = 50;
            int pageNumber = (pagina ?? 1);
            if (todos.Count() < pageSize * pageNumber) pageNumber = 1;
            ViewBag.Execucao = todos;
            return View(todos.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(string Id)
        {
           // var legisGeral = new List<LegisGeral>();
            int id = Convert.ToInt32(Id);
            ViewBag.ID = id;
            ViewBag.Caminho = "/content/arquivos/pdf/";
            Session["IdLEI"] = id;
            LegisGeral objCliente = new LegisGeral();
            var todos = legisGeralNeg.BuscarPorId(Id);
            if(todos.Count > 0)
            {
                objCliente.Id = todos[0].Id;
                objCliente.Ambito = todos[0].Ambito;
                objCliente.Ano = todos[0].Ano;
                objCliente.Arqpdf = todos[0].Arqpdf;
                objCliente.Data = todos[0].Data;
                objCliente.Ementa = todos[0].Ementa;
                objCliente.lei = todos[0].lei;
                objCliente.link = todos[0].link;
                objCliente.Localidade = todos[0].Localidade;
                objCliente.Municipio = todos[0].Municipio;
                objCliente.Numero = todos[0].Numero;
                objCliente.Orgao = todos[0].Orgao;
                objCliente.Pais = todos[0].Pais;
                objCliente.param = todos[0].param;
                objCliente.Sistema = todos[0].Sistema;
                objCliente.Tema = todos[0].Tema;
                objCliente.Tipo = todos[0].Tipo;
            }
        
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Details(LegisGeral objCliente)
        {
            legisGeralNeg.update(objCliente);
            return RedirectToAction("Index", "LegisGeral");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

