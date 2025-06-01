using MDDPlatform.Diagrams.Application.ModelEngines;
using MDDPlatform.Diagrams.Infrastructure.ExternalServices;
using MDDPlatform.Diagrams.Services.Interfaces;
using MDDPlatform.Diagrams.Services.PlantUMLs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.Diagrams.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IDomainModelService,DomainModelService>(httpClient=>
        {
            var url = configuration["Services:DomainModelService"];
            httpClient.BaseAddress = new Uri(url);
        });

        services.AddScoped<IPlantUMLService,PlantUMLService>();
        services.AddScoped<IModelEngineService,ModelEngineService>();
        
        return services;
    }
}