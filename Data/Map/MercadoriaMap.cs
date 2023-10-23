using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MorningStartApi.Models;

namespace MorningStartApi.Data.Map
{
    public class MercadoriaMap : IEntityTypeConfiguration<MercadoriaModel>
    {
        public void Configure(EntityTypeBuilder<MercadoriaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.NumeroDeRegistro);
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Fabricante).IsRequired();
        }
    }
}
