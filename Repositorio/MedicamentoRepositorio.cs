using ControleMedicamentos.Data;
using ControleMedicamentos.Models;

namespace ControleMedicamentos.Repositorio;

public class MedicamentoRepositorio : IMedicamentoRepositorio
{
    private readonly MedicamentoDbContext _dbContext;
    public MedicamentoRepositorio(MedicamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MedicamentoModel Adicionar(MedicamentoModel medicamento)
    {
        //add no DB
        _dbContext.Medicamentos.Add(medicamento);
        _dbContext.SaveChanges();
        return medicamento;

    }

    public bool Apagar(int id)
    {
        var medicamentoDB = ListarPorId(id);
        if (medicamentoDB == null)
        {
            throw new Exception("Houve uma erro ao apagar o medicamento!");
        }
        else
        {
            _dbContext.Medicamentos.Remove(medicamentoDB);
            _dbContext.SaveChanges();

            return true;
        }
    }

    public MedicamentoModel Atualizar(MedicamentoModel medicamento)
    {
        MedicamentoModel medicamentoDB = ListarPorId(medicamento.Id);
        if (medicamentoDB == null)
        {
            throw new Exception("Houve um erro na atualização do medicamento!");
        }
        else
        {
            medicamentoDB.NomeMedicamento = medicamento.NomeMedicamento;
            medicamentoDB.DataFabricacao = medicamento.DataFabricacao;
            medicamentoDB.DataVencimento = medicamento.DataVencimento;
            medicamentoDB.Descricao = medicamento.Descricao;
        }

        _dbContext.Medicamentos.Update(medicamentoDB);
        _dbContext.SaveChanges();

        return medicamentoDB;
    }

    public MedicamentoModel ListarPorId(int id)
    {
        return _dbContext.Medicamentos.FirstOrDefault(x => x.Id == id);
    }

    public List<MedicamentoModel> ListarTodos(int usuarioId)
    {
        return _dbContext.Medicamentos.Where(x => x.UsuarioId == usuarioId).ToList();
    }
}
