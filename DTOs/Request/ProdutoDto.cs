using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs.Request;

public class ProdutoDto
{
   [JsonPropertyName("produto_id")]
    public string ProdutoId { get; set; } // Use ProdutoId para seguir a convenção C#

    // Mapeia "dimensoes" do JSON para o objeto DimensoesRequestDto
    [JsonPropertyName("dimensoes")]
    public DimensoesRequestDto Dimensoes { get; set; }
}