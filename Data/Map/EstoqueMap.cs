using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MorningStartApi.Models;

namespace MorningStartApi.Data.Map
{
    public class EstoqueMap : IEntityTypeConfiguration<EstoqueModel>
    {
        public void Configure(EntityTypeBuilder<EstoqueModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Local);
            builder.Property(x => x.Operacao);
            builder.Property(x => x.DataRegistro).IsRequired();
            builder.Property(x => x.MercadoriaId);
            builder.HasOne(x => x.Mercadoria);

        }
    }
}
