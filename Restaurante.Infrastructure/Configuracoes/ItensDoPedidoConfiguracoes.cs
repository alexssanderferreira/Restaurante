using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entidades;

public class ItensDoPedidoConfiguracoes : IEntityTypeConfiguration<ItensDoPedido>
{
    public void Configure(EntityTypeBuilder<ItensDoPedido> builder)
    {
        builder.ToTable("ItensDosPedidos");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier");
        builder.Property(c => c.Quantidade).IsRequired();
        builder.Property(c => c.Modificacoes).HasColumnType("varchar").HasMaxLength(255).IsRequired();
        builder.Property(c => c.Total).IsRequired();
        builder.Property("PedidoId").IsRequired().HasColumnType("uniqueidentifier");
        builder.Property("ItemDoMenuId").IsRequired().HasColumnType("uniqueidentifier");
    }
}
