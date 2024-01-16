using ControleMedicamentos.Models;

namespace ControleMedicamentos.Repositorio;

public interface IUsuarioRepositorio
{
    UsuarioModel BuscarPorEmailELogin(string email, string login);
    UsuarioModel BuscarPorLogin(string login);
    UsuarioModel ListarPorId(int id);
    List<UsuarioModel> ListarTodos();
    UsuarioModel Adicionar(UsuarioModel usuario);
    UsuarioModel Atualizar(UsuarioModel usuario);
    UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
    bool Apagar(int id);
}
