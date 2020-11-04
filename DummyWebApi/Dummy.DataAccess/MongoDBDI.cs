using Dummy.DataAccess.MongoDB;
using Dummy.DataAccess.MongoDB.Repository;
using Dummy.DataAccess.Repository;
using Dummy.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.DataAccess
{
    public static class MongoDBDI
    {

        public static IServiceCollection AddMongoDBDataRepositories(this IServiceCollection services, DbConnection dbConnection)
        {
            IMongoRepository mongoDB = new MongoRepository(dbConnection.ConnectionString, dbConnection.DatabaseName);
            services.AddSingleton(mongoDB);
            services.AddScoped<IDummiesRepository, DummiesRepository>();
            return services;
        }
    }
}
