using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Aventureo.Utils;
using Core.Aventureo.Interfaces.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Aventureo.Extensions
{
    public static class UtilExtension
    {
        public static void AddUtilServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISecurityUtils, SecurityUtils>(
                provider => new SecurityUtils(configuration));
        }
    }
}
