using Restaurante.Domain.Entidades;

namespace Restaurante.Infrastructure.Contratos;
public interface ICartaoRepository : IBaseRepository<Cartao>
{
    Task<Cartao> ObterPorNumeroAsync(int numero);
}
