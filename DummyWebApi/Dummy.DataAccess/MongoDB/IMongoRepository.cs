using MongoDbGenericRepository;

namespace Dummy.DataAccess.MongoDB
{
    public interface IMongoRepository
    {
        IMongoDbContext GetContext();

    }
}
