using Core.Aventureo.Interfaces.Repository;
using Core.Aventureo.Interfaces.Repository.Entities;
using Infraestructure.Aventureo.Repository;
using Infraestructure.Aventureo.Repository.Entities;
using Infrastructure.Aventureo.Repository.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Aventureo.Extension
{
    public static class ServiceExtension
    {
        public static void AddInfraestructureLayer(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IViajeRepository, ViajeRepository>();
            services.AddTransient<IGastoRepository, GastoRepository>();
            services.AddTransient<IPartePlanRepository, PartePlanRepository>();
            services.AddTransient<IPlanRepository, PlanRepository>();
        }
    }
}
