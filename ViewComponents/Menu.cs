using ControleMedicamentos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControleMedicamentos.ViewComponents;

public class Menu : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

        if (string.IsNullOrEmpty(sessaoUsuario))
        {
            return null;
        }
        else
        {
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            return View(usuario);
        }
    }
}
