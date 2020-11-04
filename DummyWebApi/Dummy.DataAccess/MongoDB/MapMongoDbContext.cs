using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Dummy.DataAccess.MongoDB
{
    public class MapMongoDbContext
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Model.Dummy>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }

    }
}
