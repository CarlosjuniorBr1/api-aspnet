using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs.Request;

public class PedidoValidacaoDto
{
    [JsonPropertyName("pedido_id")]
    public int PedidoId { get; set; }
    
    [JsonPropertyName("caixas")]
    public List<CaixaValidacaoDto> Caixas { get; set; } = new();
}