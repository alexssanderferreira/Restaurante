using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entidades;
using Restaurante.Domain.ObjetosDeValor;

namespace Restaurante.Infrastructure.Persistencia;

public class RestauranteContext : DbContext
{
    public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestauranteContext).Assembly);
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Cartao> Cartoes { get; set; }
    public DbSet<ItemDoMenu> ItensDoMenu { get; set; }
    public DbSet<ItensDoPedido> ItensDosPedidos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
}
