using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entidades;

public class PedidoConfiguracoes : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier");
        builder.Property(c => c.Data).IsRequired();
        builder.Property(c => c.Status).IsRequired();
        builder.Property(c => c.Total).IsRequired();
        builder.Property("CartaoId").IsRequired().HasColumnType("uniqueidentifier");
    }
}
