using ControleMedicamentos.Models;
using ControleMedicamentos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleMedicamentos.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;


    public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }
    public IActionResult Criar()
    {
        return View();
    }
    public IActionResult Editar(int id)
    {
        var usuario = _usuarioRepositorio.ListarPorId(id);
        return View(usuario);
    }

    public IActionResult Index()
    {
        var usuario = _usuarioRepositorio.ListarTodos();

        return View(usuario);
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            _usuarioRepositorio.Adicionar(usuario);
            TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception mensagem)
        {

            TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o usuário. Detalhes do erro: {mensagem.Message}";
            return RedirectToAction("Index");
        }

    }
    public IActionResult ApagarConfirmacao(int id)
    {
        var usuario = _usuarioRepositorio.ListarPorId(id);

        return View(usuario);
    }
    public IActionResult Apagar(int id)
    {
        try
        {
            bool apagado = _usuarioRepositorio.Apagar(id);
            if (apagado)
            {
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso.";
            }
            else
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o usuário.";
            }

            return RedirectToAction("Index");
        }
        catch (Exception mensagem)
        {

            TempData["MensagemErro"] = $"Ops, não conseguimos apagar o usuário. Detalhes do erro: {mensagem.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
    {
        try
        {
            UsuarioModel usuario = null;

            if (!ModelState.IsValid)
            {
                return View("Editar", usuario);
            }
            usuario = new UsuarioModel()
            {
                Id = usuarioSemSenhaModel.Id,
                Nome = usuarioSemSenhaModel.Nome,
                Login = usuarioSemSenhaModel.Login,
                Email = usuarioSemSenhaModel.Email,
                Perfil = usuarioSemSenhaModel.Perfil
            };

            _usuarioRepositorio.Atualizar(usuario);
            TempData["MensagemSucesso"] = "Usuário alterado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception mensagem)
        {

            TempData["MensagemErro"] = $"Ops, não conseguimos alterar o usuário. Detalhes do erro: {mensagem.Message}";
            return RedirectToAction("Index");
        }

    }
}
