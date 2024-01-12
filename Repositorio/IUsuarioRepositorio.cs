using ControleMedicamentos.Models;

namespace ControleMedicamentos.Repositorio;

public interface IUsuarioRepositorio
{
    UsuarioModel BuscarPorLogin(string login);
    UsuarioModel ListarPorId(int id);
    List<UsuarioModel> ListarTodos();
    UsuarioModel Adicionar(UsuarioModel usuario);
    UsuarioModel Atualizar(UsuarioModel usuario);
    bool Apagar(int id);
}
