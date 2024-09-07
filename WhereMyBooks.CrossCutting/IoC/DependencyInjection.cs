using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhereMyBooks.Application.Commands.CreateOwner;
using WhereMyBooks.Application.Validations;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Core.Services;
using WhereMyBooks.Infrastructure.Auth;
using WhereMyBooks.Infrastructure.Persistence;
using WhereMyBooks.Infrastructure.Persistence.Repositories;
using WhereMyBooks.Infrastructure.Services;

namespace WhereMyBooks.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IBookShelfRepository, BookShelfRepository>();
        services.AddScoped<IShelfRepository, ShelfRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IMarkupRepository, MarkupRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IBookService, BookService>();

        return services;
    }

    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
    {
        string? server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
        string? port = Environment.GetEnvironmentVariable("DB_PORT") ?? "3001";
        string? database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "wheremybooks";
        string? user = Environment.GetEnvironmentVariable("DB_USER") ?? "dev";
        string? password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "yma2578k";

        string connectionString = $"Host={server};" +
                                  $"Port={port};" +
                                  $"Pooling=true;" +
                                  $"Database={database};" +
                                  $"User Id={user};" +
                                  $"Password={password};";

        services.AddDbContext<WhereMyBookDbContext>(options => { options.UseNpgsql(connectionString); });

        return services;
    }

    public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpClient("GoogleService", httpClient =>
        {
            httpClient.BaseAddress = new Uri(config.GetSection("GoogleService")["BASE_URI"]);
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            var handler = new HttpClientHandler
            {
               ClientCertificateOptions = ClientCertificateOption.Manual,
               ServerCertificateCustomValidationCallback = ((message, certificate2, arg3, arg4) => { return true;})
            };
            
            return handler;
        });

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(
            config => config.RegisterServicesFromAssembly(typeof(CreateOwnerCommand).Assembly)
        );

        return services;
    }

    public static IServiceCollection AddFluentValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<CreateOwnerValidation>();

        return services;
    }
}