using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wizardworks.Demo.Core.Config;
using Wizardworks.Demo.Core.Feature.Squares.Repository;

namespace Wizardworks.Demo.Core;
public static class DependencyInjection
{
    public static void AddWizardworksDemoCoreDependencies(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.Configure<AppSetting>(configuration.GetSection("AppSettings"));

        services.AddSingleton(x => new BlobServiceClient(configuration.GetConnectionString("StorageAccount")));

        services.AddScoped<ISquaresRepository, SquaresRepository>();
    }  
    
    public static void UseWizardworksCORS(this IApplicationBuilder app, IConfigurationManager configuration)
    {
        var allowedOrigins = configuration.GetSection("CORS:AllowedOrigins").Get<string[]>()
            ?? throw new ArgumentException("CORS:AllowedOrigins can't be empty");

        app.UseCors(corsBuilder => corsBuilder
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
    }
}
