using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Aventureo.ExternalCommunication;
using Core.Aventureo.Interfaces.ExternalCommunication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Aventureo.Extensions
{
    public static class ExternalExtension
    {
        public static void AddExternalCommunication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPlacesService, PlacesService>(
                provider => new PlacesService(configuration));
            services.AddScoped<IAIService, AIService>(
                provider => new AIService(configuration));
            services.AddScoped<IMapService, MapService>();
        }
    }
}
