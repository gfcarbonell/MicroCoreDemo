using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Api.Main.Config;
using Core.CrossCutting.Registers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Core.Api.Main
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Swagger
            SwaggerConfig.AddRegistration(services);

            // AutoMapper
            AutoMapperConfig.AddRegistration(services);

            // Inject Dependecies
            IoCRegister.AddRegistration(services);

            // JWT
            JwtAuthConfig.AddRegistration(services, _configuration);

            // Cors
            CorsConfig.AddRegistration(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            // Swagger
            SwaggerConfig.AddRegistration(app);

            // JWT
            JwtAuthConfig.AddRegistration(app, this._configuration);

            // Cors
            CorsConfig.AddRegistration(app);

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
