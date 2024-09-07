using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Services;
using WhereMyBooks.Infrastructure.Models.DTOs;
using WhereMyBooks.Infrastructure.Models.Mappers;

namespace WhereMyBooks.Infrastructure.Services;

public class BookService : IBookService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private readonly string _key;

    public BookService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _config = configuration;
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient("GoogleService");
        _key = _config.GetSection("GoogleService:API").Value;
    }

    public async Task<List<Book>> SearchBooks(string title, int idShelf)
    {

        try
        {
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = "/books/v1/volumes",
                Query = $"q=intitle:{title}&maxResults=5&key={_key}",
                Scheme = "https",
                Port = 443
            };

            var uri = uriBuilder.Uri;
            using var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GooleBooksServiceResponseDTO>();

            var items = result.Items
                .Select(b => GoogleBookMapper.MapGoogleBookToBook(b, idShelf))
                .ToList();

            return items;
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            throw;
        }
        
    }

}