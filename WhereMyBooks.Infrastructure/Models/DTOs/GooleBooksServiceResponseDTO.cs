using System.Text.Json.Serialization;

namespace WhereMyBooks.Infrastructure.Models.DTOs;

public record GooleBooksServiceResponseDTO
{
    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("totalItems")]
    public int TotalItems { get; set; }

    [JsonPropertyName("items")]
    public List<BookItemDTO> Items { get; set; }
};