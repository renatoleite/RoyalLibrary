using Domain.Interfaces.Repositories;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.DataAccess.SqlServer.Configs;
using Infrastructure.DataAccess.SqlServer.Context;
using Infrastructure.DataAccess.SqlServer.Context.RetryPolicy;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.DependencyInjection
{
    public static class InfrastructureExtensions
    {
        private const string SqlConfigurationSection = "SqlConfiguration";
        private const string SqlConnectionStringSection = "SqlConfiguration:ConnectionString";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlServerPolicyConfiguration>(configuration.GetSection(SqlConfigurationSection));
      
            services.AddScoped<IDatabaseRetryPolicy, DatabaseRetryPolicy>();
            services.AddScoped<IDbConnectionWrapper, DbConnectionWrapper>();
            services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetSection(SqlConnectionStringSection).Value));

            services.AddScoped<IBooksRepository, BooksRepository>();

            return services;
        }
    }
}
