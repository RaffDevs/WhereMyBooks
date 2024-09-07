using System.Text.Json.Serialization;

namespace WhereMyBooks.Infrastructure.Models.DTOs;

public record IndustryIdentifiersDTO
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    
    [JsonPropertyName("identefier")]
    public string Identifier { get; init; }
}