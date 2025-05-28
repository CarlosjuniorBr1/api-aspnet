namespace ApiLojaManoel.Repositories;

using Microsoft.EntityFrameworkCore;
using ApiLojaManoel.Data;
using ApiLojaManoel.Models;
using ApiLojaManoel.Interfaces;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> AdicionarAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido?> ObterPorIdAsync(long id)
    {
        return await _context.Pedidos
            .Include(p => p.Produtos)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Pedido>> ObterTodosAsync()
    {
        return await _context.Pedidos
            .Include(p => p.Produtos)
            .ToListAsync();
    }
}