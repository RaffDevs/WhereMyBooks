using System.Text.Json.Serialization;

namespace WhereMyBooks.Infrastructure.Models.DTOs;

public record BookItemDTO
{
        
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("selfLink")]
        public string SelfLink { get; set; }

        [JsonPropertyName("volumeInfo")]
        public BookInfoDTO BookInfo { get; set; }
        
}