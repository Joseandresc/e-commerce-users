 using System.ComponentModel.Design;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add Infrastructure services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>

        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }

    }
}