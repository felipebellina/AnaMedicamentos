using ControleMedicamentos.Helper;
using ControleMedicamentos.Models;
using ControleMedicamentos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleMedicamentos.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly ISessao _sessao;
    public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _sessao = sessao;
    }

    public IActionResult Index()
    {
        //Se o usuário estiver logado redirect para a home
        if (_sessao.BuscarSessaoDoUsuario() != null)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    public IActionResult RedefinirSenha()
    {
        return View();
    }

    public IActionResult Sair()
    {
        _sessao.RemoverSessaoDoUsuario();
        return RedirectToAction("Index", "Login");
    }

    [HttpPost]
    public IActionResult Entrar(LoginModel loginModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                if (usuario is not null)
                {
                    
                    if (usuario.SenhaValida(loginModel.Senha))
                    {
                        _sessao.CriarSessaoDoUsuario(usuario);
                        return RedirectToAction("Index", "Home");
                    }
                    
                    TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    return View("Index");
                }

                TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s)";
            }

            return View("Index");
        }
        catch (Exception mensagem)
        {
            TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login. Detalhes do erro {mensagem.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                if (usuario is not null)
                {
                    TempData["MensagemSucesso"] = $"Não conseguimos redefinir sua senha. Por favor verifique os dados informados.1";
                    return RedirectToAction("Index", "Login");
                }

                TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor verifique os dados informados.";
            }

            return View("Index");
        }
        catch (Exception mensagem)
        {
            TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha. Detalhes do erro: {mensagem.Message}";
            return RedirectToAction("Index");
        }
    }
}
