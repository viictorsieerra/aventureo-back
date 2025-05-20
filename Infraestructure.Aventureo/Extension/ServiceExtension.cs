using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.Interfaces.Repository.Entities;
using Infraestructure.Aventureo.Repository.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Aventureo.Extension
{
    public static class ServiceExtension
    {
        public static void AddInfraestructureLayer(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
