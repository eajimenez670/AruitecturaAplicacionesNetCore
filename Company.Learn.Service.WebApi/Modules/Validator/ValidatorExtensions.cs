using Company.Learn.Application.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Learn.Service.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDTOValidator>();
            return services;
        }
    }
}
