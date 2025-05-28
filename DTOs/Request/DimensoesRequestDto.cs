using System.Text.Json.Serialization;

namespace ApiLojaManoel.DTOs.Request;

public class DimensoesRequestDto
{
    [JsonPropertyName("altura")]
    public double Altura { get; set; } // Usando double para corresponder ao JSON

    [JsonPropertyName("largura")]
    public double Largura { get; set; } // Usando double para corresponder ao JSON

    [JsonPropertyName("comprimento")]
    public double Comprimento { get; set; } // Usando double para corresponder ao JSON
}