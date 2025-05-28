using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs;

public class CaixaUsadaDto
{
    [JsonPropertyName("caixa_id")]
    public string CaixaId { get; set; }
    [JsonPropertyName("produtos")]
    public List<string> ProdutosId { get; set; } = new();
}