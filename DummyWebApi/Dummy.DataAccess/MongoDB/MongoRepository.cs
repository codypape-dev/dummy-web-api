using MongoDbGenericRepository;

namespace Dummy.DataAccess.MongoDB
{
    public class MongoRepository : BaseMongoRepository, IMongoRepository
    {
        public MongoRepository(string connectionString, string databaseName = null) : base(connectionString, databaseName)
        {
            MapMongoDbContext.Map();
        }

        public IMongoDbContext GetContext()
        {
            return this.MongoDbContext;
        }
    }
}
