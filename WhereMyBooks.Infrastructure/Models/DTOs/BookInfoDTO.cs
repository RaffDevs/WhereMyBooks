using System.Text.Json.Serialization;

namespace WhereMyBooks.Infrastructure.Models.DTOs;

public record BookInfoDTO
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("authors")]
    public List<string> Authors { get; set; }

    [JsonPropertyName("publisher")]
    public string Publisher { get; set; }

    [JsonPropertyName("publishedDate")]
    public string PublishedDate { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("pageCount")]
    public int PageCount { get; set; }

    [JsonPropertyName("printType")]
    public string PrintType { get; set; }

    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; }

    [JsonPropertyName("imageLinks")]
    public ImageLinkDTO ImageLinks { get; set; }
    
    [JsonPropertyName("industryIdentifiers")]
    public List<IndustryIdentifiersDTO> IndustryIdentifiersDto { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("previewLink")]
    public string PreviewLink { get; set; }

    [JsonPropertyName("infoLink")]
    public string InfoLink { get; set; }

    [JsonPropertyName("canonicalVolumeLink")]
    public string CanonicalVolumeLink { get; set; }
};