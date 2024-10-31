using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain.Entidades;

namespace Restaurante.Infrastructure.Configuracoes;

public class ItensDoMenuConfiguracoes : IEntityTypeConfiguration<ItemDoMenu>
{
    public void Configure(EntityTypeBuilder<ItemDoMenu> builder)
    {
        builder.ToTable("ItensDoMenu");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier");
        builder.Property(c => c.Nome).HasColumnType("varchar").IsRequired().HasMaxLength(50);
        builder.Property(c => c.Descricao).HasColumnType("varchar").IsRequired().HasMaxLength(100);
        builder.Property(c => c.Preco).IsRequired();
        builder.Property(c => c.Imagem).HasColumnType("varchar").HasMaxLength(255).IsRequired();
        builder.Property("CategoriaId").IsRequired().HasColumnType("uniqueidentifier");
    }
}

