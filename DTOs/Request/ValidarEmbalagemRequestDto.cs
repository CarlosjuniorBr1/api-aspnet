using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs.Request;

public class ValidarEmbalagemRequestDto
{
    [JsonPropertyName("pedidos")]
    public List<PedidoValidacaoDto> Pedidos { get; set; } = new();
}