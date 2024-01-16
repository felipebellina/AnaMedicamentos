using ControleMedicamentos.Enums;
using ControleMedicamentos.Helper;
using System.ComponentModel.DataAnnotations;

namespace ControleMedicamentos.Models;

public class UsuarioModel
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Digite o nome do usuário")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Digite o login do usuário")]
    public string? Login { get; set; }
    [Required(ErrorMessage ="Digite o e-mail do usuário")]
    [EmailAddress(ErrorMessage ="O e-mail informado não é valido!")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Informe o perfil do usuário")]
    public PerfilEnum? Perfil { get; set; }
    [Required(ErrorMessage ="Digite a senha do usuário")]
    public string? Senha { get; set; }
    public DateTime? DataDeCadastro { get; set; }
    public DateTime? DataAtualização { get; set; }
    public virtual List<MedicamentoModel>? Medicamentos { get; set; }

    public bool SenhaValida (string senha)
    {
        return Senha.Equals(senha.GerarHash());
    }

    public void SetSenhaHash()
    {
        Senha = Senha.GerarHash();
    }

    public void SetNovaSenha(string novaSenha)
    {
        Senha = novaSenha.GerarHash();
    }
}
