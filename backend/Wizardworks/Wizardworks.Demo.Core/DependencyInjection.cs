using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Wizardworks.Demo.Core.Config;
using Wizardworks.Demo.Core.Feature.Squares.Repository;
using Azure.Storage.Blobs;

namespace Wizardworks.Demo.Core;
public static class DependencyInjection
{
    public static void AddWizardworksDemoCoreDependencies(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.Configure<AppSetting>(configuration.GetSection("AppSettings"));

        services.AddSingleton(x => new BlobServiceClient(configuration.GetConnectionString("StorageAccount")));

        services.AddScoped<ISquaresRepository, SquaresRepository>();
    }
}
