using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs;

public class PedidoResponseDto
{
    [JsonPropertyName("pedido_id")]
    public int PedidoId { get; set; }

    [JsonPropertyName("caixas")]
    public List<CaixaUsadaDto> Caixas { get; set; } = new();
}
