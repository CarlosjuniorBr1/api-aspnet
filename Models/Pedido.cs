using ApiLojaManoel.models;

namespace ApiLojaManoel.Models;

public class Pedido
{
    public long Id { get; set; }
    public List<Produto> Produtos { get; set; } = new();
}
