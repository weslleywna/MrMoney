using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Domain.Interfaces.Services;
using MrMoney.Domain.Services;
using MrMoney.Infrastructure.Data;
using MrMoney.Infrastructure.Repositories;

namespace MrMoney.API.Configurations
{
    public static class Injector
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Database
            MongoDbContext.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            MongoDbContext.DatabaseName = configuration.GetSection("MongoConnection:DatabaseName").Value;
            MongoDbContext.IsSSL = Convert.ToBoolean(configuration.GetSection("MongoConnection:IsSSL").Value);

            // Services
            services.AddScoped<IAuthService, AuthService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
