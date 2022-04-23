using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Domain.Interfaces.Services;
using MrMoney.Domain.Models;
using MrMoney.Domain.Services;
using MrMoney.Infrastructure.Data;
using MrMoney.Infrastructure.Repositories;
using MrMoney.Util.Global;

namespace MrMoney.API.Configurations
{
    public static class Injector
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Database
            DbConnectionConfiguration.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            DbConnectionConfiguration.DatabaseName = configuration.GetSection("MongoConnection:DatabaseName").Value;
            DbConnectionConfiguration.IsSSL = Convert.ToBoolean(configuration.GetSection("MongoConnection:IsSSL").Value);

            // Services
            services.AddScoped<IAuthService, AuthService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
