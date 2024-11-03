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
        builder.Property(c => c.Id)
            .IsRequired()
            .HasColumnType("uniqueidentifier");

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(c => c.Descricao)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(255);

        builder.Property(c => c.Preco)
            .IsRequired();

        builder.Property(c => c.Imagem)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(255);

        builder.HasOne(c => c.Categoria)
            .WithMany(c => c.ItensDoMenu)
            .HasForeignKey("CategoriaId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
