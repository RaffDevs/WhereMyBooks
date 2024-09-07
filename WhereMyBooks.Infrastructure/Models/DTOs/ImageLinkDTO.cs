using System.Text.Json.Serialization;

namespace WhereMyBooks.Infrastructure.Models.DTOs;

public record ImageLinkDTO
{
    [JsonPropertyName("smallThumbnail")]
    public string SmallThumbnail { get; set; }

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }
};