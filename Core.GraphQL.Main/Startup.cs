using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CrossCutting.Registers;
using Core.GraphQL.Main.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Core.GraphQL.Main
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public ILoggerFactory _loggerFactory { get; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            this._configuration = configuration;
            this._loggerFactory = loggerFactory;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Inject Dependecies
            IoCRegister.AddRegistration(services);

            // JWT
            JwtAuthConfig.AddRegistration(services, this._configuration);

            // Cors
            CorsConfig.AddRegistration(services);

            //GraphQL 
            GraphQLConfig.AddRegistration(services);
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
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseWebSockets();
            app.UseHttpsRedirection();
            app.UseMvc();

            // JWT
            JwtAuthConfig.AddRegistration(app, this._configuration);

            // Cors
            CorsConfig.AddRegistration(app);

            //GraphQL 
            GraphQLConfig.AddRegistration(app);
        }
    }
}
