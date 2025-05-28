using System.Text.Json.Serialization;
namespace ApiLojaManoel.DTOs.Request;

public class CaixaValidacaoDto
{
    [JsonPropertyName("caixa_id")]
    public string? CaixaId { get; set; }
    
    [JsonPropertyName("produtos")]
    public List<string> Produtos { get; set; } = new();
    
    [JsonPropertyName("observacao")]
    public string? Observacao { get; set; }
}