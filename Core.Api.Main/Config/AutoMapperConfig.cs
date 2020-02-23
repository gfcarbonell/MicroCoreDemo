using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.Config
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
