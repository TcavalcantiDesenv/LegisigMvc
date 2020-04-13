using Model.Neg;
using PagedList;
using PlatinDashboard.Presentation.MVC.ApiServices;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class AbcFarmaController : Controller
    {
        private readonly ServicosApi _servicosApi;

        public AbcFarmaController()
        {
            _servicosApi = new ServicosApi();
        }
        // GET: AbcFarma
        public ActionResult Index(string busca = "", int pagina = 1, int tamanhoPagina = 10)
        {
         //   var ObjAbcFatmaNeg = new AbcFatmaNeg();


            //List<ProdutosAbcFarma> listaProdutos = ObjAbcFatmaNeg.findAll(); //.Where(c => c. Status == 0).OrderBy(b => b.Name).ToList();
            //var produtos = listaProdutos.Where(b => b.EAN.Contains(busca) || b.DESCRICAO.Contains(busca) || 
            //b.NOME.Contains(busca) || b.NOME_FABRICANTE.Contains(busca)).OrderBy(b => b.NOME).ToPagedList(pagina, tamanhoPagina);


            //ViewBag.Busca = busca;
            //ViewBag.TamanhoPagina = tamanhoPagina;

            return View();
        }
           
        //public ActionResult Index()
        //{
        //    var ObjAbcFatmaNeg = new AbcFatmaNeg();
        //    var Produtos = _servicosApi.BuscarTodosProdutos(1,0);         

        //    ViewBag.ListaProdutos = Produtos.ToList().OrderBy(p => p.NOME);
        //   return View(Produtos);
        //}
    }
}