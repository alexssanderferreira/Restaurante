using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain.Entidades;

namespace Restaurante.Infrastructure.Configuracoes;

public class ClienteConfiguracao : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier");
        builder.Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.Property(c => c.Telefone).HasColumnType("varchar").HasMaxLength(15).IsRequired();
        builder.Property(c => c.TipoUsuario).IsRequired();
    }
}
