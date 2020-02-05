using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.Config
{
    public static class CorsConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .Build()
                );
            });
            return services;
        }
        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            return app;
        }
    }
}
