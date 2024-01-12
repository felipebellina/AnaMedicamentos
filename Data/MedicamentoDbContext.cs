using ControleMedicamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleMedicamentos.Data;

public class MedicamentoDbContext : DbContext
{
    public MedicamentoDbContext(DbContextOptions<MedicamentoDbContext> options) : base(options)
    {
    }

    public DbSet<MedicamentoModel> Medicamentos { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
}
