﻿using ControleMedicamentos.Models;
using Newtonsoft.Json;

namespace ControleMedicamentos.Helper;

public class Sessao : ISessao
{
    private readonly IHttpContextAccessor _contextAccessor;

    public Sessao(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public UsuarioModel BuscarSessaoDoUsuario()
    {
        string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");
        if (string.IsNullOrEmpty(sessaoUsuario))
        {
            return null;
        }
        else
        {
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }
    }

    public void CriarSessaoDoUsuario(UsuarioModel usuario)
    {
        string valor = JsonConvert.SerializeObject(usuario);
        _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);

    }

    public void RemoverSessaoDoUsuario()
    {
        _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
    }
}