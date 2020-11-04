using Dummy.Business.Dummies;
using Dummy.DataAccess;
using Dummy.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Business
{
    public static class BusinessDI
    {

        public static IServiceCollection AddBusinessComponents(this IServiceCollection services)
        {
            services.AddScoped<IDummy, Dummies.Dummy>();
            services.AddDataRepositories(new DbConnection { ConnectionString = AppVariables.DBConnection, DatabaseName = AppVariables.DatabaseName });

            return services;
        }

    }
}
