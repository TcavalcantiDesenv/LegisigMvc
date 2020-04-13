using PagedList;
using Servicos;
using System.Linq;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class ProdutosOrigemVannonController : Controller
    {
        private readonly ApiService _vannonService;

        public ProdutosOrigemVannonController()
        {
            _vannonService = new ApiService();
        }

        // GET: Produtos
        public ActionResult Index(int? pagina, string busca)
        {
            var Produto = _vannonService.BuscarTodosProdutos2();
            ViewBag.UltimaExecucao = Produto.OrderBy(e => e.description).ToList();

            if (string.IsNullOrEmpty(busca))
            {
                Produto = _vannonService.BuscarTodosProdutos2().OrderBy(p => p.barcode).Where(p => p.barcode == busca).ToList();


                int total = Produto.Count();
                for (int i = 0; i < Produto.Count; i++)
                {
                    var execucao2 = Produto[i];
                    ViewBag.Produtosincronizado = execucao2;
                }
            }
            else
            {
                Produto = _vannonService.BuscarTodosProdutos2().
                    OrderBy(p => p.barcode).
                    Where(p => p.barcode == busca && (p.barcode.Contains(busca))).ToList();
                ViewBag.Busca = busca;
            }
            int pageSize = 50;
            int pageNumber = (pagina ?? 1);
            if (Produto.Count() < pageSize * pageNumber) pageNumber = 1;


            return View(Produto.ToPagedList(pageNumber, pageSize));
        }
    }
}