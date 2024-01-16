using ControleMedicamentos.Data;
using ControleMedicamentos.Models;

namespace ControleMedicamentos.Repositorio;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly MedicamentoDbContext _dbContext;
    public UsuarioRepositorio(MedicamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public UsuarioModel Adicionar(UsuarioModel usuario)
    {
        //add no DB
        usuario.DataDeCadastro = DateTime.Now;
        usuario.SetSenhaHash();
        _dbContext.Usuarios.Add(usuario);
        _dbContext.SaveChanges();
        return usuario;

    }

    public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
    {
        UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);

        if (usuarioDB is null)
        {
            throw new Exception("Houve um erro na atualização da senha. Usuário não encontrado.");
        }

        if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual))
        {
            throw new Exception("Senha atual não confere.");
        }

        if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha))
        {
            throw new Exception("Nova senha deve ser diferente da atual.");
        }

        usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
        usuarioDB.DataAtualização = DateTime.Now;

        _dbContext.Usuarios.Update(usuarioDB);
        _dbContext.SaveChanges();

        return usuarioDB;
    }

    public bool Apagar(int id)
    {
        var usuarioDB = ListarPorId(id);
        if (usuarioDB == null)
        {
            throw new Exception("Houve uma erro ao apagar o usuário!");
        }
        else
        {
            _dbContext.Usuarios.Remove(usuarioDB);
            _dbContext.SaveChanges();

            return true;
        }
    }

    public UsuarioModel Atualizar(UsuarioModel usuario)
    {
        UsuarioModel usuarioDB = ListarPorId(usuario.Id);
        if (usuarioDB == null)
        {
            throw new Exception("Houve um erro na atualização do usuário!");
        }
        else
        {
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualização = DateTime.Now;
        }

        _dbContext.Usuarios.Update(usuarioDB);
        _dbContext.SaveChanges();

        return usuarioDB;
    }

    public UsuarioModel BuscarPorEmailELogin(string email, string login)
    {
        return _dbContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper().Equals(email.ToUpper()) && x.Login.ToUpper().Equals(login.ToUpper()));
    }

    public UsuarioModel BuscarPorLogin(string login)
    {
        return _dbContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper().Equals(login.ToUpper()));
    }

    public UsuarioModel ListarPorId(int id)
    {
        return _dbContext.Usuarios.FirstOrDefault(x => x.Id == id);
    }

    public List<UsuarioModel> ListarTodos()
    {
        return _dbContext.Usuarios.ToList();
    }
}

