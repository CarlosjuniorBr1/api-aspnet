using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs.Request;

public class PedidoRequestDto
{
    [JsonPropertyName("pedido_id")]
    public int Pedido_Id { get; set; }

    // Esta propriedade mapeia "produtos" do JSON
    [JsonPropertyName("produtos")]
    public List<ProdutoDto> Produtos { get; set; } = new();

}