using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs.Request;

public class ProcessarPedidosRequestDto
{
   [JsonPropertyName("pedidos")]
    public List<PedidoRequestDto> Pedidos { get; set; } = new();
}
