using ControleMedicamentos.Models;

namespace ControleMedicamentos.Repositorio;

public interface IMedicamentoRepositorio
{
    MedicamentoModel ListarPorId(int id);
    List<MedicamentoModel> ListarTodos();
    MedicamentoModel Adicionar(MedicamentoModel medicamento);
    MedicamentoModel Atualizar(MedicamentoModel medicamento);
    bool Apagar(int id);
}
