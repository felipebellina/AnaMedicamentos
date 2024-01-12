using ControleMedicamentos.Models;

namespace ControleMedicamentos.Helper;

public interface ISessao
{
    void CriarSessaoDoUsuario(UsuarioModel usuario);
    void RemoverSessaoDoUsuario();
    UsuarioModel BuscarSessaoDoUsuario();
}
