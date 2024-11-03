using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain.ObjetosDeValor;

namespace Restaurante.Infrastructure.Configuracoes;

public class CategoriaConfiguracoes : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier");
        builder.Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.Property(c => c.Descricao).HasColumnType("varchar").HasMaxLength(255).IsRequired();
    }
}
