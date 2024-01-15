using ControleMedicamentos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ControleMedicamentos.Filters;

public class PaginaParaUsuarioLogado : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

        if(string.IsNullOrEmpty(sessaoUsuario))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login"}, {"action" , "Index" } });
        }
        else
        {
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

            if(usuario is null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
        }

        base.OnActionExecuted(context);
    }
}
