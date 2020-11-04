using Dummy.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.DataAccess
{
    public static class DataDI
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services, DbConnection dbConnection)
        {
            services.AddMongoDBDataRepositories(dbConnection);
            return services;
        }
    }
}
