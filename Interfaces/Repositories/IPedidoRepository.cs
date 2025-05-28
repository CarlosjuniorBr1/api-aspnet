namespace ApiLojaManoel.Interfaces;

using ApiLojaManoel.Models;


public interface IPedidoRepository
{
    Task<Pedido> AdicionarAsync(Pedido pedido);
    Task<Pedido?> ObterPorIdAsync(long id);
    Task<List<Pedido>> ObterTodosAsync();
}
