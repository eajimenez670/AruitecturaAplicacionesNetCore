using Company.Learn.Application.Interface;
using Company.Learn.Application.Main;
using Company.Learn.Cross.Common;
using Company.Learn.Cross.Logging;
using Company.Learn.Domain.Core;
using Company.Learn.Domain.Interface;
using Company.Learn.Infrastructure.Data;
using Company.Learn.Infrastructure.Interface;
using Company.Learn.Infrastructure.Repository;
using Company.Learn.Service.WebApi.JWTSecurity;
using Company.Learn.Service.WebApi.JWTSecurity.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Learn.Service.WebApi.Service
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServiceRegistrator'
    public static class ServiceRegistrator
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServiceRegistrator'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServiceRegistrator.RegisterServices(IServiceCollection)'
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServiceRegistrator.RegisterServices(IServiceCollection)'
        {
            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<ITokenFactory, TokenFactory>();

            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        }
    }
}
