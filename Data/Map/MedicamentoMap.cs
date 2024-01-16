using ControleMedicamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMedicamentos.Data.Map;

public class MedicamentoMap : IEntityTypeConfiguration<MedicamentoModel>
{
    public void Configure(EntityTypeBuilder<MedicamentoModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Usuario);
    }
}
