using ControleMedicamentos.Models;
using ControleMedicamentos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleMedicamentos.Controllers;

public class MedicamentoController : Controller
{
    private readonly IMedicamentoRepositorio _medicamentoRepositorio;
    public MedicamentoController(IMedicamentoRepositorio medicamentoRepositorio)
    {
        _medicamentoRepositorio = medicamentoRepositorio;
    }
    public IActionResult Index()
    {
        var medicamentos = _medicamentoRepositorio.ListarTodos();

        return View(medicamentos);
    }

    public IActionResult Criar()
    {
        return View();
    }

    public IActionResult Editar(int id)
    {
        var medicamento = _medicamentoRepositorio.ListarPorId(id);
        return View(medicamento);
    }

    public IActionResult ApagarConfirmacao(int id)
    {
        var medicamento = _medicamentoRepositorio.ListarPorId(id);

        return View(medicamento);
    }

    [HttpPost]
    public IActionResult Criar(MedicamentoModel medicamento)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(medicamento);
            }
            _medicamentoRepositorio.Adicionar(medicamento);
            TempData["MensagemSucesso"] = "Medicamento cadastrado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception mensagem)
        {

            TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o medicamento. Detalhes do erro: {mensagem.Message}";
            return RedirectToAction("Index");
        }
        
    }

    [HttpPost]
    public IActionResult Alterar(MedicamentoModel medicamento)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", medicamento);
            }
            _medicamentoRepositorio.Atualizar(medicamento);
            TempData["MensagemSucesso"] = "Medicamento alterado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception mensagem)
        {

            TempData["MensagemErro"] = $"Ops, não conseguimos alterar o medicamento. Detalhes do erro: {mensagem.Message}";
            return RedirectToAction("Index");
        }
        
    }

    public IActionResult Apagar(int id)
    {
        try
        {
            bool apagado = _medicamentoRepositorio.Apagar(id);
            if (apagado)
            {
                TempData["MensagemSucesso"] = "Medicamento apagado com sucesso.";
            }
            else
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o medicamento.";
            }
            
            return RedirectToAction("Index");
        }
        catch (Exception mensagem)
        {

            TempData["MensagemErro"] = $"Ops, não conseguimos apagar o medicamento. Detalhes do erro: {mensagem.Message}";
            return RedirectToAction("Index");
        }

        
    }
}
