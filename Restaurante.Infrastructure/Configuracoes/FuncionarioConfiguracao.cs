using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain.Entidades;

namespace Restaurante.Infrastructure.Configuracoes;

public class FuncionarioConfiguracao : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("Funcionarios");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnType("uniqueidentifier");
        builder.Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.Property(c => c.Telefone).HasColumnType("varchar").HasMaxLength(15).IsRequired();
        builder.Property(c => c.Login).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.Property(c => c.Senha).HasColumnType("varchar").HasMaxLength(255).IsRequired();
        builder.Property(c => c.TipoUsuario).IsRequired();
        builder.OwnsOne(c => c.Email, tf =>
        {
            tf.Property(c => c.EnderecoEmail)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"varchar(max)");
        });
    }
}
