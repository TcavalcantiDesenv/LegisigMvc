using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Model.Entity;
using Model.Neg;
using PlatinDashboard.Presentation.MVC.ApiServices;
using PlatinDashboard.Presentation.MVC.Models;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class ArquivosController : Controller
    {
        // GET: Arquivos
        public ActionResult Index()
        {
            List<Arquivos> lstArquivos = new List<Arquivos>();
            //DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Arquivos"));
            DirectoryInfo dirInfo = new DirectoryInfo("c:/dados/Arquivos/");
            int i = 0;
            var ObjArquivosNeg = new ArquivosNeg();
            var arquivos = ObjArquivosNeg.findAll();
            foreach (var item in arquivos.OrderBy(e => e.NOME).ToList())
            {
                lstArquivos.Add(new Arquivos()
                {
                    NOME = item.NOME,
                    DESCRICAO = item.DESCRICAO,
                    OBSERVACAO = item.DESCRICAO,
                    CAMINHO = dirInfo.FullName + @"\" + item.CAMINHO
                });
                i = i + 1;
            }

            // Gera lista de produtos para pagina
            //var Aquivos = ObjArquivosNeg.findAll();
            ViewBag.ListaProdutos = lstArquivos;// Aquivos.OrderBy(e => e.NOME).ToList();
            return View(lstArquivos);

        }
    }
}