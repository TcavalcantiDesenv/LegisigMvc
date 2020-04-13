using PlatinDashboard.Presentation.MVC.ApiServices;
using PlatinDashboard.Presentation.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class BaixarArquivoController : Controller
    {
        UploadFileResult oModelArquivos = new UploadFileResult();
        private readonly ServicosApi _servicosApi;

        public BaixarArquivoController()
        {
            _servicosApi = new ServicosApi();
        }
        // GET: BaixarArquivo
        public ActionResult Index()
        {
            string host = Dns.GetHostName();
            string ip = Dns.GetHostAddresses(host)[2].ToString();
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
           // return a4;
            ViewBag.ListaIP = a4;


            var _arquivos = oModelArquivos.ListaArquivos(Server.MapPath("~/Arquivos"));
            ViewBag.ListaProdutos = _arquivos;
            return View(_arquivos);
        }
        public ActionResult Recria()
        {
            var gravado = _servicosApi.GravarArquivoProdutos();
            return RedirectToAction("Index", "BaixarArquivo");
        }
        public FileResult Download(string id)
        {
            int _arquivoId = Convert.ToInt32(id);
            string contentType = "";
            var arquivos = oModelArquivos.ListaArquivos(Server.MapPath("~/Arquivos"));
            string nomeArquivo = (from arquivo in arquivos
                                  where arquivo.IDArquivo == _arquivoId
                                  select arquivo.Caminho).First();
            string extensao = Path.GetExtension(nomeArquivo);
            string nomeArquivoV = Path.GetFileNameWithoutExtension(nomeArquivo);
            if (extensao.Equals(".abc"))
                contentType = "application/txt";
            if (extensao.Equals(".JPG") || extensao.Equals(".GIF") || extensao.Equals(".PNG"))
                contentType = "application/image";
            return File(nomeArquivo, contentType, nomeArquivoV + extensao);
        }
    }
}