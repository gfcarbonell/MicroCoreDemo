using Core.Repository.Contract.IRepositories.SQLServer.Core;
using Core.Repository.Repositories.SQLServer.Core;
using Core.Service.Contract.IServices;
using Core.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCutting.Registers
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterOthers(services);

            return services;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>(); 
            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            return services;
        }
    }
}
