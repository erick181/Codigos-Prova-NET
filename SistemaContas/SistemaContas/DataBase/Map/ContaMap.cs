using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaContas.Models;

namespace SistemaContas.DataBase.Map
{
    public class ContaMap : IEntityTypeConfiguration<ContaModel>
    {
        public void Configure(EntityTypeBuilder<ContaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(200);
            builder.Property(x => x.Descricao).HasMaxLength(500);
        }
    }
}
