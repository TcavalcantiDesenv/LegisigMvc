using Model.Entity;
using Model.Neg;
using PagedList;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    [Authorize]
    public class AgendamentosController : Controller
    {
        // GET: Clientes
        AgendamentoNeg objAgendamentoNeg;
    public AgendamentosController()
    {
        objAgendamentoNeg = new AgendamentoNeg();
    }
    public ActionResult Index(string busca = "", int pagina = 1, int tamanhoPagina = 10)
    {
        objAgendamentoNeg = new AgendamentoNeg();
        ViewBag.DiasDaSemana = GerarDiasDaSemana();
        ViewBag.Horarios = GerarHorarios();
        var Agendamento = objAgendamentoNeg.findAll().OrderBy(a => a.DiaDaSemana).ThenBy(a => a.HoraDeExecucao).ToList();
        ViewBag.Agendamento = Agendamento;
        return View(Agendamento.ToPagedList(pagina, tamanhoPagina));
    }

    [HttpGet]
    public ActionResult Create()
    {
        mensagemInicioRegistrar();
        return View();
    }

    // POST: Cliente/Create
    [HttpPost]
    public ActionResult Create(Agendamento objAgendamento)
    {
        if (ModelState.IsValid)
        {
            mensagemInicioRegistrar();
            objAgendamentoNeg.create(objAgendamento);
            MensagemErroRegistrar(objAgendamento);
            ModelState.Clear();
            return RedirectToAction("Index");
        }
        return View("Create");
    }

    [HttpGet]
    public ActionResult Deletar(int id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        mensagemInicialEliminar();
        Agendamento objAgendamento = new Agendamento(id);
        return View(objAgendamento);
    }

    [HttpPost, ActionName("Deletar")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        mensagemInicialEliminar();
        Agendamento objAgendamento = new Agendamento(id);
        objAgendamentoNeg.delete(objAgendamento);
        mostrarMensagemEliminar(objAgendamento);
        return Redirect("~/Agendamentos/Index");
    }
    public static SelectList GerarDiasDaSemana()
    {
        //Método para gerar uma lista com os dias da semana
        return new SelectList(
            new[] {
                    new { Value = "Domingo", Label = "Domingo" },
                    new { Value = "Segunda-Feira", Label = "Segunda-Feira" },
                    new { Value = "Terça-Feira", Label = "Terça-Feira" },
                    new { Value = "Quarta-Feira", Label = "Quarta-Feira" },
                    new { Value = "Quinta-Feira", Label = "Quinta-Feira" },
                    new { Value = "Sexta-Feira", Label = "Sexta-Feira" },
                    new { Value = "Sábado", Label = "Sábado" }
            }, "Value", "Label");
    }
    public static SelectList GerarHorarios()
    {
        //Método para gerar uma lista com os horários
        return new SelectList(
            new[]
            {
                    new { Value = "06:00", Label = "06:00"},
                    new { Value = "07:00", Label = "07:00"},
                    new { Value = "08:00", Label = "08:00"},
                    new { Value = "09:00", Label = "09:00"},
                    new { Value = "10:00", Label = "10:00"},
                    new { Value = "11:00", Label = "11:00"},
                    new { Value = "12:00", Label = "12:00"},
                    new { Value = "13:00", Label = "13:00"},
                    new { Value = "14:00", Label = "14:00"},
                    new { Value = "15:00", Label = "15:00"},
                    new { Value = "16:00", Label = "16:00"},
                    new { Value = "17:00", Label = "17:00"},
                    new { Value = "18:00", Label = "18:00"},
                    new { Value = "19:00", Label = "19:00"},
                    new { Value = "20:00", Label = "20:00"},
                    new { Value = "21:00", Label = "21:00"},
                    new { Value = "22:00", Label = "22:00"},
                    new { Value = "23:00", Label = "23:00"},
                    new { Value = "00:00", Label = "00:00"},
                    new { Value = "01:00", Label = "01:00"},
                    new { Value = "02:00", Label = "02:00"},
                    new { Value = "03:00", Label = "03:00"},
                    new { Value = "04:00", Label = "04:00"},
                    new { Value = "05:00", Label = "05:00"}
            }, "Value", "Label");
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            //  _db.Dispose();
        }
        base.Dispose(disposing);
    }
    public void mensagemInicioRegistrar()
    {
        ViewBag.MensagemInicio = "Insira os dados do Cliente e clique em salvar";
    }
    public void MensagemErroRegistrar(Agendamento objCliente)
    {

        //switch (objCliente.Estados)
        //{

        //    case 1000://campo cpf com letras
        //        ViewBag.MensagemErro = "Erro CPF, não insira Letras";
        //        break;

        //    case 20://campo nome vazio
        //        ViewBag.MensagemErro = "Insira Nome do Cliente";
        //        break;

        //    case 2://erro de nome
        //        ViewBag.MensagemErro = "O nome não pode ter mais de 30 caracteres";
        //        break;


        //    case 50://campo cpf vazio
        //        ViewBag.MensagemErro = "Insira CPF do Cliente";
        //        break;

        //    case 250://campo cpf vazio
        //        ViewBag.MensagemErro = "O CPF tem que ter 11 numeros, apenas numeros";
        //        break;


        //    case 60://endereco vazio
        //        ViewBag.MensagemErro = "Insira endereço do Cliente";
        //        break;

        //    case 6://erro no endereço
        //        ViewBag.MensagemErro = "Campo endereço não pode ter mais de 50 caracteres";
        //        break;

        //    case 70://campo telefone vazio
        //        ViewBag.MensagemErro = "Insira o telefone do cliente";
        //        break;

        //    case 7://campo telefone vazio
        //        ViewBag.MensagemErro = "O telefone tem que ter de 8 a 15 digitos";
        //        break;

        //    case 8://erro de duplicidade
        //        ViewBag.MensagemErro = "Cliente [" + objCliente.AgendamentoId + "] já está registrado no sistema";
        //        break;

        //    case 9://erro de duplicidade
        //        ViewBag.MensagemErro = "Numero de DiaDaSemana [" + objCliente.DiaDaSemana + "] já está registrado no sistema";
        //        break;

        //    case 99://Cliente Salvo com Sucesso
        //        ViewBag.MensagemExito = "Razão HoraDeExecucao [" + objCliente.HoraDeExecucao + "] foi inserido no sistema";
        //        break;

        //}

    }
    private void mostrarMensagemEliminar(Agendamento objCliente)
    {

    }
    public void mensagemInicialEliminar()
    {
        ViewBag.MensagemInicialEliminar = "Formulario de Exclusão";
    }
}
}