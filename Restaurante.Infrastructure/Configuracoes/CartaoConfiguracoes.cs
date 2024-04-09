using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain.Entidades;

namespace Restaurante.Infrastructure.Configuracoes;

public class CartaoConfiguracoes : IEntityTypeConfiguration<Cartao>
{
    public void Configure(EntityTypeBuilder<Cartao> builder)
    {
        builder.ToTable("Cartoes");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier");
        builder.Property(c => c.Numero).HasMaxLength(16).IsRequired();
        builder.Property(c => c.Pago).IsRequired();
        builder.Property(c => c.Status).IsRequired();
        builder.Property(c => c.DataHoraPagamento).IsRequired();
    }
}

