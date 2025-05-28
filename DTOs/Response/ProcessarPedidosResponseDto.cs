using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs;

public class ProcessarPedidosResponseDto
{
    [JsonPropertyName("pedidos")]
    public List<PedidoResponseDto> Pedidos { get; set; } = new();
}