using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infraestructure.Repository;
using eCommerce.Infraestructure.DbContext;

namespace eCommerce.Infraestructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add Infrastructure services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IUsersRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
       

    }
}
