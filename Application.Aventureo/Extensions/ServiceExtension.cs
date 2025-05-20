using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Aventureo.Services;
using Core.Aventureo.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Aventureo.Extensions
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services) {
           services.AddScoped<IJwtAuthService, JwtAuthService>();        
        }
    }
}
