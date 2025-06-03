using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.Aventureo.Services;
using Core.Aventureo.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Aventureo.Extensions
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IJwtAuthService, JwtAuthService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IViajeService, ViajeService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IPartePlanService, PartePlanService>();
            services.AddScoped<IGastoService, GastoService>();
        }
    }
}
