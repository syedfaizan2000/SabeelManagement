using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace SabeelManagement
{
    public static class ConfigureService
    {
        public static IServiceCollection AddSabeelManagementService(this IServiceCollection services, IConfiguration config)
        { // Replace this with your actual connection string

            var connection = config.GetSection("ConnectionStrings:MySql").Value.ToString();
            services.AddDbContext<MySqlContext>(options =>
            options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
            //services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }
    }
}
