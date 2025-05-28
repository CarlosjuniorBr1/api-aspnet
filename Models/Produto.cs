using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiLojaManoel.models;

public class Produto
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public long Id { get; set; }

    public string ProdutoId { get; set; }
    public double Altura { get; set; }
    public double Largura { get; set; }
    public double Comprimento { get; set; }
    public double Volume { get; set; }
    public long? PedidoId { get; set; }

    public Produto() { }

    public Produto(string produtoId, double altura, double largura, double comprimento)
    {
        ProdutoId = produtoId;
        Altura = altura;
        Largura = largura;
        Comprimento = comprimento;
        Volume = altura * largura * comprimento;
    }
}